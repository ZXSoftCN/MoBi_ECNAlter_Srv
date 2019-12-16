namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PLMECNQuerySV;
    using UFSoft.UBF.AopFrame;
    using UFSoft.UBF.Util.Context;
    using UFSoft.UBF.Business;
    using UFSoft.UBF.PL;

    /// <summary>
    /// CreatePLMECN partial 
    /// </summary>	
    public partial class CreatePLMECN
    {
        internal BaseStrategy Select()
        {
            return new CreatePLMECNImpementStrategy();
        }
    }

    #region  implement strategy
    /// <summary>
    /// Impement Implement
    /// 
    /// </summary>	
    internal partial class CreatePLMECNImpementStrategy : BaseStrategy
    {
        public CreatePLMECNImpementStrategy() { }

        public override object Do(object obj)
        {
            CreatePLMECN bpObj = (CreatePLMECN)obj;

            StringBuilder strbResult = new StringBuilder();

            if (string.IsNullOrEmpty(bpObj.ECNAlterRequest))
            {
                //logger.Error(string.Format("创建料品失败：传入参数BOMItemInfo为空。"));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", "传输ECN信息失败：传入参数ECNAlterRequest为空。"));
                return strbResult.ToString();
            }
            ECNAlterRequest ecnAlterRequest = new ECNAlterRequest();
            #region 测试代码
            //ecnAlterRequest.ECNDocNo = "10001";

            //ECNBomMaster ecnBom = new ECNBomMaster();
            //ecnBom.ItemMasterCode = "物料编码";
            //ecnBom.BOMVersionCode = "BOM版本号";
            //ecnBom.BOMType = "BOM种类";



            //ECNBOMComponent ecmCom = new ECNBOMComponent();
            //ecmCom.PreItemCode = "替换前子件物料编码";
            //ecmCom.PreItemVersionCode = "替换前物料版本号";
            //ecmCom.PreIssueUomCode = "替换前单位";
            //ecmCom.PreUsageQty = 1;
            //ecmCom.PreScrap = 1; 
            //ecmCom.PreParentQty = 1; 
            //ecmCom.ECNAction = "add";
            //ecmCom.PostItemCode = "替换后子件物料编码";
            //ecmCom.PostItemVersionCode = "替换后物料版本号";
            //ecmCom.PostIssueUomCode = "替换后单位";
            //ecmCom.PostUsageQty = 1; 
            //ecmCom.PostScrap = 1;
            //ecmCom.PostParentQty = 1;


            //ECNMOInfo ecnmo = new ECNMOInfo();
            //ecnmo.IsAlter = "Y";
            //ecnmo.OrgCode = "组织编号";
            //ecnmo.MONo = "MO单号";
            //ecnmo.MOQty = 1;
            //ecnmo.PrePerUsageQty = 1;
            //ecnmo.PreUsageQty = 1;
            //ecnmo.DiffPerUsageQty = 1;
            //ecnmo.DiffUsageQty = 1;
            //ecnmo.PostPerUsageQty = 1;
            //ecnmo.PostUsageQty = 1;

            //ecmCom.ECNMOInfos = new List<ECNMOInfo>();

            //ecmCom.ECNMOInfos.Add(ecnmo);

            //ecnBom.ECNComponents = new List<ECNBOMComponent>();
            //ecnBom.ECNComponents.Add(ecmCom);

            //ecnAlterRequest.ECNBomMasters = new List<ECNBomMaster>();
            //ecnAlterRequest.ECNBomMasters.Add(ecnBom);


            //strbResult.Append(XmlSerializerHelper.XmlSerialize<ECNAlterRequest>(ecnAlterRequest, Encoding.Unicode));
            #endregion
            try
            {
                ecnAlterRequest = XmlSerializerHelper.XmlDeserialize<ECNAlterRequest>(bpObj.ECNAlterRequest, Encoding.Unicode);
                //cxtInfo = XmlSerializerHelper.XmlDeserialize<ContextInfo>(bpObj.ContextInfo, Encoding.Unicode);
            }
            catch (Exception ex)
            {
                //logger.Error(string.Format("反序列化ItemInfo失败：{0}", bpObj.ItemInfo));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", string.Format("反序列化ECNAlterRequest失败：{0}", bpObj.ECNAlterRequest)));
                return strbResult.ToString();
            }

            if (string.IsNullOrEmpty(ecnAlterRequest.ECNDocNo))
            {
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", "传入的ECNAlterRequest中没有ECNDocNo信息"));
                return strbResult.ToString();
            }

            if (ecnAlterRequest.ECNBomMasters.Count <= 0)
            {
                //logger.Error(string.Format("传入的ItemInfo中没有料品信息"));
                strbResult.AppendLine(string.Format("<ResultInfo Error=\"{0}\" />", "传入的ECNAlterRequest中没有BOM信息"));
                return strbResult.ToString();
            }
            else
            {
                try
                {
                    PLMBE.ECNAlterRequestBE.ECNInfo entityExistsECNInfo = PLMBE.ECNAlterRequestBE.ECNInfo.Finder.Find("ECNDocNo=@DocNo ", new OqlParam[1] { new OqlParam(ecnAlterRequest.ECNDocNo) });
                    //删除原ECNInfo信息，重新生成。
                    if (entityExistsECNInfo != null)
                    {
                        using (ISession session = Session.Open())
                        {
                            entityExistsECNInfo.Remove();
                            session.Commit();
                        }
                    }
                    using (ISession session = Session.Open())
                    {
                        PLMBE.ECNAlterRequestBE.ECNInfo ecnInfo = PLMBE.ECNAlterRequestBE.ECNInfo.Create();
                        ecnInfo.ECNDocNo = ecnAlterRequest.ECNDocNo;
                        foreach (ECNBomMaster bomMaster in ecnAlterRequest.ECNBomMasters)
                        {
                            foreach (ECNBOMComponent bomComponent in bomMaster.ECNComponents)
                            {
                                PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter = PLMBE.ECNAlterRequestBE.ECNAlter.Create(ecnInfo);
                                ecnAlter.ECNDocNo = ecnAlterRequest.ECNDocNo;//ECN单号

                                ecnAlter.ItemMasterCode = bomMaster.ItemMasterCode;//物料编码
                                ecnAlter.BOMVersionCode = bomMaster.BOMVersionCode;//BOM版本号
                                ecnAlter.BOMType = bomMaster.BOMType;//BOM种类
                                ecnAlter.PreItemCode = bomComponent.PreItemCode;//替换前子件物料编码
                                ecnAlter.PreItemVersionCode = bomComponent.PreItemVersionCode;//替换前物料版本号
                                ecnAlter.PreIssueUomCode = bomComponent.PreIssueUomCode;//替换前单位
                                ecnAlter.PreUsageQty = bomComponent.PreUsageQty;//替换前用量
                                ecnAlter.PreScrap = bomComponent.PreScrap;//替换前损耗率
                                ecnAlter.PreParentQty = bomComponent.PreParentQty;//替换前母件底数
                                ecnAlter.ECNAction = bomComponent.ECNAction;//ECN事件
                                ecnAlter.PostItemCode = bomComponent.PostItemCode;//替换后子件物料编码
                                ecnAlter.PostItemVersionCode = bomComponent.PostItemVersionCode;//替换后物料版本号
                                ecnAlter.PostIssueUomCode = bomComponent.PostIssueUomCode;//替换后单位
                                ecnAlter.PostUsageQty = bomComponent.PostUsageQty;//替换后用量
                                ecnAlter.PostScrap = bomComponent.PostScrap;//替换后损耗率
                                ecnAlter.PostParentQty = bomComponent.PostParentQty;//替换后母件底数

                                foreach (ECNMOInfo ecnMOInfo in bomComponent.ECNMOInfos)
                                {
                                    PLMBE.ECNAlterRequestBE.ECNAlterMOInfo ecnAlterMoInfo = PLMBE.ECNAlterRequestBE.ECNAlterMOInfo.Create(ecnAlter);
                                    ecnAlterMoInfo.IsAlter = ecnMOInfo.IsAlter;//是否修改
                                    ecnAlterMoInfo.OrgCode = ecnMOInfo.OrgCode;//组织编号
                                    MO.MO.MO mo = MO.MO.MO.Finder.Find("DocNo=@DocNo and Org.Code = @OrgCode",
                                        new OqlParam[2] { new OqlParam(ecnMOInfo.MONo), new OqlParam(ecnMOInfo.OrgCode) });
                                    ecnAlterMoInfo.MONo = ecnMOInfo.MONo;//MO单号

                                    ecnAlterMoInfo.MOQty = ecnMOInfo.MOQty;//MO订单数量
                                    if (mo != null)
                                        ecnAlterMoInfo.MOTotalRcvQty = mo.TotalRcvQty;
                                    ecnAlterMoInfo.PrePerUsageQty = ecnMOInfo.PrePerUsageQty;//替换前单个子件用量
                                    ecnAlterMoInfo.PreUsageQty = ecnMOInfo.PreUsageQty;//替换前子件总需求量
                                    ecnAlterMoInfo.DiffPerUsageQty = ecnMOInfo.DiffPerUsageQty;//单个变化差量
                                    ecnAlterMoInfo.DiffUsageQty = ecnMOInfo.DiffUsageQty;//变化总差量
                                    ecnAlterMoInfo.PostPerUsageQty = ecnMOInfo.PostPerUsageQty;//替换后单个子件用量
                                    ecnAlterMoInfo.PostUsageQty = ecnMOInfo.PostUsageQty;//替换后子件总需求量
                                    ecnAlterMoInfo.PickListDocLineNo = ecnMOInfo.PickListDocLineNo;//备料行号

                                    MO.MO.MOPickList mopick = MO.MO.MOPickList.Finder.Find("MO.DocNo=@DocNo and MO.Org.Code = @OrgCode and ItemMaster.Code =@ItemMaster and DocLineNO=@LineNo ",
                                        new OqlParam[4] { new OqlParam(ecnMOInfo.MONo), new OqlParam(ecnMOInfo.OrgCode), new OqlParam(bomComponent.PreItemCode), new OqlParam(ecnMOInfo.PickListDocLineNo) });
                                    if (mopick != null)
                                    {
                                        ecnAlterMoInfo.IssuedQty = mopick.IssuedQty;
                                        ecnAlterMoInfo.IsFromPhantomExpanding = mopick.IsFromPhantomExpanding;//是否虚拟件扩展出来
                                    }
                                    else
                                    {
                                        ecnAlterMoInfo.IssuedQty = 0;
                                        ecnAlterMoInfo.IsFromPhantomExpanding = false;
                                    }
                                }
                            }
                        }
                        session.Commit();

                        strbResult.AppendLine(string.Format("<ResultInfo Success=\"{0}\" />", string.Format("U9接收ECN信息成功 U9ECNInfoID:{0}", ecnInfo.ID)));
                    }
                }
                catch (Exception ex)
                {
                    strbResult.AppendLine(string.Format("<ResultInfo Error=\"{0}\" />", ex.Message));
                }
            }

            return strbResult.ToString();
        }
    }

    #endregion


}