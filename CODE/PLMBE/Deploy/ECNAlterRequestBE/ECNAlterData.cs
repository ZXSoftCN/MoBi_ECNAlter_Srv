
	using System; 
	using System.Collections;
	using System.Collections.Generic ;
	using System.Runtime.Serialization;

namespace UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE
{
	/// <summary>
	/// ECN变更记录 缺省DTO 
	/// 
	/// </summary>
	[DataContract(Name = "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData", Namespace = "http://www.UFIDA.org/EntityData",IsReference=true)]	
	[Serializable]
    [KnownType("GetKnownTypes")]
	public partial class ECNAlterData : UFSoft.UBF.Business.DataTransObjectBase
	{

	    public static IList<Type> GetKnownTypes()
        {
            IList<Type> knownTypes = new List<Type>();
            
                        
                        
                        
                        
                        
                        
                                        knownTypes.Add(typeof(List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData>));
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                        knownTypes.Add(typeof(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfoData));
            
                knownTypes.Add(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict));
            return knownTypes;
        }
		/// <summary>
		/// Default Constructor
		/// </summary>
		public ECNAlterData()
		{
			initData() ;
		}
		private void initData()
		{
			//设置默认值
	     			
	     			
	     			
	     			
	     			
	     							SysVersion= 0; 			     			
	     			
	     			
	     			
	     			
	     			
	     			
	     			
	     							PreUsageQty=0m; 
	     							PreScrap=0m; 
	     							PreParentQty=0m; 
	     			
	     			
	     			
	     			
	     							PostUsageQty=0m; 
	     							PostScrap=0m; 
	     							PostParentQty=0m; 
	     			


			//设置组合的集合属性为List<>对象. -目前直接在属性上处理.
			
			//调用默认值初始化服务进行配置方式初始化
			UFSoft.UBF.Service.DTOService.InitConfigDefault(this);
		}		
		[System.Runtime.Serialization.OnDeserializing]
        internal void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        {
			 initData();
        }
        
		#region System Fields
		///<summary>
		/// 实体类型. 
		/// </summary>
		[DataMember(IsRequired=false)]
		public override string SysEntityType
		{
			get { return "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter" ;}
		}
		#endregion


		
		#region Properties Inner Component
	        					/// <summary>
		/// ECN变更生产记录
		/// ECN变更记录.Misc.ECN变更生产记录
		/// </summary>
		[DataMember(IsRequired=false)]
		private List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData> m_eCNAlterMOInfo;
		public List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData> ECNAlterMOInfo
		{
			get	
			{	
				if (m_eCNAlterMOInfo == null)
				{
					List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData> m_list = new List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData>() ;
					m_eCNAlterMOInfo = m_list;
				}
				return m_eCNAlterMOInfo ;
			}
			set	
			{	
				m_eCNAlterMOInfo = value ;
			}
		}		

			        			
			private UFSoft.UBF.Business.BusinessEntity.EntityKey m_eCNInfo_SKey ;
			/// <summary>
			/// ECN信息 序列化Key属性。（传递跨组织序列列字段）
			/// ECN变更记录.Misc.ECN信息
			/// </summary>
			[DataMember(IsRequired=false)]
			public UFSoft.UBF.Business.BusinessEntity.EntityKey ECNInfo_SKey
			{
				get 
				{
					return m_eCNInfo_SKey ;					
				}
				set
				{
					m_eCNInfo_SKey = value ;	
				}
			}
		/// <summary>
		/// ECN信息
		/// ECN变更记录.Misc.ECN信息
		/// </summary>
		[DataMember(IsRequired=false)]
		private UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfoData m_eCNInfo;
		public UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfoData ECNInfo
		{
			get	
			{	
				return m_eCNInfo ;
			}
			set	
			{	
				m_eCNInfo = value ;
			}
		}		

			
		#endregion	

		#region Properties Outer Component
		
				/// <summary>
		/// ID
		/// ECN变更记录.Key.ID
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int64 m_iD ;
		public System.Int64 ID
		{
			get	
			{	
				return m_iD  ;
			}
			set	
			{	
				m_iD = value ;	
			}
		}
		

				/// <summary>
		/// 创建时间
		/// ECN变更记录.Sys.创建时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_createdOn ;
		public System.DateTime CreatedOn
		{
			get	
			{	
				return m_createdOn  ;
			}
			set	
			{	
				m_createdOn = value ;	
			}
		}
		

				/// <summary>
		/// 创建人
		/// ECN变更记录.Sys.创建人
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_createdBy ;
		public System.String CreatedBy
		{
			get	
			{	
				return m_createdBy  ;
			}
			set	
			{	
				m_createdBy = value ;	
			}
		}
		

				/// <summary>
		/// 修改时间
		/// ECN变更记录.Sys.修改时间
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.DateTime m_modifiedOn ;
		public System.DateTime ModifiedOn
		{
			get	
			{	
				return m_modifiedOn  ;
			}
			set	
			{	
				m_modifiedOn = value ;	
			}
		}
		

				/// <summary>
		/// 修改人
		/// ECN变更记录.Sys.修改人
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_modifiedBy ;
		public System.String ModifiedBy
		{
			get	
			{	
				return m_modifiedBy  ;
			}
			set	
			{	
				m_modifiedBy = value ;	
			}
		}
		

				/// <summary>
		/// 事务版本
		/// ECN变更记录.Sys.事务版本
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int64 m_sysVersion ;
		public System.Int64 SysVersion
		{
			get	
			{	
				return m_sysVersion  ;
			}
			set	
			{	
				m_sysVersion = value ;	
			}
		}
		

				/// <summary>
		/// ECN单号
		/// ECN变更记录.Misc.ECN单号
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_eCNDocNo ;
		public System.String ECNDocNo
		{
			get	
			{	
				return m_eCNDocNo  ;
			}
			set	
			{	
				m_eCNDocNo = value ;	
			}
		}
		

				/// <summary>
		/// 物料编码
		/// ECN变更记录.Misc.物料编码
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_itemMasterCode ;
		public System.String ItemMasterCode
		{
			get	
			{	
				return m_itemMasterCode  ;
			}
			set	
			{	
				m_itemMasterCode = value ;	
			}
		}
		

				/// <summary>
		/// BOM版本号
		/// ECN变更记录.Misc.BOM版本号
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_bOMVersionCode ;
		public System.String BOMVersionCode
		{
			get	
			{	
				return m_bOMVersionCode  ;
			}
			set	
			{	
				m_bOMVersionCode = value ;	
			}
		}
		

				/// <summary>
		/// BOM种类
		/// ECN变更记录.Misc.BOM种类
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_bOMType ;
		public System.String BOMType
		{
			get	
			{	
				return m_bOMType  ;
			}
			set	
			{	
				m_bOMType = value ;	
			}
		}
		

				/// <summary>
		/// 替换前子件物料编码
		/// ECN变更记录.Misc.替换前子件物料编码
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_preItemCode ;
		public System.String PreItemCode
		{
			get	
			{	
				return m_preItemCode  ;
			}
			set	
			{	
				m_preItemCode = value ;	
			}
		}
		

				/// <summary>
		/// 替换前物料版本号
		/// ECN变更记录.Misc.替换前物料版本号
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_preItemVersionCode ;
		public System.String PreItemVersionCode
		{
			get	
			{	
				return m_preItemVersionCode  ;
			}
			set	
			{	
				m_preItemVersionCode = value ;	
			}
		}
		

				/// <summary>
		/// 替换前单位
		/// ECN变更记录.Misc.替换前单位
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_preIssueUomCode ;
		public System.String PreIssueUomCode
		{
			get	
			{	
				return m_preIssueUomCode  ;
			}
			set	
			{	
				m_preIssueUomCode = value ;	
			}
		}
		

				/// <summary>
		/// 替换前用量
		/// ECN变更记录.Misc.替换前用量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_preUsageQty ;
		public System.Decimal PreUsageQty
		{
			get	
			{	
				return m_preUsageQty  ;
			}
			set	
			{	
				m_preUsageQty = value ;	
			}
		}
		

				/// <summary>
		/// 替换前损耗率
		/// ECN变更记录.Misc.替换前损耗率
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_preScrap ;
		public System.Decimal PreScrap
		{
			get	
			{	
				return m_preScrap  ;
			}
			set	
			{	
				m_preScrap = value ;	
			}
		}
		

				/// <summary>
		/// 替换前母件底数
		/// ECN变更记录.Misc.替换前母件底数
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_preParentQty ;
		public System.Decimal PreParentQty
		{
			get	
			{	
				return m_preParentQty  ;
			}
			set	
			{	
				m_preParentQty = value ;	
			}
		}
		

				/// <summary>
		/// ECN事件
		/// ECN变更记录.Misc.ECN事件
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_eCNAction ;
		public System.String ECNAction
		{
			get	
			{	
				return m_eCNAction  ;
			}
			set	
			{	
				m_eCNAction = value ;	
			}
		}
		

				/// <summary>
		/// 替换后子件物料编码
		/// ECN变更记录.Misc.替换后子件物料编码
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_postItemCode ;
		public System.String PostItemCode
		{
			get	
			{	
				return m_postItemCode  ;
			}
			set	
			{	
				m_postItemCode = value ;	
			}
		}
		

				/// <summary>
		/// 替换后物料版本号
		/// ECN变更记录.Misc.替换后物料版本号
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_postItemVersionCode ;
		public System.String PostItemVersionCode
		{
			get	
			{	
				return m_postItemVersionCode  ;
			}
			set	
			{	
				m_postItemVersionCode = value ;	
			}
		}
		

				/// <summary>
		/// 替换后单位
		/// ECN变更记录.Misc.替换后单位
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_postIssueUomCode ;
		public System.String PostIssueUomCode
		{
			get	
			{	
				return m_postIssueUomCode  ;
			}
			set	
			{	
				m_postIssueUomCode = value ;	
			}
		}
		

				/// <summary>
		/// 替换后用量
		/// ECN变更记录.Misc.替换后用量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_postUsageQty ;
		public System.Decimal PostUsageQty
		{
			get	
			{	
				return m_postUsageQty  ;
			}
			set	
			{	
				m_postUsageQty = value ;	
			}
		}
		

				/// <summary>
		/// 替换后损耗率
		/// ECN变更记录.Misc.替换后损耗率
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_postScrap ;
		public System.Decimal PostScrap
		{
			get	
			{	
				return m_postScrap  ;
			}
			set	
			{	
				m_postScrap = value ;	
			}
		}
		

				/// <summary>
		/// 替换后母件底数
		/// ECN变更记录.Misc.替换后母件底数
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_postParentQty ;
		public System.Decimal PostParentQty
		{
			get	
			{	
				return m_postParentQty  ;
			}
			set	
			{	
				m_postParentQty = value ;	
			}
		}
		
		#endregion	

		#region Multi_Fields
																									
		#endregion 		
	}	

}

