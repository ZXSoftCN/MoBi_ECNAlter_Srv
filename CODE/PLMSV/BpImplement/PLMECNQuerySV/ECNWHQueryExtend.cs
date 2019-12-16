namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
	using System;
	using System.Collections.Generic;
	using System.Text; 
	using UFSoft.UBF.AopFrame;	
	using UFSoft.UBF.Util.Context;

	/// <summary>
	/// ECNWHQuery partial 
	/// </summary>	
	public partial class ECNWHQuery 
	{	
		internal BaseStrategy Select()
		{
			return new ECNWHQueryImpementStrategy();	
		}		
	}
	
	#region  implement strategy	
	/// <summary>
	/// Impement Implement
	/// 
	/// </summary>	
	internal partial class ECNWHQueryImpementStrategy : BaseStrategy
	{
		public ECNWHQueryImpementStrategy() { }

		public override object Do(object obj)
		{						
			ECNWHQuery bpObj = (ECNWHQuery)obj;

            StringBuilder strbResult = new StringBuilder();


            if (string.IsNullOrEmpty(bpObj.BOMItemInfo))
            {
                //logger.Error(string.Format("创建料品失败：传入参数BOMItemInfo为空。"));
                strbResult.AppendFormat(string.Format("<ResultInfo Error=\"{0}\" />", "查询库存失败：传入参数BOMItemInfo为空。"));
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

            //Organization beOrgContext = Organization.FindByCode(cxtInfo.OrgCode);

            //ItemMaster beItemMaster = ItemMaster.Finder.Find("Code=@code and Org=@org",
            //            new OqlParam[] { new OqlParam(bpObj.ItemModule), new OqlParam(beOrgContext.ID) });
            //if (beItemMaster == null)
            //{
            //    logger.Error(string.Format("模板料品ItemModule编号{0},组织【{1}】下无法找到!", bpObj.ItemModule, beOrgContext.Name));
            //    strbError.AppendLine(string.Format("<ResultInfo Error=\"{0}\" />",
            //        string.Format("模板料品ItemModule编号{0},组织【{1}】下无法找到!", bpObj.ItemModule, beOrgContext.Name)));
            //    return strbResult.ToString();
            //}

            ECNWHQueryRlt ecnWhQueryRlt = new ECNWHQueryRlt();
            ecnWhQueryRlt.OrgCode = ecnQuery.OrgCode;
            String[] arrOrgs = ecnQuery.OrgCode.Split(new String[] { "," },StringSplitOptions.RemoveEmptyEntries);
            
            List<WHBOMMaster> whBOMMasters = new List<WHBOMMaster>();

            
            foreach (BOMMaster bomMaster in ecnQuery.BomMasters)
            {
                WHBOMMaster whBOMMaster = new WHBOMMaster();
                whBOMMaster.ItemMasterCode = bomMaster.ItemMasterCode;
                whBOMMaster.BOMVersionCode = bomMaster.BOMVersionCode;
                whBOMMaster.BOMType = bomMaster.BOMType;

                //多组织查询时对各数据量进行汇总合并。
                decimal _onWayQtySum = decimal.Zero;
                decimal _whQtySum = decimal.Zero;
                decimal _whTransQtySum = decimal.Zero;
                decimal _MORequestQtySum = decimal.Zero;

                for (int i = 0; i < arrOrgs.Length; i++)
                {
                    String queryOrg = arrOrgs[i];
                    
                    #region  cjy 2018年9月27日20:18:15 增加BOM母项的相关数量字段
                    #region  在途量
                    //已审核的采购未收货
                    StringBuilder _Waysql_1 = new StringBuilder();
                    _Waysql_1.Append(" SELECT isnull(sum(PurQtyPU - TotalRecievedQtyPU),0) as OnWayQty ");
                    _Waysql_1.Append(" from PM_POLine A ");
                    _Waysql_1.Append(" LEFT JOIN PM_PurchaseOrder B on A.PurchaseOrder = B.ID ");
                    _Waysql_1.Append(" LEFT JOIN CBO_ItemMaster C on C.ID = A.ItemInfo_ItemID ");
                    _Waysql_1.Append(" LEFT JOIN Base_Organization D on D.ID = B.Org ");
                    _Waysql_1.Append(" where B.Status = 2 and C.Code='" + bomMaster.ItemMasterCode + "' and D.Code='" + queryOrg + "' ");
                    _Waysql_1.Append(" GROUP BY C.Code ");

                    object _onWayQty_1 = 0;
                    UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), _Waysql_1.ToString(), null, out _onWayQty_1);

                    //未业务关闭的退货数量
                    StringBuilder _Waysql_2 = new StringBuilder();
                    _Waysql_2.Append(" SELECT isnull(SUM(A.RtnFillQtyTU),0) AS RtnFillQtyTU ");
                    _Waysql_2.Append(" FROM  PM_RcvLine A ");
                    _Waysql_2.Append(" LEFT JOIN PM_Receivement B ON B.ID=A.Receivement ");
                    _Waysql_2.Append(" LEFT JOIN CBO_ItemMaster C on C.ID = A.ItemInfo_ItemID ");
                    _Waysql_2.Append(" LEFT JOIN Base_Organization D on D.ID = B.Org ");
                    _Waysql_2.Append(" where B.Status != 5 and C.Code='" + bomMaster.ItemMasterCode + "' and D.Code='" + queryOrg + "' ");
                    _Waysql_2.Append(" GROUP BY C.Code ");

                    object _onWayQty_2 = 0;
                    UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), _Waysql_2.ToString(), null, out _onWayQty_2);

                    //已核准和开工（未终止）的生产订单未入库数量
                    StringBuilder _Waysql_3 = new StringBuilder();
                    _Waysql_3.Append(" SELECT ISNULL(SUM(A.ProductQty-A.TotalRcvQty),0) AS ProductQty ");
                    _Waysql_3.Append(" FROM MO_MO A ");
                    _Waysql_3.Append(" LEFT JOIN CBO_ItemMaster B ON B.ID=A.ItemMaster ");
                    _Waysql_3.Append(" LEFT JOIN Base_Organization C on C.ID=A.Org ");
                    _Waysql_3.Append(" where A.DocState in (1,2) and B.Code='" + bomMaster.ItemMasterCode + "' and C.Code='" + queryOrg + "' ");
                    _Waysql_3.Append(" GROUP BY B.Code ");

                    object _onWayQty_3 = 0;
                    UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), _Waysql_3.ToString(), null, out _onWayQty_3);

                    decimal _onWayQty = decimal.Zero;

                    if (_onWayQty_1 == null)
                        _onWayQty += 0;
                    else
                        _onWayQty += decimal.Parse(_onWayQty_1.ToString());

                    if (_onWayQty_2 == null)
                        _onWayQty += 0;
                    else
                        _onWayQty += decimal.Parse(_onWayQty_2.ToString());

                    if (_onWayQty_3 == null)
                        _onWayQty += 0;
                    else
                        _onWayQty += decimal.Parse(_onWayQty_3.ToString());


                    _onWayQtySum += _onWayQty;

                    #endregion

                    #region  库存量
                    StringBuilder _whsql = new StringBuilder();
                    _whsql.Append("select  isnull(sum((((A.[StoreQty] - A.[ResvStQty]) - A.[ResvOccupyStQty]) -  case  when ((((A.[IsProdCancel] = 1) or (A.[MO_EntityID] != 0)) or A.[ProductDate] is not null) or (A.[WP_EntityID] != 0)) then A.[StoreQty] else convert(decimal(24,9),0) end )),0) as InvQty ");
                    _whsql.Append(" from InvTrans_WhQoh as A ");
                    _whsql.Append(" left join CBO_ItemMaster B on B.ID = A.ItemInfo_ItemID ");
                    _whsql.Append(" left join Base_Organization C on C.ID = B.Org ");
                    _whsql.Append(" where B.Code = '" + bomMaster.ItemMasterCode + "' AND C.Code = '" + queryOrg + "' ");
                    _whsql.Append(" group by B.[Code] ");

                    object _onWhQty = 0;
                    UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), _whsql.ToString(), null, out _onWhQty);

                    //if (_onWhQty == null)
                    //    whBOMMaster.OnWhQty = 0;
                    //else
                    //    whBOMMaster.OnWhQty = decimal.Parse(_onWhQty.ToString());

                    if (_onWhQty != null)
                    {
                        _whQtySum += decimal.Parse(_onWhQty.ToString());
                    }
                    #endregion


                    #region 调出未入数量

                    StringBuilder _whTranssql = new StringBuilder();

                    _whTranssql.Append(" SELECT isnull(sum(StoreUOMQty), 0) as StoreUOMQty  ");
                    _whTranssql.Append(" FROM (SELECT A.StoreUOMQty -  ");
                    _whTranssql.Append(" (SELECT SUM(RcvQty) FROM InvDoc_TransOutSubLine where TransOutLine = a.ID) AS StoreUOMQty   ");
                    _whTranssql.Append("  FROM InvDoc_TransOutLine A ");
                    _whTranssql.Append("  LEFT JOIN CBO_ItemMaster B ON B.ID = A.ItemInfo_ItemID ");
                    _whTranssql.Append(" LEFT JOIN Base_Organization C on C.ID = A.Org ");
                    _whTranssql.Append(" WHERE B.Code = '" + bomMaster.ItemMasterCode + "' AND C.Code = '" + queryOrg + "' ) as TableA ");


                    object _whTransQty = 0;
                    UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), _whTranssql.ToString(), null, out _whTransQty);

                    //if (_whTransQty == null)
                    //    whBOMMaster.OnWhTransQty = 0;
                    //else
                    //    whBOMMaster.OnWhTransQty = decimal.Parse(_whTransQty.ToString());

                    if (_whTransQty != null)
                    {
                        _whTransQtySum += decimal.Parse(_whTransQty.ToString());
                    }

                    #endregion

                    #region MO需求量 已下达未完工的数量

                    StringBuilder _mosql = new StringBuilder();

                    _mosql.Append(" SELECT isnull(SUM(A.ActualReqQty - A.IssuedQty), 0) AS MORequestQty ");
                    _mosql.Append(" FROM MO_MOPickList A ");
                    _mosql.Append(" LEFT JOIN MO_MO B ON B.ID = A.MO ");
                    _mosql.Append(" LEFT JOIN CBO_ItemMaster C on C.ID = A.ItemMaster ");
                    _mosql.Append(" LEFT JOIN Base_Organization D on D.ID = B.Org ");
                    _mosql.Append(" WHERE C.Code = '" + bomMaster.ItemMasterCode + "' AND D.Code = '" + queryOrg + "' AND B.DocState = 2 ");
                    _mosql.Append(" Group by C.Code ");

                    object _moRequestQty = 0;
                    UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), _mosql.ToString(), null, out _moRequestQty);
                    //if (_moRequestQty == null)
                    //    whBOMMaster.MORequestQty = 0;
                    //else
                    //    whBOMMaster.MORequestQty = decimal.Parse(_moRequestQty.ToString());

                    if (_moRequestQty != null)
                    {
                        _MORequestQtySum += decimal.Parse(_moRequestQty.ToString());
                    }
                    #endregion


                    #endregion

                    List<WHBOMComponent> whBOMComponents = new List<WHBOMComponent>();

                    foreach (BOMComponent bomComponent in bomMaster.Components)
                    {
                        WHBOMComponent whBOMComponent = new WHBOMComponent();
                        whBOMComponent.PreItemCode = bomComponent.PreItemCode;
                        whBOMComponent.PreItemVersionCode = bomComponent.PreItemVersionCode;
                        whBOMComponent.Uom = bomComponent.PreIssueUomCode;

                        decimal onWayQtySum = decimal.Zero;
                        decimal whQtySum = decimal.Zero;
                        decimal whTransQtySum = decimal.Zero;
                        decimal MORequestQtySum = decimal.Zero;

                        for (int j = 0; j < arrOrgs.Length; j++)
                        {
                            String queryOrg_Comp = arrOrgs[j];


                            #region  在途量
                            //采购未收货
                            StringBuilder Waysql_1 = new StringBuilder();
                            Waysql_1.Append(" SELECT isnull(sum(PurQtyPU - TotalRecievedQtyPU),0) as OnWayQty ");
                            Waysql_1.Append(" from PM_POLine A ");
                            Waysql_1.Append(" LEFT JOIN PM_PurchaseOrder B on A.PurchaseOrder = B.ID ");
                            Waysql_1.Append(" LEFT JOIN CBO_ItemMaster C on C.ID = A.ItemInfo_ItemID ");
                            Waysql_1.Append(" LEFT JOIN Base_Organization D on D.ID = B.Org ");
                            Waysql_1.Append(" where C.Code='" + bomComponent.PreItemCode + "' and D.Code='" + queryOrg_Comp + "' ");
                            Waysql_1.Append(" GROUP BY C.Code ");

                            object onWayQty_1 = 0;
                            UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), Waysql_1.ToString(), null, out onWayQty_1);

                            //退货不等于业务关闭
                            StringBuilder Waysql_2 = new StringBuilder();
                            Waysql_2.Append(" SELECT isnull(SUM(A.RtnFillQtyTU),0) AS RtnFillQtyTU ");
                            Waysql_2.Append(" FROM  PM_RcvLine A ");
                            Waysql_2.Append(" LEFT JOIN PM_Receivement B ON B.ID=A.Receivement ");
                            Waysql_2.Append(" LEFT JOIN CBO_ItemMaster C on C.ID = A.ItemInfo_ItemID ");
                            Waysql_2.Append(" LEFT JOIN Base_Organization D on D.ID = B.Org ");
                            Waysql_2.Append(" where C.Code='" + bomComponent.PreItemCode + "' and D.Code='" + queryOrg_Comp + "' ");
                            Waysql_2.Append(" GROUP BY C.Code ");

                            object onWayQty_2 = 0;
                            UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), Waysql_2.ToString(), null, out onWayQty_2);

                            //生成未入库数量
                            StringBuilder Waysql_3 = new StringBuilder();
                            Waysql_3.Append(" SELECT ISNULL(SUM(A.ProductQty-A.TotalRcvQty),0) AS ProductQty ");
                            Waysql_3.Append(" FROM MO_MO A ");
                            Waysql_3.Append(" LEFT JOIN CBO_ItemMaster B ON B.ID=A.ItemMaster ");
                            Waysql_3.Append(" LEFT JOIN Base_Organization C on C.ID=A.Org ");
                            Waysql_3.Append(" where B.Code='" + bomComponent.PreItemCode + "' and C.Code='" + queryOrg_Comp + "' ");
                            Waysql_3.Append(" GROUP BY B.Code ");

                            object onWayQty_3 = 0;
                            UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), Waysql_3.ToString(), null, out onWayQty_3);


                            decimal onWayQty = decimal.Zero;


                            if (onWayQty_1 == null)
                                onWayQty += 0;
                            else
                                onWayQty += decimal.Parse(onWayQty_1.ToString());

                            if (onWayQty_2 == null)
                                onWayQty += 0;
                            else
                                onWayQty += decimal.Parse(onWayQty_2.ToString());

                            if (onWayQty_3 == null)
                                onWayQty += 0;
                            else
                                onWayQty += decimal.Parse(onWayQty_3.ToString());

                            onWayQtySum += onWayQty;
                            #endregion

                            #region  库存量
                            StringBuilder whsql = new StringBuilder();
                            whsql.Append("select  isnull(sum((((A.[StoreQty] - A.[ResvStQty]) - A.[ResvOccupyStQty]) -  case  when ((((A.[IsProdCancel] = 1) or (A.[MO_EntityID] != 0)) or A.[ProductDate] is not null) or (A.[WP_EntityID] != 0)) then A.[StoreQty] else convert(decimal(24,9),0) end )),0) as InvQty ");
                            whsql.Append(" from InvTrans_WhQoh as A ");
                            whsql.Append(" left join CBO_ItemMaster B on B.ID = A.ItemInfo_ItemID ");
                            whsql.Append(" left join Base_Organization C on C.ID = B.Org ");
                            whsql.Append(" where B.Code = '" + bomComponent.PreItemCode + "' AND C.Code = '" + queryOrg_Comp + "' ");
                            whsql.Append(" group by B.[Code] ");

                            object onWhQty = 0;
                            UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), whsql.ToString(), null, out onWhQty);

                            //if (onWhQty == null)
                            //    whBOMComponent.OnWhQty = 0;
                            //else
                            //    whBOMComponent.OnWhQty = decimal.Parse(onWhQty.ToString());

                            if (onWhQty != null)
                            {
                                whQtySum += decimal.Parse(onWhQty.ToString());
                            }

                            #endregion


                            #region 调出未入数量

                            StringBuilder whTranssql = new StringBuilder();

                            whTranssql.Append(" SELECT isnull(sum(StoreUOMQty), 0) as StoreUOMQty  ");
                            whTranssql.Append(" FROM (SELECT A.StoreUOMQty -  ");
                            whTranssql.Append(" (SELECT SUM(RcvQty) FROM InvDoc_TransOutSubLine where TransOutLine = a.ID) AS StoreUOMQty   ");
                            whTranssql.Append("  FROM InvDoc_TransOutLine A ");
                            whTranssql.Append("  LEFT JOIN CBO_ItemMaster B ON B.ID = A.ItemInfo_ItemID ");
                            whTranssql.Append(" LEFT JOIN Base_Organization C on C.ID = A.Org ");
                            whTranssql.Append(" WHERE B.Code = '" + bomComponent.PreItemCode + "' AND C.Code = '" + queryOrg_Comp + "' ) as TableA ");


                            object whTransQty = 0;
                            UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), whTranssql.ToString(), null, out whTransQty);

                            //if (onWhQty == null)
                            //    whBOMComponent.OnWhTransQty = 0;
                            //else
                            //    whBOMComponent.OnWhTransQty = decimal.Parse(whTransQty.ToString());

                            if (onWhQty != null)
                            {
                                whTransQtySum += decimal.Parse(whTransQty.ToString());
                            }

                            #endregion

                            #region MO需求量 已下达未完工的数量

                            StringBuilder mosql = new StringBuilder();

                            mosql.Append(" SELECT isnull(SUM(A.ActualReqQty - A.IssuedQty), 0) AS MORequestQty ");
                            mosql.Append(" FROM MO_MOPickList A ");
                            mosql.Append(" LEFT JOIN MO_MO B ON B.ID = A.MO ");
                            mosql.Append(" LEFT JOIN CBO_ItemMaster C on C.ID = A.ItemMaster ");
                            mosql.Append(" LEFT JOIN Base_Organization D on D.ID = B.Org ");
                            mosql.Append(" WHERE C.Code = '" + bomComponent.PreItemCode + "' AND D.Code = '" + queryOrg_Comp + "' AND B.DocState = 2 ");
                            mosql.Append(" Group by C.Code ");

                            object moRequestQty = 0;
                            UFSoft.UBF.Util.DataAccess.DataAccessor.RunSQL(UFSoft.UBF.Util.DataAccess.DataAccessor.GetConn(), mosql.ToString(), null, out moRequestQty);
                            //if (moRequestQty == null)
                            //    whBOMComponent.MORequestQty = 0;
                            //else
                            //    whBOMComponent.MORequestQty = decimal.Parse(moRequestQty.ToString()); ;

                            if (moRequestQty != null)
                            {
                                MORequestQtySum += decimal.Parse(moRequestQty.ToString());
                            }

                            #endregion

                        }

                        whBOMComponent.OnWayQty = onWayQtySum;
                        whBOMComponent.OnWhQty = whQtySum;
                        whBOMComponent.OnWhTransQty = whTransQtySum;
                        whBOMComponent.MORequestQty = MORequestQtySum;

                        whBOMComponents.Add(whBOMComponent);
                    }

                    whBOMMaster.WHComponents = whBOMComponents;
                }

                whBOMMaster.OnWayQty = _onWayQtySum;
                whBOMMaster.OnWhQty = _whQtySum;
                whBOMMaster.OnWhTransQty = _whTransQtySum;
                whBOMMaster.MORequestQty = _MORequestQtySum;

                whBOMMasters.Add(whBOMMaster);
            }

            ecnWhQueryRlt.WHBOMMasters = whBOMMasters;


            strbResult.Append(XmlSerializerHelper.XmlSerialize<ECNWHQueryRlt>(ecnWhQueryRlt, Encoding.Unicode));


            return strbResult.ToString();
        }		
	}

	#endregion
	
	
}