﻿namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PLMECNQuerySV;
    using UFSoft.UBF.AopFrame;
    using UFSoft.UBF.Util.Context;
    using UFSoft.UBF.PL;
    using UFIDA.U9.CBO.SCM.Item;

    /// <summary>
    /// QueryPLMECN partial 
    /// </summary>	
    public partial class QueryPLMECN
    {
        internal BaseStrategy Select()
        {
            return new QueryPLMECNImpementStrategy();
        }
    }

    #region  implement strategy
    /// <summary>
    /// Impement Implement
    /// 服务根据原保存的ECN变更单ECNInfo查询出当前MO的完工入库数量TotalRcvQty设置到PostMOTotalRcvQty，
    /// 将备料表的已领数量设置到PostIssuedQty。两者可用于同ECNInfo记录的原完工入库(快照)数量PreMOTotalRcvQty和原已领(快照)数量PreIssuedQty进行比较。
    /// </summary>	
    internal partial class QueryPLMECNImpementStrategy : BaseStrategy
    {
        public QueryPLMECNImpementStrategy() { }

        public override object Do(object obj)
        {
            QueryPLMECN bpObj = (QueryPLMECN)obj;

            StringBuilder strbResult = new StringBuilder();

            if (string.IsNullOrEmpty(bpObj.ECNAlterInfo))
            {
                //logger.Error(string.Format("创建料品失败：传入参数BOMItemInfo为空。"));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", "传输ECN信息失败：传入参数ECNAlterInfo为空。"));
                return strbResult.ToString();
            }

            ECNDiffRequest ecnDiffRequest = new ECNDiffRequest();

            try
            {
                ecnDiffRequest = XmlSerializerHelper.XmlDeserialize<ECNDiffRequest>(bpObj.ECNAlterInfo, Encoding.Unicode);
                //cxtInfo = XmlSerializerHelper.XmlDeserialize<ContextInfo>(bpObj.ContextInfo, Encoding.Unicode);
            }
            catch (Exception ex)
            {
                //logger.Error(string.Format("反序列化ItemInfo失败：{0}", bpObj.ItemInfo));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", string.Format("反序列化ECNAlterInfo失败：{0}", bpObj.ECNAlterInfo)));
                return strbResult.ToString();
            }

            PLMBE.ECNAlterRequestBE.ECNInfo ecnInfo = PLMBE.ECNAlterRequestBE.ECNInfo.Finder.Find("ECNDocNo=@ECNDocNo", new OqlParam[1] { new OqlParam(ecnDiffRequest.ECNDocNo) });

            if (ecnInfo != null)
            {
                ECNDiffResponse _ecnAlterRequest = new ECNDiffResponse();
                _ecnAlterRequest.ECNDocNo = ecnInfo.ECNDocNo;
                List<ECNBomMaster> _ecnBomMasterlist = new List<ECNBomMaster>();

                foreach (BOMMaster reqBOMMaster in ecnDiffRequest.BomMasters)
                {
                    foreach (PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter in ecnInfo.ECNAlter)
                    {
                        foreach (BOMComponent reqBOMComp in reqBOMMaster.Components)
                        {
                            if (reqBOMMaster.ItemMasterCode.Equals(ecnAlter.ItemMasterCode) && reqBOMMaster.BOMVersionCode.Equals(ecnAlter.BOMVersionCode)
                                && reqBOMMaster.BOMType.Equals(ecnAlter.BOMType) 
                                && reqBOMComp.ECNAction.Equals(ecnAlter.ECNAction) && reqBOMComp.PreItemCode.Equals(ecnAlter.PreItemCode)
                                && reqBOMComp.PreItemVersionCode.Equals(ecnAlter.PreItemVersionCode) && reqBOMComp.PostItemCode.Equals(ecnAlter.PostItemCode)
                                && reqBOMComp.PostItemVersionCode.Equals(ecnAlter.PostItemVersionCode))
                            {
                                ECNBomMaster _ecnBomMaster = new ECNBomMaster();
                                _ecnBomMaster.ItemMasterCode = ecnAlter.ItemMasterCode;//物料编码
                                _ecnBomMaster.BOMVersionCode = ecnAlter.BOMVersionCode;//BOM版本号
                                _ecnBomMaster.BOMType = ecnAlter.BOMType;//BOM种类
                                _ecnBomMaster.ECNAtlerID = ecnAlter.ID;
                                _ecnBomMasterlist.Add(_ecnBomMaster);

                                ECNBOMComponent _ecnBOMComponent = new ECNBOMComponent();
                                _ecnBOMComponent.PreItemCode = ecnAlter.PreItemCode;//替换前子件物料编码
                                _ecnBOMComponent.PreItemVersionCode = ecnAlter.PreItemVersionCode;//替换前物料版本号
                                _ecnBOMComponent.PreIssueUomCode = ecnAlter.PreIssueUomCode;//替换前单位
                                _ecnBOMComponent.PreUsageQty = ecnAlter.PreUsageQty;//替换前用量
                                _ecnBOMComponent.PreScrap = ecnAlter.PreScrap;//替换前损耗率
                                _ecnBOMComponent.PreParentQty = ecnAlter.PreParentQty;//替换前母件底数
                                _ecnBOMComponent.ECNAction = ecnAlter.ECNAction;//ECN事件
                                _ecnBOMComponent.PostItemCode = ecnAlter.PostItemCode;//替换后子件物料编码
                                _ecnBOMComponent.PostItemVersionCode = ecnAlter.PostItemVersionCode;//替换后物料版本号
                                _ecnBOMComponent.PostIssueUomCode = ecnAlter.PostIssueUomCode;//替换后单位
                                _ecnBOMComponent.PostUsageQty = ecnAlter.PostUsageQty;//替换后用量
                                _ecnBOMComponent.PostScrap = ecnAlter.PostScrap;//替换后损耗率
                                _ecnBOMComponent.PostParentQty = ecnAlter.PostParentQty;//替换后母件底数

                                List<ECNMOInfo> _ecnMOInfolist = new List<ECNMOInfo>();

                                foreach (PLMBE.ECNAlterRequestBE.ECNAlterMOInfo ecnAlterMoInfo in ecnAlter.ECNAlterMOInfo)
                                {
                                    ECNMOInfo _ecnMOInfo = new ECNMOInfo();
                                    _ecnMOInfo.IsAlter = ecnAlterMoInfo.IsAlter;//是否修改
                                    _ecnMOInfo.OrgCode = ecnAlterMoInfo.OrgCode;//组织编号
                                    MO.MO.MO mo = MO.MO.MO.Finder.Find("DocNo=@DocNo and Org.Code = @OrgCode",
                                        new OqlParam[2] { new OqlParam(ecnAlterMoInfo.MONo), new OqlParam(ecnAlterMoInfo.OrgCode) });
                                    _ecnMOInfo.MONo = ecnAlterMoInfo.MONo;//MO单号

                                    _ecnMOInfo.MOQty = ecnAlterMoInfo.MOQty;//MO订单数量
                                    if (mo != null)
                                        _ecnMOInfo.PostFinishedQty = mo.TotalRcvQty;     //最新MO入库数量

                                    _ecnMOInfo.PreFinishedQty = ecnAlterMoInfo.MOTotalRcvQty;     //快照MO入库数量
                                    _ecnMOInfo.PrePerUsageQty = ecnAlterMoInfo.PrePerUsageQty;//替换前单个子件用量
                                    _ecnMOInfo.PreUsageQty = ecnAlterMoInfo.PreUsageQty;//替换前子件总需求量
                                    _ecnMOInfo.DiffPerUsageQty = ecnAlterMoInfo.DiffPerUsageQty;//单个变化差量
                                    _ecnMOInfo.DiffUsageQty = ecnAlterMoInfo.DiffUsageQty;//变化总差量
                                    _ecnMOInfo.PostPerUsageQty = ecnAlterMoInfo.PostPerUsageQty;//替换后单个子件用量
                                    _ecnMOInfo.PostUsageQty = ecnAlterMoInfo.PostUsageQty;//替换后子件总需求量

                                    _ecnMOInfo.PickListDocLineNo = ecnAlterMoInfo.PickListDocLineNo;
                                    _ecnMOInfo.DocLineNo = ecnAlterMoInfo.PickListDocLineNo;
                                    if (mo.BOMVersionKey != null)
                                    {
                                        _ecnMOInfo.BOMVersion = mo.BOMVersion.VersionCode;
                                    }
                                    else
                                    {
                                        _ecnMOInfo.BOMVersion = string.Empty;
                                    }
                                    _ecnMOInfo.StatusCode = mo.DocState.Value;
                                    switch (mo.DocState.Value)
                                    {
                                        case 0:
                                            _ecnMOInfo.StatusName = "开立";
                                            break;
                                        case 1:
                                            _ecnMOInfo.StatusName = "已核准";
                                            break;
                                        case 2:
                                            _ecnMOInfo.StatusName = "开工";
                                            break;
                                        case 3:
                                            _ecnMOInfo.StatusName = "完工";
                                            break;
                                        case 4:
                                            _ecnMOInfo.StatusName = "核准中";
                                            break;
                                        default:
                                            _ecnMOInfo.StatusName = mo.DocState.Name;
                                            break;
                                    }

                                    _ecnMOInfo.IsFromPhantomExpanding = ecnAlterMoInfo.IsFromPhantomExpanding;
                                    MO.MO.MOPickList mopick = MO.MO.MOPickList.Finder.Find("MO.ID=@ID and  ItemMaster.Code =@ItemMaster and DocLineNO=@LineNo ",
                                        new OqlParam[3] { new OqlParam(mo.ID), new OqlParam(ecnAlter.PreItemCode), new OqlParam(ecnAlterMoInfo.PickListDocLineNo) });
                                    if (mopick != null)
                                    {
                                        _ecnMOInfo.PostFetchedQty = mopick.IssuedQty; //最新领料数量
                                        _ecnMOInfo.ItemCode = mopick.ItemCode;
                                        _ecnMOInfo.PhantomItemCode = ecnAlterMoInfo.IsFromPhantomExpanding ? mopick.BOMComponent.BOMMaster.ItemMaster.Code : "";
                                        _ecnMOInfo.PhantomItemName = ecnAlterMoInfo.IsFromPhantomExpanding ? mopick.BOMComponent.BOMMaster.ItemMaster.Name : "";
                                        _ecnMOInfo.ItemVersionNo = mopick.ItemMaster.Version;
                                    }
                                    else
                                    {
                                        //新增子件的情况
                                        if (!string.IsNullOrEmpty(ecnAlter.PostItemCode))
                                        {
                                            UFIDA.U9.CBO.SCM.Item.ItemMaster itemPick_Add = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.ID=@Org and Code =@Code",
                                                new OqlParam[2] { new OqlParam(mo.Org.ID.ToString()), new OqlParam(ecnAlter.PostItemCode) });
                                            _ecnMOInfo.ItemVersionNo = itemPick_Add.Version;
                                            _ecnMOInfo.ItemCode = itemPick_Add.Code;
                                        }
                                    }
                                    _ecnMOInfo.PreFetchedQty = ecnAlterMoInfo.IssuedQty; //快照领料数量
                                    _ecnMOInfo.IsSplit = "N";//是否分割
                                    _ecnMOInfolist.Add(_ecnMOInfo);

                                    //当前MO生产订单数量没变化，则直接通过。减少MO分割查询
                                    if (mo.ProductQty.Equals(ecnAlterMoInfo.MOQty))
                                    {
                                        continue;
                                    }
                                    //若MO有分割则加入分割的MO
                                    #region 根据循环遍历出来的分割MO进行新增
                                    //List<MO.MO.MOSplitMergeRelation> lstCache = new List<MO.MO.MOSplitMergeRelation>();
                                    //LoopQueryMOSplit(lstCache, mo.ID, ecnInfo.CreatedOn);
                                    #endregion

                                    UFIDA.U9.MO.MO.MOSplitMergeRelation.EntityList lstSplit = UFIDA.U9.MO.MO.MOSplitMergeRelation.Finder.FindAll("PrevMO=@prevMO", new OqlParam[] { new OqlParam(mo.ID) });
                                    foreach (var itemMOSplit in lstSplit)
                                    {
                                        //不是分割方式或生成在本次ECN设变前的分割MO都排除掉
                                        if (itemMOSplit.SplitMergeType != UFIDA.U9.MO.Enums.MOSplitMergeStyleEnum.Split || itemMOSplit.CreatedOn <= ecnInfo.CreatedOn)
                                        {
                                            continue;
                                        }
                                        ECNMOInfo ecnMOInfo_Split = AddSplitMOInfo(ecnAlterMoInfo, _ecnMOInfo, mo, itemMOSplit);
                                        if (ecnMOInfo_Split != null)
                                        {
                                            _ecnMOInfolist.Add(ecnMOInfo_Split);
                                        }
                                    }
                                    ecnAlterMoInfo.MOQty = mo.ProductQty;//被分割后的生产订单数量
                                }

                                _ecnBOMComponent.ECNMOInfos = _ecnMOInfolist;

                                ECNBomMaster itemMaster = _ecnBomMasterlist.Find(delegate(ECNBomMaster _dto) { return (_dto.ECNAtlerID == ecnAlter.ID); });
                                // Add(_ecnBOMComponent);
                                itemMaster.ECNComponents = new List<ECNBOMComponent>();

                                itemMaster.ECNComponents.Add(_ecnBOMComponent);
                            }
                        }
                    }
                }
                _ecnAlterRequest.ECNBomMasters = _ecnBomMasterlist;

                strbResult.Append(XmlSerializerHelper.XmlSerialize<ECNDiffResponse>(_ecnAlterRequest, Encoding.Unicode));
            }
            else
            {
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", string.Format("ECNDocNo={0}未找到U9记录", ecnDiffRequest.ECNDocNo)));
                return strbResult.ToString();
            }
            return strbResult.ToString();
        }

        /// <summary>
        /// 添加分割后的MO返回,调整
        /// </summary>
        /// <param name="ecnAlterInfo">ECN设变MO记录</param>
        /// <param name="moInfoPre">分割前MO返回记录</param>
        /// <param name="mo">U9MO-信息</param>
        /// <param name="moSplitRelation">U9MO分割记录</param>
        /// <returns></returns>
        public ECNMOInfo AddSplitMOInfo(PLMBE.ECNAlterRequestBE.ECNAlterMOInfo ecnAlterInfo, ECNMOInfo moInfoPre, MO.MO.MO mo, UFIDA.U9.MO.MO.MOSplitMergeRelation moSplitRelation)
        {
            PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter = ecnAlterInfo.ECNAlter;
            MO.MO.MO nextMO = moSplitRelation.NextMO;

            //如果已存在当前变更MO清单单中
            foreach (PLMBE.ECNAlterRequestBE.ECNAlterMOInfo itemMo in ecnAlter.ECNAlterMOInfo)
            {
                if (itemMo.ID.Equals(nextMO.ID))
                {
                    return null;
                }
            }
            ECNMOInfo moinfoSplit = new ECNMOInfo();
            moinfoSplit.IsAlter = ecnAlterInfo.IsAlter;//是否修改
            moinfoSplit.OrgCode = ecnAlterInfo.OrgCode;//组织编号

            moinfoSplit.MONo = nextMO.DocNo;//MO单号
            moinfoSplit.MOQty = nextMO.ProductQty;//分割后新MO订单数量
            moinfoSplit.PostFinishedQty = 0;     //最新MO入库数量
            moinfoSplit.PreFinishedQty = 0;     //快照MO入库数量
            moinfoSplit.PrePerUsageQty = ecnAlterInfo.PrePerUsageQty;//替换前单个子件用量
            //moinfoSplit.PreUsageQty = ecnAlterInfo.PreUsageQty;//替换前子件总需求量
            moinfoSplit.DiffPerUsageQty = ecnAlterInfo.DiffPerUsageQty;//单个变化差量
            moinfoSplit.PostPerUsageQty = ecnAlterInfo.PostPerUsageQty;//替换后单个子件用量
            moinfoSplit.PickListDocLineNo = ecnAlterInfo.PickListDocLineNo;
            moinfoSplit.DocLineNo = ecnAlterInfo.PickListDocLineNo;
            if (mo.BOMVersionKey != null)
            {
                moinfoSplit.BOMVersion = mo.BOMVersion.VersionCode;
            }
            else
            {
                moinfoSplit.BOMVersion = string.Empty;
            }
            moinfoSplit.StatusCode = mo.DocState.Value;
            switch (mo.DocState.Value)
            {
                case 0:
                    moinfoSplit.StatusName = "开立";
                    break;
                case 1:
                    moinfoSplit.StatusName = "已核准";
                    break;
                case 2:
                    moinfoSplit.StatusName = "开工";
                    break;
                case 3:
                    moinfoSplit.StatusName = "完工";
                    break;
                case 4:
                    moinfoSplit.StatusName = "核准中";
                    break;
                default:
                    moinfoSplit.StatusName = mo.DocState.Name;
                    break;
            }

            moinfoSplit.IsFromPhantomExpanding = ecnAlterInfo.IsFromPhantomExpanding;
            MO.MO.MOPickList mopick = MO.MO.MOPickList.Finder.Find("MO.ID=@ID and  ItemMaster.Code =@ItemMaster and DocLineNO=@LineNo ",
                new OqlParam[3] { new OqlParam(mo.ID), new OqlParam(ecnAlter.PreItemCode), new OqlParam(ecnAlterInfo.PickListDocLineNo) });
            if (mopick != null)
            {
                moinfoSplit.PostFetchedQty = mopick.IssuedQty; //最新领料数量
                moinfoSplit.ItemCode = mopick.ItemCode;
                moinfoSplit.PhantomItemCode = ecnAlterInfo.IsFromPhantomExpanding ? mopick.BOMComponent.BOMMaster.ItemMaster.Code : "";
                moinfoSplit.PhantomItemName = ecnAlterInfo.IsFromPhantomExpanding ? mopick.BOMComponent.BOMMaster.ItemMaster.Name : "";
                moinfoSplit.ItemVersionNo = mopick.ItemMaster.Version;
            }
            else
            {
                //新增子件的情况
                if (!string.IsNullOrEmpty(ecnAlter.PostItemCode))
                {
                    UFIDA.U9.CBO.SCM.Item.ItemMaster itemPick_Add = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.ID=@Org and Code =@Code",
                        new OqlParam[2] { new OqlParam(mo.Org.ID.ToString()), new OqlParam(ecnAlter.PostItemCode) });
                    moinfoSplit.ItemVersionNo = itemPick_Add.Version;
                    moinfoSplit.ItemCode = itemPick_Add.Code;
                }
            }
            moinfoSplit.PostFetchedQty = 0; //最新领料数量
            moinfoSplit.PreFetchedQty = 0; //快照领料数量


            decimal ActualReqQty_Next = decimal.Zero;
            decimal ActualReqQty_Pre = decimal.Zero;

            decimal PreReqQty_Next = decimal.Zero;
            decimal PreReqQty_Pre = decimal.Zero;

            ItemMaster itemMaster = null;
            switch (ecnAlter.ECNAction.ToLower())
            {
                case "add": //新增
                case "qtyadd": //增加
                case "qtyreduce": //减少
                case "qtyreplace": //替换
                    if (String.IsNullOrEmpty(ecnAlter.PostItemCode))
                    {
                        throw new Exception("变更动作指定为'add新增'时，变更后的料号不允许空！");
                    }
                    itemMaster = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.ID=@Org and Code =@Code",
                        new OqlParam[2] { new OqlParam(mo.Org.ID.ToString()), new OqlParam(ecnAlter.PostItemCode) });
                    int round_precision = itemMaster.InventoryUOM.Round.Precision;

                    //从mo.ProductQty改为设变发起时的生产数量
                    if (ecnAlter.PostParentQty != 0)
                    {
                        ActualReqQty_Next = (ecnAlterInfo.MOQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty / ecnAlter.PostParentQty;
                        PreReqQty_Next = (ecnAlterInfo.MOQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PreUsageQty / ecnAlter.PostParentQty;
                    }
                    else
                    { 
                        ActualReqQty_Next = (ecnAlterInfo.MOQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty;
                        PreReqQty_Next = (ecnAlterInfo.MOQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PreUsageQty;
                    }
                    //分割订单的备料数量等于 分割后的生产数量除以原生产订单数量
                    ActualReqQty_Pre = ecnAlterInfo.PostUsageQty * mo.ProductQty / ecnAlterInfo.MOQty;
                    //进位取整
                    ActualReqQty_Pre = Convert.ToDecimal(Math.Ceiling(Math.Pow(10, round_precision) * Convert.ToDouble(ActualReqQty_Pre)) / Math.Pow(10, round_precision));

                    ActualReqQty_Next = ecnAlterInfo.PostUsageQty * nextMO.ProductQty / ecnAlterInfo.MOQty;
                    //进位取整
                    ActualReqQty_Next = Convert.ToDecimal(Math.Ceiling(Math.Pow(10, round_precision) * Convert.ToDouble(ActualReqQty_Next)) / Math.Pow(10, round_precision));

                    //分割订单的替换前备料数量等于 分割后的生产数量除以原生产订单数量
                    PreReqQty_Pre = ecnAlterInfo.PreUsageQty * mo.ProductQty / ecnAlterInfo.MOQty;
                    //进位取整
                    PreReqQty_Pre = Convert.ToDecimal(Math.Ceiling(Math.Pow(10, round_precision) * Convert.ToDouble(PreReqQty_Pre)) / Math.Pow(10, round_precision));

                    PreReqQty_Next = ecnAlterInfo.PreUsageQty * nextMO.ProductQty / ecnAlterInfo.MOQty;
                    //进位取整
                    PreReqQty_Next = Convert.ToDecimal(Math.Ceiling(Math.Pow(10, round_precision) * Convert.ToDouble(PreReqQty_Next)) / Math.Pow(10, round_precision));

                    moinfoSplit.PostUsageQty = ActualReqQty_Next;//替换后子件总需求量
                    moInfoPre.PostUsageQty = ActualReqQty_Pre;//原被分割的MO设变的替换后数量

                    moinfoSplit.PreUsageQty = PreReqQty_Next;//替换前子件总需求量
                    moInfoPre.PreUsageQty = PreReqQty_Pre;//原被分割的MO设变的替换前数量
                    break;
                case "del": //删除
                    moinfoSplit.PostUsageQty = 0;//替换后子件总需求量
                    break;
            }
            //被分割后的生产订单数量，连续分割时若原MO的生产数量为0，则造成除数为0的异常。ActualReqQty_Pre = ecnAlterInfo.PostUsageQty * mo.ProductQty / ecnAlterInfo.MOQty;
            //ecnAlterInfo.MOQty = mo.ProductQty;
            moInfoPre.MOQty = mo.ProductQty;//被分割后的生产订单数量
            moInfoPre.IsSplit = "Y";//是否分割
            moinfoSplit.IsSplit = "Y";//是否分割
            return moinfoSplit;
        }

        /// <summary>
        /// 循环遍历MO多级分割的MO
        /// </summary>
        /// <param name="lstCache">必须前期</param>
        /// <param name="moID"></param>
        /// <param name="dtCurrent"></param>
        public void LoopQueryMOSplit(List<UFIDA.U9.MO.MO.MOSplitMergeRelation> lstCache, long moID,DateTime dtCurrent){
            if (lstCache == null)
            {
                throw new Exception("循环遍历MO多级分割时，提供的lstCache不能为空！");
            }

            UFIDA.U9.MO.MO.MOSplitMergeRelation.EntityList lstSplit = UFIDA.U9.MO.MO.MOSplitMergeRelation.Finder.FindAll("PrevMO=@prevMO", new OqlParam[] { new OqlParam(moID) });
            foreach (var itemMOSplit in lstSplit)
            {
                //不是分割方式或生成在本次ECN设变前的分割MO都排除掉
                if (itemMOSplit.SplitMergeType != UFIDA.U9.MO.Enums.MOSplitMergeStyleEnum.Split || itemMOSplit.CreatedOn <= dtCurrent)
                {
                    continue;
                }
                lstCache.Add(itemMOSplit);
                LoopQueryMOSplit(lstCache, itemMOSplit.NextMO.ID, dtCurrent);
            }
        }
    }

    #endregion


}