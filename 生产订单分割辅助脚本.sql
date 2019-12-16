exec sp_executesql N'with A as (SELECT * FROM ( SELECT  A.[PrevMO] as [A_PrevMO], A.[NextMO] as [A_NextMO], A.[SplitMergeType] as [A_SplitMergeType], A.[IsAutoCreate] as [A_IsAutoCreate], A.[QtyRatio] as [A_QtyRatio], A.[CostRatio] as [A_CostRatio], A.[Date] as [A_Date], A.[ID] as [A_ID], A.[SysVersion] as [A_SysVersion], A.[RootMO] as [A_RootMO] , ROW_NUMBER() OVER(ORDER BY A.[ID] asc, (A.[ID] + 17) asc ) AS rownum  
FROM  MO_MOSplitMergeRelation as A WHERE  ((A.[PrevMO] = 1001506280009474) or (A.[NextMO] = 1001506280009474))) T WHERE T.rownum>  @PageLowerBound and T.rownum<= @PageUpperBound) select  A.[A_PrevMO] as [PrevMO], A.[A_NextMO] as [NextMO], A2.[Round_Precision] as [PrevMO_ProductUOM_Round_Precision], A2.[Round_RoundType] as [PrevMO_ProductUOM_Round_RoundType], A2.[Round_RoundValue] as [PrevMO_ProductUOM_Round_RoundValue], A4.[Round_Precision] as [NextMO_ProductUOM_Round_Precision], A4.[Round_RoundType] as [NextMO_ProductUOM_Round_RoundType], A4.[Round_RoundValue] as [NextMO_ProductUOM_Round_RoundValue], A6.[Round_Precision] as [RootMO_ProductUOM_Round_Precision], A6.[Round_RoundType] as [RootMO_ProductUOM_Round_RoundType], A6.[Round_RoundValue] as [RootMO_ProductUOM_Round_RoundValue], A1.[DocNo] as [PrevMO_DocNo], A3.[DocNo] as [NextMO_DocNo], A.[A_SplitMergeType] as [SplitMergeType], A.[A_IsAutoCreate] as [IsAutoCreate], A.[A_QtyRatio] as [QtyRatio], A.[A_CostRatio] as [CostRatio], A.[A_Date] as [Date], A.[A_ID] as [ID], A.[A_SysVersion] as [SysVersion] from  A  left join [MO_MO] as A1 on (A.[A_PrevMO] = A1.[ID])  left join [Base_UOM] as A2 on (A1.[ProductUOM] = A2.[ID])  left join [MO_MO] as A3 on (A.[A_NextMO] = A3.[ID])  left join [Base_UOM] as A4 on (A3.[ProductUOM] = A4.[ID])  left join [MO_MO] as A5 on (A.[A_RootMO] = A5.[ID])  left join [Base_UOM] as A6 on (A5.[ProductUOM] = A6.[ID]) order by A.rownum ',N'@PageLowerBound bigint,@PageUpperBound bigint',@PageLowerBound=0,@PageUpperBound=20

select docno,* from mo_mo where ID = 1001911060010001

分割生产订单号：
MO1506280662
MO1911060001

select  A1.[DocNo],A.* from  MO_MOSplitMergeRelation as A  left join [MO_MO] as A1 on (A.[NextMO] = A1.[ID])
join MO_MO A2 on A.PrevMO = A2.ID
where A2.DocNO = 'MO1506280662'

select * from sys.tables where name like '%Safor%'

select  A1.[DocNo],A.* from  MO_MOSplitMergeRelation as A  
left join [MO_MO] as A1 on (A.[NextMO] = A1.[ID])
join MO_MO A2 on A.PrevMO = A2.ID

where A.SplitMergeType = 0 and  A.CreatedOn > ''