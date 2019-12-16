namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using UFSoft.UBF.AopFrame;
    using UFSoft.UBF.PL;
    using UFSoft.UBF.Util.Context;
    using UFIDA.U9.MO.Enums;

    /// <summary>
    /// ECNMOQuery partial 
    /// </summary>	
    public partial class ECNMOQuery
    {
        internal BaseStrategy Select()
        {
            return new ECNMOQueryImpementStrategy();
        }
    }

    #region  implement strategy
    /// <summary>
    /// Impement Implement
    /// 
    /// </summary>	
    internal partial class ECNMOQueryImpementStrategy : BaseStrategy
    {
        public ECNMOQueryImpementStrategy() { }

        public override object Do(object obj)
        {
            ECNMOQuery bpObj = (ECNMOQuery)obj;

            StringBuilder strbResult = new StringBuilder();

            if (string.IsNullOrEmpty(bpObj.BOMItemInfo))
            {
                //logger.Error(string.Format("创建料品失败：传入参数BOMItemInfo为空。"));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", "查询生产订单失败：传入参数BOMItemInfo为空。"));
                return strbResult.ToString();
            }
            ECNQuery ecnQuery = new ECNQuery();

            try
            {
                ecnQuery = XmlSerializerHelper.XmlDeserialize<ECNQuery>(bpObj.BOMItemInfo, Encoding.Unicode);
                //cxtInfo = XmlSerializerHelper.XmlDeserialize<ContextInfo>(bpObj.ContextInfo, Encoding.Unicode);
            }
            catch (Exception ex)
            {
                //logger.Error(string.Format("反序列化ItemInfo失败：{0}", bpObj.ItemInfo));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", string.Format("反序列化BOMItemInfo失败：{0}", bpObj.BOMItemInfo)));
                return strbResult.ToString();
            }

            if (ecnQuery.BomMasters.Count <= 0)
            {
                //logger.Error(string.Format("传入的ItemInfo中没有料品信息"));
                strbResult.AppendLine(string.Format("<ResultInfo Error=\"{0}\" />", "传入的BOMItemInfo中没有BOM信息"));
                return strbResult.ToString();
            }
            else
            {
                foreach (BOMMaster bomMaster in ecnQuery.BomMasters)
                {
                    int BOMType = (bomMaster.BOMType != "0") ? 1 : 0;
                    //CBO.MFG.BOM.BOMMaster _bomMaster = CBO.MFG.BOM.BOMMaster.Finder.Find("ItemMaster.Code=@ItemCode and BOMVersionCode =@BOMVersionCode and BOMType =@BOMType ", new OqlParam[3] { new OqlParam(bomMaster.ItemMasterCode), new OqlParam(bomMaster.BOMVersionCode), new OqlParam(BOMType) });
                    //if (_bomMaster == null)
                    //{
                    //    strbResult.AppendLine(string.Format("<ResultInfo Error=\"{0}\" />", "传入的BOMItemInfo中组织未找" + bomMaster.ItemMasterCode + ",版本为：" + bomMaster.BOMVersionCode + ",U9 BOM信息"));
                    //    return strbResult.ToString();
                    //}

                    foreach (BOMComponent bomComponent in bomMaster.Components)
                    {
                        bomComponent.MOInfos = new List<MOInfo>();

                        // and ItemVersion.Version =@ItemVersion  , new OqlParam(bomComponent.PreItemVersionCode) 
                        //MO.MO.MOPickList.EntityList mopicklist = MO.MO.MOPickList.Finder.FindAll("MO.BOMMaster =@BOMMaster and MO.Org.Code=@OrgCode and ItemMaster.Code =@ItemMaster and MO.DocState !=3", new OqlParam[3] { new OqlParam(_bomMaster.ID), new OqlParam(ecnQuery.OrgCode), new OqlParam(bomComponent.PreItemCode) });
                        if (bomComponent.ECNAction == "add")
                        {
                            MO.MO.MO.EntityList lstMO = MO.MO.MO.Finder.FindAll("ItemMaster.Code = @MOItemMaster and DocState !=3 ", new OqlParam[1] { new OqlParam(bomMaster.ItemMasterCode) });
                            //MO.MO.MO.EntityList lstMO = MO.MO.MO.Finder.FindAll("ItemMaster.Code = @MOItemMaster and BOMVersion.VersionCode = @BOMVersionCode and DocState !=3 ",
                            //    new OqlParam[2] { new OqlParam(bomMaster.ItemMasterCode), new OqlParam(bomMaster.BOMVersionCode) });
                           
                            foreach (var moItem in lstMO)
                            {
                                //排除终止状态
                                if (moItem.Cancel.Canceled)
                                {
                                    continue;
                                }
                                if (moItem.ProductQty > 0)
                                {
                                    UFIDA.U9.CBO.SCM.Item.ItemMaster itemPick_Add = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.ID=@Org and Code =@Code",
                                    new OqlParam[2] { new OqlParam(moItem.Org.ID.ToString()), new OqlParam(bomComponent.PostItemCode) });

                                    MOInfo moInfo = new MOInfo();
                                    moInfo.OrgCode = moItem.Org.Code;
                                    moInfo.MONo = moItem.DocNo;
                                    moInfo.StatusCode = moItem.DocState.Value;
                                    if (moItem.BOMVersionKey != null)
                                    {
                                        moInfo.BOMVersion = moItem.BOMVersion.VersionCode;
                                    }
                                    else
                                    {
                                        moInfo.BOMVersion = string.Empty;
                                    }
                                    switch (moItem.DocState.Value)
                                    {
                                        case 0:
                                            moInfo.StatusName = "开立";
                                            break;
                                        case 1:
                                            moInfo.StatusName = "已核准";
                                            break;
                                        case 2:
                                            moInfo.StatusName = "开工";
                                            break;
                                        case 3:
                                            moInfo.StatusName = "完工";
                                            break;
                                        case 4:
                                            moInfo.StatusName = "核准中";
                                            break;
                                        default:
                                            moInfo.StatusName = moItem.DocState.Name;
                                            break;
                                    }
                                    //MOStateEnum.GetFromValue(moItem.DocState.Value).
                                    moInfo.MOQty = moItem.ProductQty;
                                    moInfo.PrePerUsageQty = 0;
                                    moInfo.PreUsageQty = 0;
                                    moInfo.FinishedQty = moItem.TotalRcvQty;
                                    moInfo.ItemVersionNo = itemPick_Add.Version;//备件子件料品版本
                                    moInfo.ItemCode = itemPick_Add.Code;//备件子件料号
                                    moInfo.FetchedQty = 0;
                                    moInfo.DocLineNo = 0;
                                    moInfo.IsFromPhantomExpanding = false;
                                    moInfo.PostPerUsageQty = bomComponent.PostUsageQty;
                                    moInfo.PostUsageQty = (moItem.ProductQty * bomComponent.PostUsageQty) * (1 + bomComponent.PostScrap) / bomComponent.PostParentQty;
                                    moInfo.PhantomItemCode = "";
                                    moInfo.PhantomItemName = "";

                                    bomComponent.MOInfos.Add(moInfo);
                                }
                            }
                        }
                        else
                        {
                            //MO.MO.MOPickList.EntityList mopicklist = MO.MO.MOPickList.Finder.FindAll("IsPhantomPart = 0 and MO.ItemMaster.Code = @MOItemMaster and MO.BOMVersion.VersionCode = @BOMVersionCode and MO.Org.Code = @OrgCode and ItemMaster.Code =@ItemMaster and MO.DocState !=3", 
                            //    new OqlParam[4] { new OqlParam(bomMaster.ItemMasterCode),new OqlParam(bomMaster.BOMVersionCode), new OqlParam(ecnQuery.OrgCode), new OqlParam(bomComponent.PreItemCode) });
                            MO.MO.MOPickList.EntityList mopicklist = MO.MO.MOPickList.Finder.FindAll("IsPhantomPart = 0 and MO.ItemMaster.Code = @MOItemMaster and ItemMaster.Code =@ItemMaster and MO.DocState !=3",
                                new OqlParam[2] { new OqlParam(bomMaster.ItemMasterCode), new OqlParam(bomComponent.PreItemCode) });
                            if (mopicklist != null && mopicklist.Count > 0)
                            {
                                List<MOInfo> lstMoInfo = new List<MOInfo>();
                                foreach (MO.MO.MOPickList mopick in mopicklist)
                                {
                                    //排除终止状态和虚拟件备料行
                                    if (mopick.MO.Cancel.Canceled || mopick.IsPhantomPart)
                                    {
                                        continue;
                                    }
                                    if (mopick.MO.ProductQty > 0)
                                    {
                                        MOInfo moInfo = new MOInfo();
                                        moInfo.OrgCode = mopick.MO.Org.Code;
                                        moInfo.MONo = mopick.MO.DocNo;
                                        moInfo.StatusCode = mopick.MO.DocState.Value;
                                        if (mopick.MO.BOMVersionKey != null)
                                        {
                                            moInfo.BOMVersion = mopick.MO.BOMVersion.VersionCode;
                                        }
                                        else
                                        {
                                            moInfo.BOMVersion = string.Empty;
                                        }
                                        switch (mopick.MO.DocState.Value)
                                        {
                                            case 0:
                                                moInfo.StatusName = "开立";
                                                break;
                                            case 1:
                                                moInfo.StatusName = "已核准";
                                                break;
                                            case 2:
                                                moInfo.StatusName = "开工";
                                                break;
                                            case 3:
                                                moInfo.StatusName = "完工";
                                                break;
                                            case 4:
                                                moInfo.StatusName = "核准中";
                                                break;
                                            default:
                                                moInfo.StatusName = mopick.MO.DocState.Name;
                                                break;
                                        }
                                        moInfo.MOQty = mopick.MO.ProductQty;
                                        moInfo.ItemCode = mopick.ItemCode;
                                        moInfo.PrePerUsageQty = mopick.ActualReqQty / mopick.MO.ProductQty;
                                        moInfo.PreUsageQty = mopick.ActualReqQty;//实际需求数量
                                        moInfo.FinishedQty = mopick.MO.TotalRcvQty;
                                        moInfo.ItemVersionNo = mopick.ItemMaster.Version;//备件子件料品版本
                                        moInfo.FetchedQty = mopick.IssuedQty;//已领数量
                                        moInfo.IsFromPhantomExpanding = mopick.IsFromPhantomExpanding;
                                        moInfo.PhantomItemCode = mopick.IsFromPhantomExpanding ? mopick.BOMComponent.BOMMaster.ItemMaster.Code : "";
                                        moInfo.PhantomItemName = mopick.IsFromPhantomExpanding ? mopick.BOMComponent.BOMMaster.ItemMaster.Name : "";
                                        moInfo.DocLineNo = mopick.DocLineNO;
                                        if (mopick.IsFromPhantomExpanding)
                                        {
                                            //当备料为虚拟件展出时，默认替换后用量等于替换前用量
                                            moInfo.PostPerUsageQty = mopick.ActualReqQty / mopick.MO.ProductQty;
                                            moInfo.PostUsageQty = mopick.ActualReqQty;//实际需求数量
                                        }
                                        else
                                        {
                                            moInfo.PostPerUsageQty = bomComponent.PostUsageQty;
                                            moInfo.PostUsageQty = (mopick.MO.ProductQty * bomComponent.PostUsageQty) * (1 + bomComponent.PostScrap) / bomComponent.PostParentQty;
                                        }

                                        lstMoInfo.Add(moInfo);
                                        bomComponent.MOInfos.Add(moInfo);
                                    }
                                }
                                #region 【取消】对相同料品的备料行合并及排序。备料表下因虚拟件展开分解出多个相同料品的情况非常少，通过“是否虚拟件展开”和“来源虚拟料号”可以进行区分。
                                //var lstMoInfoGroup = from m in lstMoInfo
                                //                     group m by m.ItemCode into g
                                //                     select new { ItemCode = g.Key, Details = g };
                                //foreach (var t in lstMoInfoGroup)
                                //{
                                //    //如果存在相同的料号备料，才进行合并处理。
                                //    if (t.Details.Count() > 1)
                                //    {
                                //        var lstSection = from m in lstMoInfo
                                //                where m.ItemCode == t.ItemCode
                                //                select m;
                                //        MOInfo moinfoCombin = null;
                                //        #region 检索合并行
                                //        foreach (var mItem in lstSection)
                                //        {
                                //            //优先取：不是虚拟件展开的备料行
                                //            if (!mItem.IsFromPhantomExpanding)
                                //            {
                                //                moinfoCombin = mItem;
                                //                break;
                                //            }
                                //            else
                                //            {
                                //                //初始行
                                //                if (moinfoCombin == null)
                                //                {
                                //                    moinfoCombin = mItem;
                                //                }
                                //                else
                                //                {
                                //                    //再取：已领数量更小的。
                                //                    if (moinfoCombin.FetchedQty > mItem.FetchedQty)
                                //                    {
                                //                        moinfoCombin = mItem;
                                //                    }
                                //                    else
                                //                    {
                                //                        //最后取：同时虚拟件展开，已领数量相同的最小行号
                                //                        if (moinfoCombin.FetchedQty == mItem.FetchedQty && moinfoCombin.DocLineNo > mItem.DocLineNo)
                                //                        {
                                //                            moinfoCombin = mItem;
                                //                        }
                                //                    }
                                //                }
                                //            }
                                //        }
                                //        #endregion
                                //    }
                                //}
                                #endregion
                            }
                        }

                    }
                }
            }
            
            ECNMOQueryRlt ecnMOQueryRlt = new ECNMOQueryRlt();
            ecnMOQueryRlt.OrgCode = ecnQuery.OrgCode;
            ecnMOQueryRlt.BomMasters = ecnQuery.BomMasters;

            strbResult.Append(XmlSerializerHelper.XmlSerialize<ECNMOQueryRlt>(ecnMOQueryRlt, Encoding.Unicode));


            return strbResult.ToString();
        }
    }

    #endregion


}