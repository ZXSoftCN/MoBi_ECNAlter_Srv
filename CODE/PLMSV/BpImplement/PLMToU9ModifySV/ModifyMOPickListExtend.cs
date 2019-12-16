﻿namespace UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CBO.Pub.Controller;
    using UFSoft.UBF.AopFrame;
    using UFSoft.UBF.Util.Context;
    using UFSoft.UBF.PL;
    using PLMECNQuerySV;
    using UFSoft.UBF.Transactions;
    using UFIDA.U9.CBO.SCM.Item;
    using UFIDA.U9.CBO.MFG.BOM;
    using UFIDA.U9.CBO.MFG.Enums;
    using UFIDA.U9.CBO.Enums;
    using UFIDA.U9.ISV.MFG.BOM;
    using UFIDA.U9.CBO.MFG.CostElement;
    using UFIDA.U9.CBO.SCM.ProjectTask;
    using UFIDA.U9.Base.Organization;
    using UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE;
    using UFSoft.UBF.Business;
    using UFSoft.UBF.Util.Log;

    /// <summary>
    /// ModifyMOPickList partial 
    /// </summary>	
    public partial class ModifyMOPickList
    {
        internal BaseStrategy Select()
        {
            return new ModifyMOPickListImpementStrategy();
        }
    }

    #region  implement strategy
    /// <summary>
    /// Impement Implement
    /// 
    /// </summary>	
    internal partial class ModifyMOPickListImpementStrategy : BaseStrategy
    {
        StringBuilder strbError = new StringBuilder();
        StringBuilder strbSuccess = new StringBuilder();
        private static readonly ILogger logger = LoggerManager.GetLogger(LoggerType.Transaction_Scope);
        const String szOrgCode = "04";//深圳组织编号，常量
        string strErrorItem = "母件：{0}中子件：{1}错误：{2}|";
        //string strInfoItem = "<infoItem code=\"{0}\" />";

        public ModifyMOPickListImpementStrategy() { }

        public override object Do(object obj)
        {
            ModifyMOPickList bpObj = (ModifyMOPickList)obj;

            StringBuilder strbResult = new StringBuilder();

            if (string.IsNullOrEmpty(bpObj.PLMECNInfo))
            {
                //logger.Error(string.Format("创建料品失败：传入参数BOMItemInfo为空。"));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", "传输ECN信息失败：传入参数PLMECNInfo为空。"));
                logger.Error(strbResult.ToString());
                return strbResult.ToString();
            }

            PLMECNInfo plmEcnInfo = new PLMECNInfo();
            try
            {
                plmEcnInfo = XmlSerializerHelper.XmlDeserialize<PLMECNInfo>(bpObj.PLMECNInfo, Encoding.Unicode);
                //cxtInfo = XmlSerializerHelper.XmlDeserialize<ContextInfo>(bpObj.ContextInfo, Encoding.Unicode);
            }
            catch (Exception ex)
            {
                //logger.Error(string.Format("反序列化ItemInfo失败：{0}", bpObj.ItemInfo));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", string.Format("反序列化PLMECNInfo失败：{0}", bpObj.PLMECNInfo)));
                logger.Error(strbResult.ToString());
                return strbResult.ToString();
            }


            string ECNDocNo = plmEcnInfo.ECNDocNo;

            PLMBE.ECNAlterRequestBE.ECNInfo ecnInfo = PLMBE.ECNAlterRequestBE.ECNInfo.Finder.Find("ECNDocNo=@ECNDocNo", new OqlParam[1] { new OqlParam(ECNDocNo) });


            strbResult.Append("<ResultInfo>");
            string BomVerNo = string.Empty;
            if (ecnInfo != null)
            {
                using (UBFTransactionScope scope = new UBFTransactionScope(TransactionOption.Required))
                {
                    try
                    {
                        #region 通过查询接口获取到所有需要修改的MOPickList
                        List<ISV.MO.MOKeyDTOData> mokeylist = new List<ISV.MO.MOKeyDTOData>();
                        foreach (PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter in ecnInfo.ECNAlter)
                        {

                            foreach (PLMBE.ECNAlterRequestBE.ECNAlterMOInfo ecnMoInfo in ecnAlter.ECNAlterMOInfo)
                            {

                                ISV.MO.MOKeyDTOData _mokey = mokeylist.Find(delegate(ISV.MO.MOKeyDTOData _dto) { return (_dto.DocNo == ecnMoInfo.MONo); });
                                if (_mokey == null && ecnMoInfo.IsAlter.ToUpper() == "Y")
                                {
                                    MO.MO.MO mo = MO.MO.MO.Finder.Find("DocNo=@DocNo and Org.Code = @OrgCode", new OqlParam[2] { new OqlParam(ecnMoInfo.MONo), new OqlParam(ecnMoInfo.OrgCode) });
                                    if (mo != null)
                                    {
                                        ISV.MO.MOKeyDTOData mokey = new ISV.MO.MOKeyDTOData();
                                        //mokey.DocNo = ecnMoInfo.MONo;//可能会查出不同组织同一MO单号的记录
                                        mokey.ID = mo.ID;
                                        if (!mokeylist.Exists(delegate(ISV.MO.MOKeyDTOData _dto) { return (_dto.ID == mo.ID); }))
                                        {
                                            mokeylist.Add(mokey);
                                        }
                                    }
                                }
                            }
                        }
                        UFIDA.U9.ISV.MO.Proxy.QueryMO4ExternalProxy qryMo = new ISV.MO.Proxy.QueryMO4ExternalProxy();
                        qryMo.MOKeyDTOs = mokeylist;
                        List<ISV.MO.MODTOData> modtolist = qryMo.Do();
                        #endregion

                        #region 修改MOPickList信息（如果未领料则删除直接用替换后物料生成，如果领用完，则不处理，部分领用取未领用数量生成）

                        List<ISV.MO.MOModifyDTOData> mfymodtolist = new List<ISV.MO.MOModifyDTOData>();
                        foreach (PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter in ecnInfo.ECNAlter)
                        {
                            foreach (PLMBE.ECNAlterRequestBE.ECNAlterMOInfo ecnAlterInfo in ecnAlter.ECNAlterMOInfo)
                            {
                                //备料表若存在虚拟件可能会出现有多条相同料品的备料行，对无须变更的变更备料记录过滤排除
                                if (ecnAlterInfo.IsAlter.ToUpper() == "N")
                                {
                                    continue;
                                }
                                ISV.MO.MODTOData modto = modtolist.Find(delegate(ISV.MO.MODTOData _modto) { return (_modto.DocNo == ecnAlterInfo.MONo && _modto.Org.Code == ecnAlterInfo.OrgCode); });
                                if (modto == null)
                                {
                                    continue;
                                }

                                List<UFIDA.U9.ISV.MO.MOPickListDTOData> pickDTOList = new List<UFIDA.U9.ISV.MO.MOPickListDTOData>();
                                pickDTOList.AddRange(modto.MOPickListDTOs);
                                decimal ActualReqQty = decimal.Zero;

                                MO.MO.MO mo = MO.MO.MO.Finder.Find("DocNo=@DocNo and Org.ID = @OrgId", new OqlParam[2] { new OqlParam(modto.DocNo), new OqlParam(modto.Org.ID) });
                                ISV.MO.MOModifyDTOData mfymodto = new ISV.MO.MOModifyDTOData();
                                mfymodto.MOKeyDTO = new ISV.MO.MOKeyDTOData();
                                //mfymodto.MOKeyDTO.DocNo = modto.DocNo;
                                mfymodto.MOKeyDTO.ID = mo.ID;//使用ID更准确，避免多组织同一单号和只用DocNo会在ModifyMO4External内部使用上下午组织作为默认组织进行查询
                                mfymodto.MODTO = modto;

                                #region (作废，改到QueryPLMECN查询时加入) 处理ECN设变审批时生产订单发生分割造成生产数量减少，对分割后的备料进行按比例分配处理。
                                //if (ecnAlterInfo.MOQty > mo.ProductQty)
                                //{
                                //    UFIDA.U9.MO.MO.MOSplitMergeRelation.EntityList lstSplit = UFIDA.U9.MO.MO.MOSplitMergeRelation.Finder.FindAll("PrevMO=@prevMO", new OqlParam[] { new OqlParam(mo.ID) });
                                //    foreach (var itemMOSplit in lstSplit)
                                //    {
                                //        //不是分割方式或生成在本次ECN设变前的分割MO都排除掉
                                //        if (itemMOSplit.SplitMergeType != UFIDA.U9.MO.Enums.MOSplitMergeStyleEnum.Split || itemMOSplit.CreatedOn <= ecnAlterInfo.CreatedOn)
                                //        {
                                //            continue;
                                //        }
                                //        AddSplitMO(mfymodtolist, ecnAlterInfo, mo, itemMOSplit);
                                //    }
                                //}
                                #endregion

                                //ISV.MO.MOPickListDTOData _pickDTO = pickDTOList.Find(delegate(ISV.MO.MOPickListDTOData _dto) { return (_dto.ItemMaster.Code.ToUpper() == ecnAlter.PreItemCode.ToUpper()); });
                                ISV.MO.MOPickListDTOData _pickDTO = pickDTOList.Find(delegate(ISV.MO.MOPickListDTOData _dto)
                                {
                                    if (_dto.MO == null)
                                    {
                                        //当pickDTOList在当前批次新增了备料行时，对应MO还未保存建立，所以为空。
                                        return false;
                                    }
                                    return (_dto.DocLineNo == ecnAlterInfo.PickListDocLineNo && _dto.MO.ID == mo.ID);
                                });//通过生产订单ID+备料行号，找到所需修改的备料行。在ECNMOQuery中已经排除掉了虚拟备料。

                                MO.MO.MOPickList mopick = MO.MO.MOPickList.Finder.Find("IsPhantomPart = 0 and MO.DocNo=@DocNo and  ItemMaster.Code =@ItemMaster and MO.Org.ID = @OrgId and DocLineNO=@LineNo ",
                                    new OqlParam[4] { new OqlParam(ecnAlterInfo.MONo), new OqlParam(ecnAlter.PreItemCode.ToUpper()), new OqlParam(modto.Org.ID), new OqlParam(ecnAlterInfo.PickListDocLineNo) });
                                //除了add操作时 ，mopick因为PreItemCode为空可以为null。其他情况下（如提交的备料行出现重复行号时）直接continue;
                                if (mopick == null)
                                {
                                    if (!ecnAlter.ECNAction.ToLower().Equals("add"))
                                    {
                                        continue;
                                    }
                                }

                                switch (ecnAlter.ECNAction.ToLower())
                                {
                                    case "add": //新增
                                        if (String.IsNullOrEmpty(ecnAlter.PostItemCode))
                                        {
                                            throw new Exception("变更动作指定为'add新增'时，变更后的料号不允许空！");
                                        }
                                        if (ecnAlter.PostParentQty != 0)
                                            ActualReqQty = (mo.ProductQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty / ecnAlter.PostParentQty;
                                        else
                                            ActualReqQty = (mo.ProductQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty;

                                        CreatePickList(mo.Org, pickDTOList, ecnAlter, ecnAlter.PostItemCode, ActualReqQty);
                                        break;
                                    case "del": //删除

                                        if (_pickDTO != null && _pickDTO.ActualReqQty > _pickDTO.IssuedQty)
                                        {
                                            if (_pickDTO.IssuedQty == 0)
                                            {
                                                //_pickDTO.CUD = 8;  //如果未领料，直接删除该备料行
                                                _pickDTO.CUD = 4;   //如果未领料，就修改实际需求数量为0
                                                _pickDTO.ActualReqQty = 0;
                                            }
                                            else
                                            {
                                                _pickDTO.CUD = 4;   //如果已领料，就修改需求数量
                                                _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                                            }
                                        }
                                        break;
                                    case "qtyadd": //增加
                                    case "qtyreduce": //减少
                                    case "qtyreplace": //替换
                                        if (String.IsNullOrEmpty(ecnAlter.PostItemCode))
                                        {
                                            //标记为“增加”或“减少”时，但变更后物料为空，则认定为该行进行删除处理。
                                            //所以进行数量变更，必须指定PostItemCode（变更后料号）。
                                            if (_pickDTO != null && _pickDTO.ActualReqQty > _pickDTO.IssuedQty)
                                            {
                                                if (_pickDTO.IssuedQty == 0)
                                                {
                                                    //_pickDTO.CUD = 8;  //如果未领料，直接删除该备料行
                                                    _pickDTO.CUD = 4;   //如果未领料，就修改实际需求数量为0
                                                    _pickDTO.ActualReqQty = 0;
                                                }
                                                else
                                                {
                                                    _pickDTO.CUD = 4;   //如果已领料，就修改需求数量
                                                    _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (_pickDTO != null && ecnAlter.PostItemCode.ToUpper() == ecnAlter.PreItemCode.ToUpper())
                                            {
                                                //如果变更生产备料行指定了替换后子件总需求量则直接使用，不再通过变更子件行计算得出
                                                if (ecnAlterInfo.PostUsageQty > 0)
                                                {
                                                    ActualReqQty = ecnAlterInfo.PostUsageQty;
                                                }
                                                else
                                                {
                                                    if (ecnAlter.PostParentQty != 0)
                                                        ActualReqQty = mo.ProductQty * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty / ecnAlter.PostParentQty;
                                                    else
                                                        ActualReqQty = mo.ProductQty * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty;
                                                }
                                                //变更后的实际需求量小于已领数量，则保持实际需求量等于已领数量
                                                if (ActualReqQty < mopick.IssuedQty)
                                                {
                                                    _pickDTO.CUD = 4;   //如果已领料，就修改需求数量
                                                    _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                                                }
                                                else
                                                {
                                                    _pickDTO.CUD = 4;
                                                    _pickDTO.ActualReqQty = ActualReqQty;
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                            #region 变更前后料品不一致的情况。使用删除前料品，新增变更后料品来处理。
                                            //else
                                            //{
                                            //    if (_pickDTO != null && _pickDTO.ActualReqQty > _pickDTO.IssuedQty)
                                            //    {
                                            //        if (_pickDTO.IssuedQty == 0)
                                            //        {
                                            //            _pickDTO.CUD = 8;
                                            //        }
                                            //        else
                                            //        {
                                            //            _pickDTO.CUD = 4;
                                            //            _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                                            //        }
                                            //        //创建新替换的子件
                                            //        #region 原代码
                                            //        //decimal IssMOQty = decimal.Zero;
                                            //        //if (ecnAlter.PreUsageQty != 0)
                                            //        //    IssMOQty = _pickDTO.ActualReqQty - _pickDTO.IssuedQty / ecnAlter.PreUsageQty;
                                            //        //else
                                            //        //    IssMOQty = _pickDTO.ActualReqQty - _pickDTO.IssuedQty;


                                            //        //if (ecnAlter.PostParentQty != 0)
                                            //        //{
                                            //        //    ActualReqQty = IssMOQty * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty / ecnAlter.PostParentQty;
                                            //        //    ActualReqQty = decimal.Floor(ActualReqQty / ecnAlter.PostUsageQty) * ecnAlter.PostUsageQty;
                                            //        //}
                                            //        //else
                                            //        //    ActualReqQty = IssMOQty * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty;
                                            //        #endregion

                                            //        #region 新代码
                                            //        decimal preCompletedQty = decimal.Zero;//由已领数量推算出的可完成母件数量
                                            //        decimal prePerUsageQty = decimal.Zero;//前子件单个用量
                                            //        if (ecnAlter.PreParentQty != 0)
                                            //        {
                                            //            prePerUsageQty = ecnAlter.PreUsageQty / ecnAlter.PreParentQty;
                                            //        }
                                            //        else
                                            //        {
                                            //            prePerUsageQty = ecnAlter.PreUsageQty;
                                            //        }
                                            //        preCompletedQty = decimal.Floor(_pickDTO.IssuedQty / (prePerUsageQty * (1 + ecnAlter.PreScrap)));//已领数量除以单个母件用量取整

                                            //        decimal unCompleteQty = mo.ProductQty - preCompletedQty;//未完成数量
                                            //        decimal postPerUsageQty = decimal.Zero;//替换子件单个用量
                                            //        if (ecnAlter.PostParentQty != 0)
                                            //        {
                                            //            postPerUsageQty = ecnAlter.PostUsageQty / ecnAlter.PostParentQty;
                                            //        }
                                            //        else
                                            //        {
                                            //            postPerUsageQty = ecnAlter.PostUsageQty;
                                            //        }

                                            //        //替换子件可领用数量：未完成数量*单个替换子件用量。
                                            //        ActualReqQty = decimal.Ceiling(unCompleteQty * (postPerUsageQty * (1 + ecnAlter.PostScrap)));
                                            //        #endregion

                                            //        CreatePickList(pickDTOList, ecnAlter, ecnAlter.PostItemCode.ToUpper(), ActualReqQty);
                                            //    }
                                            //}
                                            #endregion
                                        }
                                        break;
                                }
                                modto.MOPickListDTOs = pickDTOList;
                                if (!mfymodtolist.Exists(delegate(ISV.MO.MOModifyDTOData _modto)
                                {
                                    return (_modto.MOKeyDTO.ID == mfymodto.MOKeyDTO.ID);
                                }))
                                {
                                    mfymodtolist.Add(mfymodto);
                                }
                            }
                        }

                        try
                        {
                            UFIDA.U9.ISV.MO.Proxy.ModifyMO4ExternalProxy mfymo = new ISV.MO.Proxy.ModifyMO4ExternalProxy();
                            mfymo.MOModifyDTOs = mfymodtolist;
                            bool bRlt = mfymo.Do();
                            if (bRlt)
                            {
                                strbResult.Append(string.Format("<Message Success=\"{0}\" />", "备料表更新成功"));
                            }
                            else
                            {
                                throw new Exception("备料表更新失败！");
                            }


                        }
                        catch (Exception e)
                        {
                            strbResult.Append(string.Format("<Message Error=\"{0}\" />", e.Message));
                            logger.Error(strbResult.ToString());
                            return strbResult.ToString();
                        }

                        #endregion

                        #region 永久性修改BOM作废，使用一期PLM对照U9的流程处理
                        //if (!String.IsNullOrEmpty(plmEcnInfo.ActionType) && plmEcnInfo.ActionType == "0")
                        //{
                        //    #region 创建新BOM版本
                        //    ISV.MFG.BOM.QueryDelParamsDTOData qryBomDto = new ISV.MFG.BOM.QueryDelParamsDTOData();
                        //    qryBomDto.BOMVersionCode = ecnInfo.ECNAlter[0].BOMVersionCode;
                        //    qryBomDto.BOMType = ecnInfo.ECNAlter[0].BOMType == "0" ? 0 : 1;
                        //    UFIDA.U9.CBO.SCM.Item.ItemMaster item = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.Code=@Org and Code =@Code", new OqlParam[2] { new OqlParam(szOrgCode), new OqlParam(ecnInfo.ECNAlter[0].ItemMasterCode) });

                        //    qryBomDto.ItemMaster = new CommonArchiveDataDTOData();
                        //    if (item != null)
                        //        qryBomDto.ItemMaster.ID = item.ID;
                        //    else
                        //        throw new Exception("深圳组织中未找到料号:[" + ecnInfo.ECNAlter[0].ItemMasterCode + "]");
                        //    qryBomDto.Org = new CommonArchiveDataDTOData();
                        //    qryBomDto.Org.Code = szOrgCode;//非深圳组织移除。只生成到深圳组织，再由下发功能自动更新到其它组织。


                        //    ISV.MFG.BOM.Proxy.QueryBOMSvProxy qryBom = new ISV.MFG.BOM.Proxy.QueryBOMSvProxy();
                        //    qryBom.QryParams = new List<ISV.MFG.BOM.QueryDelParamsDTOData>();
                        //    qryBom.QryParams.Add(qryBomDto);
                        //    List<ISV.MFG.BOM.BOMMasterDTO4CreateSvData> BomDtolist = qryBom.Do();

                        //    List<ISV.MFG.BOM.BOMMasterDTO4CreateSvData> craeteBomDtolist = new List<ISV.MFG.BOM.BOMMasterDTO4CreateSvData>();

                        //    Organization beOrgContext = Organization.FindByCode(szOrgCode);//深圳组织

                        //    foreach (ISV.MFG.BOM.BOMMasterDTO4CreateSvData bomDto in BomDtolist)
                        //    {
                        //        BOMMasterDTO4CreateSvData bomDtoExchange = CreateBOMMasterDTO(bomDto, beOrgContext);
                        //        if (bomDtoExchange == null)
                        //        {
                        //            throw new Exception(strbError.ToString());
                        //        }

                        //        List<ISV.MFG.BOM.BOMComponentDTO4CreateSvData> bomCompDtoList = new List<ISV.MFG.BOM.BOMComponentDTO4CreateSvData>();
                        //        bomCompDtoList.AddRange(bomDto.BOMComponents);

                        //        foreach (PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter in ecnInfo.ECNAlter)
                        //        {
                        //            ISV.MFG.BOM.BOMComponentDTO4CreateSvData bomCompDtoOld = bomCompDtoList.Find(delegate(ISV.MFG.BOM.BOMComponentDTO4CreateSvData _dto) { return (_dto.ItemMaster.Code == ecnAlter.PreItemCode); });
                        //            //新创建子件
                        //            ISV.MFG.BOM.BOMComponentDTO4CreateSvData bomCompDtoNew = null;

                        //            #region 原代码
                        //            //ISV.MFG.BOM.BOMComponentDTO4CreateSvData bomCompDto = new ISV.MFG.BOM.BOMComponentDTO4CreateSvData();

                        //            //bomCompDtoNew.ItemMaster = new CommonArchiveDataDTOData();

                        //            //UFIDA.U9.CBO.SCM.Item.ItemMaster _item = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.Code=@Org and Code =@Code", new OqlParam[2] { new OqlParam("04"), new OqlParam(ecnAlter.PostItemCode) });
                        //            //if (_item != null)
                        //            //    bomCompDtoNew.ItemMaster.ID = _item.ID;
                        //            //bomCompDtoNew.ComponentType = 0;
                        //            //bomCompDtoNew.OperationNum = "10";
                        //            //bomCompDtoNew.UsageQtyType = 1;
                        //            //bomCompDtoNew.UsageQty = ecnAlter.PostUsageQty;
                        //            //bomCompDtoNew.ParentQty = ecnAlter.PostParentQty;
                        //            //bomCompDtoNew.ScrapType = 0;
                        //            //bomCompDtoNew.IssueStyle = 0;
                        //            //bomCompDtoNew.SupplyStyle = 0;
                        //            //bomCompDtoNew.TimeUOM = new CommonArchiveDataDTOData();
                        //            //bomCompDtoNew.TimeUOM.Code = "DAY";
                        //            //bomCompDtoNew.SubstituteStyle = 0;
                        //            //// bomCompDto.issueOrg = new UFIDAU9CBOPubControllerCommonArchiveDataDTOData();
                        //            //// bomCompDto.issueOrg.m_iD = 1001007094250320;
                        //            //bomCompDtoNew.LeadTimeOffSet = 0;
                        //            ////bomCompDto.CostElement = new CommonArchiveDataDTOData();
                        //            ////bomCompDto.CostElement.Code = "No1";
                        //            //bomCompDtoNew.SubcontractItemSrc = -1;
                        //            //bomCompDtoNew.ConsignProcessItemSrc = 2;
                        //            //bomCompDtoNew.IsCharge = true;
                        //            //bomCompDtoNew.CostPercent = 0;
                        //            //bomCompDtoNew.IsEffective = true;
                        //            #endregion

                        //            switch (ecnAlter.ECNAction.ToLower())
                        //            {
                        //                case "add": //新增
                        //                    //新创建子件
                        //                    bomCompDtoNew = CreateBOMComponentDTO(bomDto, ecnAlter);
                        //                    bomCompDtoList.Add(bomCompDtoNew);
                        //                    break;
                        //                case "del": //删除
                        //                    bomCompDtoList.Remove(bomCompDtoOld);
                        //                    break;
                        //                case "qtyadd": //增加
                        //                case "qtyreduce": //减少
                        //                    if (!String.IsNullOrEmpty(ecnAlter.PostItemCode))
                        //                    {
                        //                        if (ecnAlter.PostItemCode.ToUpper() == ecnAlter.PreItemCode.ToUpper())
                        //                        {
                        //                            bomCompDtoOld.UsageQty = ecnAlter.PostUsageQty;
                        //                            bomCompDtoOld.ParentQty = ecnAlter.PostParentQty;
                        //                        }
                        //                        else
                        //                        {
                        //                            //新创建子件
                        //                            bomCompDtoNew = CreateBOMComponentDTO(bomDto, ecnAlter);
                        //                            bomCompDtoList.Remove(bomCompDtoOld);
                        //                            bomCompDtoList.Add(bomCompDtoNew);
                        //                        }
                        //                    }
                        //                    break;
                        //            }
                        //        }

                        //        bomDtoExchange.BOMComponents = bomCompDtoList;
                        //        craeteBomDtolist.Add(bomDtoExchange);
                        //    }
                        //    if (strbError.Length > 0)
                        //    {
                        //        throw new Exception(strbError.ToString());
                        //    }

                        //    ISV.MFG.BOM.Proxy.CreateBOMSvProxy creacteBom = new ISV.MFG.BOM.Proxy.CreateBOMSvProxy();
                        //    ContextDTOData dtoContext = new ContextDTOData();
                        //    dtoContext.CultureName = "zh-CN";// "zh-CN";
                        //    dtoContext.UserCode = "PLM";//默认：系统管理员admin
                        //    dtoContext.EntCode = "1";// "";//测试默认公司：.正式使用请根据需要指定。
                        //    dtoContext.OrgCode = szOrgCode;//
                        //    creacteBom.ContextDTO = dtoContext;

                        //    creacteBom.BOMMasterDTOList = craeteBomDtolist;
                        //    List<LogDTO4CreateSvData> lstRltBOM = creacteBom.Do();
                        //    //创建服务返回结果数为0，也认定为执行失败，回滚。
                        //    if (lstRltBOM.Count > 0)
                        //    {
                        //        strbResult.Append(string.Format("<Message Success=\"{0}\" BOMVersionCode=\"{1}\" />", "BOM新版本创建成功", BomVerNo));
                        //    }
                        //    else
                        //    {
                        //        throw new Exception(String.Format("创建料品{0}，BOM版本号{1}失败。", ecnInfo.ECNAlter[0].ItemMasterCode, BomVerNo));
                        //    }
                        //    #endregion

                        //}
                        #endregion
                        #region  测试更新备料表
                        //List<ISV.MO.MOKeyDTOData> mokeylist = new List<ISV.MO.MOKeyDTOData>();

                        //ISV.MO.MOKeyDTOData mokey = new ISV.MO.MOKeyDTOData();
                        //mokey.DocNo = bpObj.PLMECNInfo;
                        //mokeylist.Add(mokey);

                        //#region 先查询MO信息
                        //UFIDA.U9.ISV.MO.Proxy.QueryMO4ExternalProxy qryMo = new ISV.MO.Proxy.QueryMO4ExternalProxy();
                        //qryMo.MOKeyDTOs = mokeylist;
                        //List<ISV.MO.MODTOData> modtolist = qryMo.Do();
                        //#endregion


                        //List<ISV.MO.MOModifyDTOData> mfymodtolist = new List<ISV.MO.MOModifyDTOData>();

                        //ISV.MO.MOModifyDTOData mfymodto = new ISV.MO.MOModifyDTOData();

                        //mfymodto.MODTO = modtolist[0];
                        //mfymodto.MOKeyDTO = mokey;


                        //List<UFIDA.U9.ISV.MO.MOPickListDTOData> pickDTOList = new List<UFIDA.U9.ISV.MO.MOPickListDTOData>();
                        //pickDTOList.AddRange(modtolist[0].MOPickListDTOs);

                        //UFIDA.U9.ISV.MO.MOPickListDTOData pickDTO = new ISV.MO.MOPickListDTOData();
                        //pickDTOList.Add(pickDTO);




                        //ISV.MO.MOPickListDTOData _pickDTO = pickDTOList.Find(delegate (ISV.MO.MOPickListDTOData _dto) { return (_dto.ItemMaster.Code == "005.01.0.0033"); });

                        //if (_pickDTO != null && _pickDTO.ActualReqQty > _pickDTO.IssuedQty)
                        //{
                        //    if (_pickDTO.IssuedQty == 0)
                        //    {
                        //        _pickDTO.CUD = 8;
                        //    }
                        //    else
                        //    {
                        //        _pickDTO.CUD = 4;
                        //        _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                        //    }

                        //}


                        //modtolist[0].MOPickListDTOs = pickDTOList;


                        //pickDTO.CUD = 2;
                        //pickDTO.OperationNum = "10";
                        //pickDTO.ItemMaster = new CommonArchiveDataDTOData();
                        //pickDTO.ItemMaster.Code = "005.01.0.0026";
                        //pickDTO.ActualReqQty = 1.0001m;
                        //pickDTO.FromElement = -1;
                        //pickDTO.FromGrade = -1;
                        //pickDTO.ToElement = -1;
                        //pickDTO.ToGrade = -1;
                        //pickDTO.TransferStyle = -1;


                        //mfymodtolist.Add(mfymodto);


                        //UFIDA.U9.ISV.MO.Proxy.ModifyMO4ExternalProxy mfymo = new ISV.MO.Proxy.ModifyMO4ExternalProxy();
                        //mfymo.MOModifyDTOs = mfymodtolist;
                        //mfymo.Do();
                        #endregion
                        scope.Commit();
                    }
                    catch (Exception e)
                    {
                        strbResult.AppendFormat(string.Format("<Message Error=\"{0}\" />", e.Message));
                        logger.Error(strbResult.ToString());
                        scope.Rollback();
                    }
                }
            }
            else
            {
                strbResult.AppendFormat(string.Format("<Message Error=\"{0}\" />", string.Format("ECNDocNo：{0}未找到U9记录", ECNDocNo)));
                logger.Error(strbResult.ToString());
                return strbResult.ToString();
            }

            strbResult.Append("</ResultInfo>");
            return strbResult.ToString();
        }

        public void CreatePickList(Organization org, List<UFIDA.U9.ISV.MO.MOPickListDTOData> pickDTOList, PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter, string ItemCode, decimal ActualReqQty)
        {

            UFIDA.U9.ISV.MO.MOPickListDTOData pickDTO = new ISV.MO.MOPickListDTOData();
            pickDTOList.Add(pickDTO);

            pickDTO.CUD = 2;
            pickDTO.OperationNum = "10";
            UFIDA.U9.CBO.SCM.Item.ItemMaster item = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.ID=@Org and Code =@Code",
                new OqlParam[2] { new OqlParam(org.ID.ToString()), new OqlParam(ecnAlter.PostItemCode) });

            pickDTO.ItemMaster = new CommonArchiveDataDTOData();

            //pickDTO.ItemMaster.Code = ecnAlter.PostItemCode.ToUpper();//会生成当前上下文组织下的料号，而不是对应MO组织下的料号。

            if (item == null)
            {
                throw new Exception(string.Format("组织【{0}】下没有料号【{1}】，无法新增备料行！", org.Name, ecnAlter.PostItemCode));
            }
            pickDTO.ItemMaster.ID = item.ID;

            pickDTO.BOMReqQty = 0;
            pickDTO.ActualReqQty = ActualReqQty;
            //pickDTO.ActualReqDate = pickDTOList[0].ActualReqDate;//实际需求日期，按备料表中第一个子件的需求日期默认。
            //pickDTO.PlanReqDate = pickDTOList[0].PlanReqDate;//计划需求日期

            pickDTO.FromElement = -1;
            pickDTO.FromGrade = -1;
            pickDTO.ToElement = -1;
            pickDTO.ToGrade = -1;
            pickDTO.TransferStyle = -1;

            pickDTO.IsCalcCost = true;//计算成本
            pickDTO.ActualReqDate = DateTime.Now.Date;//实际需求日期
            //pickDTO.ActualReqDate = pickDTOList[0].ActualReqDate;//实际需求日期，按备料表中第一个子件的需求日期默认。
            //pickDTO.PlanReqDate = pickDTOList[0].PlanReqDate;//计划需求日期
            pickDTO.QtyType = 1;
            pickDTO.SubcItemSrcType = -1;
            pickDTO.IsSCV = true;
            pickDTO.ConsignProcessItemSrc = 2;
            if (!string.IsNullOrEmpty(item.VersionID.ToString()))
            {
                pickDTO.ItemVersion = new CommonArchiveDataDTOData();
                pickDTO.ItemVersion.ID = item.VersionID;
            }
            //pickDTO.MaterialType //无法赋值，同手工加入的备料记录不同。超额类型
            //pickDTO.GroupQtyType //无法赋值，同手工加入的备料记录不同。成组用量类型

        }

        public void AddSplitMO(List<ISV.MO.MOModifyDTOData> mfymodtolist,PLMBE.ECNAlterRequestBE.ECNAlterMOInfo ecnAlterInfo, MO.MO.MO mo,UFIDA.U9.MO.MO.MOSplitMergeRelation moSplitRelation)
        {
            PLMBE.ECNAlterRequestBE.ECNAlter ecnAlter = ecnAlterInfo.ECNAlter;
            MO.MO.MO nextMO = moSplitRelation.NextMO;

            List<ISV.MO.MOKeyDTOData> mokeylist_Split = new List<ISV.MO.MOKeyDTOData>();
            ISV.MO.MOKeyDTOData mokey_Split = new ISV.MO.MOKeyDTOData();
            mokey_Split.ID = nextMO.ID;
            mokeylist_Split.Add(mokey_Split);

            UFIDA.U9.ISV.MO.Proxy.QueryMO4ExternalProxy qryMo_Split = new ISV.MO.Proxy.QueryMO4ExternalProxy();
            qryMo_Split.MOKeyDTOs = mokeylist_Split;
            List<ISV.MO.MODTOData> modtolist_Split = qryMo_Split.Do();

            ISV.MO.MODTOData modto_Split = modtolist_Split.Find(delegate(ISV.MO.MODTOData _modto) { return (_modto.DocNo == nextMO.DocNo && _modto.Org.Code == nextMO.Org.Code); });
            if (modto_Split == null)
            {
                throw new Exception(string.Format("组织--{0}的生产订单：{1}下的分割订单：{2}设变失败！",mo.Org.Name,mo.DocNo,nextMO.DocNo));
            }
            ISV.MO.MOModifyDTOData mfymodto = new ISV.MO.MOModifyDTOData();
            mfymodto.MOKeyDTO = new ISV.MO.MOKeyDTOData();
            //mfymodto.MOKeyDTO.DocNo = modto.DocNo;
            mfymodto.MOKeyDTO.ID = nextMO.ID;//使用ID更准确，避免多组织同一单号和只用DocNo会在ModifyMO4External内部使用上下午组织作为默认组织进行查询
            mfymodto.MODTO = modto_Split;

            List<UFIDA.U9.ISV.MO.MOPickListDTOData> pickDTOList_Split = new List<UFIDA.U9.ISV.MO.MOPickListDTOData>();
            pickDTOList_Split.AddRange(modto_Split.MOPickListDTOs);

            ISV.MO.MOPickListDTOData _pickDTO = pickDTOList_Split.Find(delegate(ISV.MO.MOPickListDTOData _dto)
            {
                if (_dto.MO == null)
                {
                    //当pickDTOList在当前批次新增了备料行时，对应MO还未保存建立，所以为空。
                    return false;
                }
                return (_dto.DocLineNo == ecnAlterInfo.PickListDocLineNo && _dto.MO.ID == nextMO.ID);
            });//通过生产订单ID+备料行号，找到所需修改的备料行。在ECNMOQuery中已经排除掉了虚拟备料。

            MO.MO.MOPickList mopick_Split = MO.MO.MOPickList.Finder.Find("IsPhantomPart = 0 and MO.DocNo=@DocNo and  ItemMaster.Code =@ItemMaster and MO.Org.ID = @OrgId and DocLineNO=@LineNo ",
                new OqlParam[4] { new OqlParam(nextMO.DocNo), new OqlParam(ecnAlter.PreItemCode.ToUpper()), new OqlParam(nextMO.Org.ID), new OqlParam(ecnAlterInfo.PickListDocLineNo) });
            //除了add操作时 ，mopick因为PreItemCode为空可以为null。其他情况下（如提交的备料行出现重复行号时）直接continue;
            if (mopick_Split == null)
            {
                if (!ecnAlter.ECNAction.ToLower().Equals("add"))
                {
                    return;
                }
            }

            decimal ActualReqQty = decimal.Zero;
            switch (ecnAlter.ECNAction.ToLower())
            {
                case "add": //新增
                    if (String.IsNullOrEmpty(ecnAlter.PostItemCode))
                    {
                        throw new Exception("变更动作指定为'add新增'时，变更后的料号不允许空！");
                    }
                    //从mo.ProductQty改为设变发起时的生产数量
                    if (ecnAlter.PostParentQty != 0)
                        ActualReqQty = (ecnAlterInfo.MOQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty / ecnAlter.PostParentQty;
                    else
                        ActualReqQty = (ecnAlterInfo.MOQty - mo.TotalCompleteQty) * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty;

                    ActualReqQty = Math.Round(ActualReqQty * nextMO.ProductQty / ecnAlterInfo.MOQty,0);//分割订单的备料数量等于 分割后的生产数量除以原生产订单数量
                    CreatePickList(mo.Org, pickDTOList_Split, ecnAlter, ecnAlter.PostItemCode, ActualReqQty);
                    break;
                case "del": //删除
                    if (_pickDTO != null && _pickDTO.ActualReqQty > _pickDTO.IssuedQty)
                    {
                        if (_pickDTO.IssuedQty == 0)
                        {
                            //_pickDTO.CUD = 8;  //如果未领料，直接删除该备料行
                            _pickDTO.CUD = 4;   //如果未领料，就修改实际需求数量为0
                            _pickDTO.ActualReqQty = 0;
                        }
                        else
                        {
                            _pickDTO.CUD = 4;   //如果已领料，就修改需求数量
                            _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                        }
                    }
                    break;
                case "qtyadd": //增加
                case "qtyreduce": //减少
                case "qtyreplace": //替换
                    if (String.IsNullOrEmpty(ecnAlter.PostItemCode))
                    {
                        //标记为“增加”或“减少”时，但变更后物料为空，则认定为该行进行删除处理。
                        //所以进行数量变更，必须指定PostItemCode（变更后料号）。
                        if (_pickDTO != null && _pickDTO.ActualReqQty > _pickDTO.IssuedQty)
                        {
                            if (_pickDTO.IssuedQty == 0)
                            {
                                //_pickDTO.CUD = 8;  //如果未领料，直接删除该备料行
                                _pickDTO.CUD = 4;   //如果未领料，就修改实际需求数量为0
                                _pickDTO.ActualReqQty = 0;
                            }
                            else
                            {
                                _pickDTO.CUD = 4;   //如果已领料，就修改需求数量
                                _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                            }
                        }
                    }
                    else
                    {
                        if (_pickDTO != null && ecnAlter.PostItemCode.ToUpper() == ecnAlter.PreItemCode.ToUpper())
                        {
                            //如果变更生产备料行指定了替换后子件总需求量则直接使用，不再通过变更子件行计算得出
                            if (ecnAlterInfo.PostUsageQty > 0)
                            {
                                ActualReqQty = ecnAlterInfo.PostUsageQty;
                            }
                            else
                            {
                                if (ecnAlter.PostParentQty != 0)
                                    ActualReqQty = ecnAlterInfo.MOQty * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty / ecnAlter.PostParentQty;
                                else
                                    ActualReqQty = ecnAlterInfo.MOQty * (1 + ecnAlter.PostScrap) * ecnAlter.PostUsageQty;
                            }

                            ActualReqQty = Math.Round(ActualReqQty * nextMO.ProductQty / ecnAlterInfo.MOQty,0);//分割订单的备料数量等于 分割后的生产数量除以原生产订单数量

                            //变更后的实际需求量小于已领数量，则保持实际需求量等于已领数量
                            if (ActualReqQty < mopick_Split.IssuedQty)
                            {
                                _pickDTO.CUD = 4;   //如果已领料，就修改需求数量
                                _pickDTO.ActualReqQty = _pickDTO.IssuedQty;
                            }
                            else
                            {
                                _pickDTO.CUD = 4;
                                _pickDTO.ActualReqQty = ActualReqQty;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
            }
            modto_Split.MOPickListDTOs = pickDTOList_Split;
            if (!mfymodtolist.Exists(delegate(ISV.MO.MOModifyDTOData _modto)
            {
                return (_modto.MOKeyDTO.ID == mfymodto.MOKeyDTO.ID);
            }))
            {
                mfymodtolist.Add(mfymodto);
            }
        }

        /// <summary>
        /// 创建新增BOM服务的DTO
        /// </summary>
        /// <param name="_bom"></param>
        /// <returns></returns>
        private BOMMasterDTO4CreateSvData CreateBOMMasterDTO(ISV.MFG.BOM.BOMMasterDTO4CreateSvData _bomDto, Organization _beOrgContext)
        {
            BOMMasterDTO4CreateSvData dtoMaster = new BOMMasterDTO4CreateSvData();
            try
            {
                if (string.IsNullOrEmpty(_bomDto.ItemMaster.Code))
                {
                    throw new Exception("母件料号编码传入为空字符串。");
                }
                ItemMaster beItemMaster = ItemMaster.Finder.Find("Id=@id",
                    new OqlParam[] { new OqlParam(_bomDto.ItemMaster.ID) });
                if (beItemMaster == null)
                {
                    throw new Exception(string.Format("母件料号{0}不存在！", _bomDto.ItemMaster.Code));
                }
                #region 检查历史BOM上版本的生效、失效日期。不允许同一天内两次版本升级。
                OqlParamList lstParam = new OqlParamList();
                string opath = " Org=@org and ItemMaster=@item and BOMType=@bomType ";
                lstParam.Add(new OqlParam(_beOrgContext.ID));
                lstParam.Add(new OqlParam(beItemMaster.ID));
                lstParam.Add(new OqlParam(_bomDto.BOMType));

                UFIDA.U9.CBO.MFG.BOM.BOMMaster.EntityList lstBomOld = new UFIDA.U9.CBO.MFG.BOM.BOMMaster.EntityList();

                lstBomOld = UFIDA.U9.CBO.MFG.BOM.BOMMaster.Finder.FindAll(opath, lstParam.ToArray());
                foreach (var itemOldBom in lstBomOld)
                {
                    if (itemOldBom.EffectiveDate.Date == DateTime.Now.Date)
                    {
                        throw new Exception(string.Format("BOM母件{0}在{1}有版本{2}不允许同一天叠加版本升级。",
                            _bomDto.ItemMaster.Code, DateTime.Today.ToShortDateString(), itemOldBom.BOMVersionCode));
                    }
                }
                #endregion

                #region 检查是否存在当前版本的料品，如果存在，则修改生效日期为当前日期。（对应修改上一版本的失效日期为当前日期减一），
                string BomVerNo = string.Empty;
                string x = _bomDto.BOMVersionCode;
                string a = "";
                string b = "";

                //对V3.0 会生成V.31异常数据 =>V.31
                //for (int i = 0; i < x.Length; i++)
                //{
                //    try
                //    {

                //        b += Convert.ToInt32(x.Substring(i, 1));
                //    }
                //    catch
                //    {
                //        a += x.Substring(i, 1);

                //    }
                //}
                a = x.Substring(0, 1);//直接
                b = x.Substring(1);

                BomVerNo = a + (Convert.ToDecimal(b) + 1);
                if (ExistsBOMVersionCode(szOrgCode, _bomDto.ItemMaster.ID.ToString(), _bomDto.BOMType, BomVerNo))
                {
                    throw new Exception(String.Format("提供的母件{0}的BOM版本不是最新版本。", _bomDto.BOMVersionCode));
                }

                #region 修改料品版本号
                dtoMaster.BOMVersionCode = BomVerNo;
                dtoMaster.EffectiveDate = DateTime.Now;
                dtoMaster.DisableDate = DateTime.MaxValue;
                //失效日期改为当前BOM版本的失效日期，即最大日期。
                //if (beItemMaster != null && beItemMaster.ItemMasterVersions != null && beItemMaster.ItemMasterVersions.Count > 0)
                //{
                //    bool isExists = false;
                //    foreach (var itemVersion in beItemMaster.ItemMasterVersions)
                //    {
                //        if (string.Equals(itemVersion.Version, BomVerNo))
                //        {

                //            if (DateTime.Compare(itemVersion.Effective.EffectiveDate, DateTime.Now.Date) != 0)
                //            {
                //                isExists = true;
                //                using (ISession session2 = Session.Open())
                //                {
                //                    ItemMasterVersion itemFormer = getFormerItemMasterVersion(beItemMaster, itemVersion);
                //                    if (itemFormer != null)
                //                    {
                //                        itemFormer.Effective.DisableDate = DateTime.Now.Date.AddDays(-1);//修改上一料品版本。不考虑生效日期与失效日期同一天的情况。
                //                        session2.InList(itemFormer);
                //                    }
                //                    itemVersion.Effective.EffectiveDate = DateTime.Now.Date;
                //                    itemVersion.Effective.DisableDate = DateTime.MaxValue.Date;
                //                    session2.InList(itemVersion);
                //                    session2.Commit();
                //                }
                //            }
                //        }
                //    }
                //    if (!isExists)
                //    {
                //        using (ISession session2 = Session.Open())
                //        {
                //            if (beItemMaster.ItemMasterVersions.Count > 0)
                //            {
                //                beItemMaster.ItemMasterVersions[beItemMaster.ItemMasterVersions.Count - 1].Effective.DisableDate = DateTime.Now.AddDays(-1);
                //            }
                //            ItemMasterVersion version = ItemMasterVersion.Create(beItemMaster);
                //            version.Version = BomVerNo;
                //            version.ECNDate = DateTime.Now.Date;
                //            version.Effective.EffectiveDate = DateTime.Now.Date;
                //            version.Effective.IsEffective = true;
                //            version.Effective.DisableDate = DateTime.MaxValue.Date;
                //            session2.Modify(beItemMaster);
                //            session2.Commit();
                //        }
                //    }
                //}
                #endregion
                #endregion

                dtoMaster.Org = new CommonArchiveDataDTOData();
                dtoMaster.Org.ID = _beOrgContext.ID;
                dtoMaster.Org.Code = _beOrgContext.Code;
                dtoMaster.Org.Name = _beOrgContext.Name;

                //不启用货主组织
                //dtoMaster.OwnerOrg = new CommonArchiveDataDTO();
                //dtoMaster.OwnerOrg.ID = beOrg.ID;
                //dtoMaster.OwnerOrg.Code = beOrg.Code;
                //dtoMaster.OwnerOrg.Name = beOrg.Name;

                dtoMaster.ItemMaster = new CommonArchiveDataDTOData();
                dtoMaster.ItemMaster.ID = beItemMaster.ID;
                dtoMaster.ItemMaster.Code = beItemMaster.Code;
                dtoMaster.ItemMaster.Name = beItemMaster.Name;

                dtoMaster.BOMVersionCode = BomVerNo;//新建立
                dtoMaster.AlternateType = _bomDto.AlternateType;
                dtoMaster.Lot = _bomDto.Lot;
                dtoMaster.ProductUOM = _bomDto.ProductUOM;
                dtoMaster.EffectiveDate = DateTime.Now.Date;
                dtoMaster.DisableDate = DateTime.MaxValue;
                dtoMaster.FromQty = 0;
                dtoMaster.ToQty = 0;
                dtoMaster.IsPrimaryLot = true;
                dtoMaster.Explain = String.Empty;
                dtoMaster.BOMType = _bomDto.BOMType;
                //成本卷积IsCostRoll 在接口DTO中未提供
                dtoMaster.Status = MFGDocStatusEnum.Approved.Value;//已核准

            }
            catch (Exception ex)
            {
                strbError.AppendLine(string.Format(strErrorItem, _bomDto.ItemMaster.Code, "", ex.Message));
                dtoMaster = null;
            }
            return dtoMaster;
        }


        /// <summary>
        /// 新创建子件
        /// </summary>
        /// <param name="_dtoBom">原BOM母件DTO</param>
        /// <param name="_ecnAlter">变更子件记录</param>
        /// <returns></returns>
        private ISV.MFG.BOM.BOMComponentDTO4CreateSvData CreateBOMComponentDTO(ISV.MFG.BOM.BOMMasterDTO4CreateSvData _dtoBom, ECNAlter _ecnAlter)
        {
            try
            {
                ISV.MFG.BOM.BOMComponentDTO4CreateSvData dtoComponent = new ISV.MFG.BOM.BOMComponentDTO4CreateSvData();
                //UFIDA.U9.CBO.SCM.Item.ItemMaster _item = UFIDA.U9.CBO.SCM.Item.ItemMaster.Finder.Find("Org.Code=@Org and Code =@Code", new OqlParam[2] { new OqlParam(szOrgCode), new OqlParam(_ecnAlter.PostItemCode) });

                //dtoComponent.Sequence = _iSeq;
                dtoComponent.OperationNum = "10";//默认工序号：空
                ItemMaster beItemComponent = ItemMaster.Finder.Find("Code=@code and Org.Code=@org",
                new OqlParam[] { new OqlParam(_ecnAlter.PostItemCode), new OqlParam(szOrgCode) });
                if (beItemComponent == null)
                {
                    throw new Exception(string.Format("子件料号{0}在组织{1}下不存在！", _ecnAlter.PostItemCode, szOrgCode));
                }

                dtoComponent.ItemMaster = new CommonArchiveDataDTOData();
                dtoComponent.ItemMaster.ID = beItemComponent.ID;
                dtoComponent.ItemMaster.Code = beItemComponent.Code;
                dtoComponent.ItemMaster.Name = beItemComponent.Name;
                //子项物料启用了版本管理
                if (beItemComponent.ItemMasterVersions != null && beItemComponent.ItemMasterVersions.Count > 0)
                {
                    //获取最新的料品版本号
                    ItemMasterVersion lastestVersion = beItemComponent.ItemMasterVersions[0];
                    foreach (var innerVersion in beItemComponent.ItemMasterVersions)
                    {
                        if (String.Compare(innerVersion.Version, lastestVersion.Version, true) > 0)
                        {
                            lastestVersion = innerVersion;
                        }
                    }
                    dtoComponent.ItemVersionCode = lastestVersion.Version;
                }

                dtoComponent.ComponentType = ComponentTypeEnum.StandardComp.Value;//标准

                dtoComponent.BOMCompSubstituteDTO4CreateSv = new List<BOMComponentDTO4CreateSvData>();
                dtoComponent.SubstituteStyle = SubstituteStyleEnum.None.Value;
                dtoComponent.ScrapType = ScrapTypeEnum.SingleScrap.Value;
                dtoComponent.FixedScrap = beItemComponent.MfgInfo.ImmovableWaste; //固定损耗率
                //dtoComponent.Scrap = _bomComponent.Scrap;//损耗率
                dtoComponent.Scrap = _ecnAlter.PostScrap;//损耗率

                dtoComponent.UsageQtyType = UsageQuantityTypeEnum.Variable.Value;
                //dtoComponent.UsageQty = _bomComponent.UsageQty;
                //dtoComponent.ParentQty = _bomComponent.ParentQty;
                dtoComponent.UsageQty = _ecnAlter.PostUsageQty;
                dtoComponent.ParentQty = _ecnAlter.PostParentQty;

                dtoComponent.IssueUOM = new CommonArchiveDataDTOData();
                dtoComponent.IssueUOM.ID = beItemComponent.MaterialOutUOM.ID;
                dtoComponent.IssueUOM.Code = beItemComponent.MaterialOutUOM.Code;
                dtoComponent.IssueUOM.Name = beItemComponent.MaterialOutUOM.Name;
                dtoComponent.PlanPercent = 0;
                dtoComponent.IsCharge = true;
                dtoComponent.FromQty = 0;
                dtoComponent.ToQty = 0;
                dtoComponent.IsEffective = true;

                dtoComponent.SupplyStyle = SupplyStyleEnum.Org.Value;
                dtoComponent.IssueOrg = new CommonArchiveDataDTOData();
                //dtoComponent.IssueOrg.ID = _beOrg.ID;
                //dtoComponent.IssueOrg.Name = _beOrg.Name;
                dtoComponent.IssueOrg.Code = szOrgCode;
                dtoComponent.IsSpecialUseItem = false;//是否专项控制
                if (beItemComponent.InventoryInfo.Warehouse != null)
                {
                    dtoComponent.SupplyWareHouse = new CommonArchiveDataDTOData();//供应地点
                    dtoComponent.SupplyWareHouse.ID = beItemComponent.InventoryInfo.Warehouse.ID;
                    dtoComponent.SupplyWareHouse.Code = beItemComponent.InventoryInfo.Warehouse.Code;
                    dtoComponent.SupplyWareHouse.Name = beItemComponent.InventoryInfo.Warehouse.Name;
                }
                dtoComponent.SetChkAtComplete = false;
                dtoComponent.SetChkAtOptComplete = false;
                dtoComponent.SetChkAtOptStart = false;
                if (_dtoBom.BOMType == 1)
                {
                    dtoComponent.IsWholeSetIssue = true;
                }
                else
                {
                    dtoComponent.IsWholeSetIssue = false;
                }
                dtoComponent.StandardMaterialScale = 0;
                dtoComponent.IsOverIssue = false;
                dtoComponent.IsATP = false;
                dtoComponent.IsCTP = false;
                dtoComponent.LeadTimeOffSet = 0;
                dtoComponent.IsMandatory = false;
                dtoComponent.IsExclude = false;
                dtoComponent.IsDefault = false;
                dtoComponent.IsOptionDependent = false;
                dtoComponent.IsCalcPrice = false;
                dtoComponent.MinSelectedQty = 1;
                dtoComponent.MaxSelectedQty = 1;
                dtoComponent.CostElement = new CommonArchiveDataDTOData();
                CostElement beCost = CostElement.Finder.Find("Name='材料费'", new OqlParam[] { });
                if (beCost != null)
                {
                    dtoComponent.CostElement.ID = beCost.ID;
                    dtoComponent.CostElement.Code = beCost.Code;
                    dtoComponent.CostElement.Name = beCost.Name;
                }
                dtoComponent.CostPercent = 0;//成本百分比
                dtoComponent.Remark = String.Empty;
                //直接读取料品属性，属于虚拟
                if (beItemComponent.ItemFormAttribute == ItemTypeAttributeEnum.Phantom)
                {
                    //如果子项勾选‘虚拟’，此处选择‘不发料
                    dtoComponent.IsPhantomPart = true;
                    dtoComponent.IssueStyle = IssueStyleEnum.Phantom.Value;
                }
                else
                {
                    dtoComponent.IsPhantomPart = false;
                    dtoComponent.IssueStyle = IssueStyleEnum.Push.Value;
                }
                //收货审核属性RCVApproved，标准接口未提供。

                dtoComponent.IsCeiling = false;//是否取整

                //新建立子件通过料号建立，没有工程号。
                //if (!String.IsNullOrEmpty(_bomComponent.CompProject))
                //{
                //    Project itemProject = Project.FindByCode(_bomComponent.CompProject);
                //    if (itemProject != null)
                //    {
                //        dtoComponent.CompProject = new CommonArchiveDataDTOData();
                //        dtoComponent.CompProject.ID = itemProject.ID;
                //        dtoComponent.CompProject.Code = itemProject.Code;
                //        dtoComponent.CompProject.Name = itemProject.Name;
                //    }
                //}

                return dtoComponent;
            }
            catch (Exception ex)
            {
                strbError.AppendLine(string.Format(strErrorItem, _dtoBom.ItemMaster.Code, _ecnAlter.PostItemCode, ex.Message));
                return null;
            }
        }

        private bool ExistsBOMVersionCode(String _orgCode, String _itemId, int _bomType, String _bomVersionCode)
        {
            UFIDA.U9.CBO.MFG.BOM.BOMMaster beBOMMaster = UFIDA.U9.CBO.MFG.BOM.BOMMaster.Finder.Find("Org.Code=@org and ItemMaster=@item and BomType = @bomtype and BOMVersionCode = @bomVersion ",
                            new OqlParam[] { new OqlParam(_orgCode), new OqlParam(_itemId), new OqlParam(_bomType), new OqlParam(_bomVersionCode) });
            if (beBOMMaster != null)
            {
                return true;
            }
            return false;
        }

        private ItemMasterVersion getFormerItemMasterVersion(ItemMaster item, ItemMasterVersion currVersion)
        {
            DateTime dtCurrent = currVersion.Effective.EffectiveDate;
            EntityDataQuery query = ItemMasterVersion.Finder.CreateDataQuery();
            query.Select(new string[] { "Version" });
            string condition = string.Empty;
            condition = "ID!=@id and Item=@item and Effective.EffectiveDate<=@effDate order by Effective.EffectiveDate desc";
            query.Parameters.Add(new OqlParam(currVersion.ID));
            query.Parameters.Add(new OqlParam(item.ID));
            query.Parameters.Add(new OqlParam(dtCurrent));

            string versionCode = (string)query.FindValue(condition);
            if ((versionCode != null) && (versionCode.Length > 0))
            {
                return ItemMasterVersion.GetItemVersionByVerString(item.Key, versionCode);
            }
            return null;
        }

    }

    #endregion


}