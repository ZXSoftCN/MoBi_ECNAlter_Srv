
	using System; 
	using System.Collections;
	using System.Collections.Generic ;
	using System.Runtime.Serialization;

namespace UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE
{
	/// <summary>
	/// ECN变更生产记录 缺省DTO 
	/// 
	/// </summary>
	[DataContract(Name = "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData", Namespace = "http://www.UFIDA.org/EntityData",IsReference=true)]	
	[Serializable]
    [KnownType("GetKnownTypes")]
	public partial class ECNAlterMOInfoData : UFSoft.UBF.Business.DataTransObjectBase
	{

	    public static IList<Type> GetKnownTypes()
        {
            IList<Type> knownTypes = new List<Type>();
            
                        
                        
                        
                        
                        
                                        knownTypes.Add(typeof(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData));
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
            
                knownTypes.Add(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict));
            return knownTypes;
        }
		/// <summary>
		/// Default Constructor
		/// </summary>
		public ECNAlterMOInfoData()
		{
			initData() ;
		}
		private void initData()
		{
			//设置默认值
	     			
	     			
	     			
	     			
	     			
	     							SysVersion= 0; 			     			
	     			
	     			
	     			
	     							MOQty=0m; 
	     							PrePerUsageQty=0m; 
	     							PreUsageQty=0m; 
	     							DiffPerUsageQty=0m; 
	     							DiffUsageQty=0m; 
	     							PostPerUsageQty=0m; 
	     							PostUsageQty=0m; 
	     							MOTotalRcvQty=0m; 
	     							IssuedQty=0m; 
	     							PickListDocLineNo= 0; 			     							IsFromPhantomExpanding=false; 


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
			get { return "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo" ;}
		}
		#endregion


		
		#region Properties Inner Component
	        			
			private UFSoft.UBF.Business.BusinessEntity.EntityKey m_eCNAlter_SKey ;
			/// <summary>
			/// ECN变更记录 序列化Key属性。（传递跨组织序列列字段）
			/// ECN变更生产记录.Misc.ECN变更记录
			/// </summary>
			[DataMember(IsRequired=false)]
			public UFSoft.UBF.Business.BusinessEntity.EntityKey ECNAlter_SKey
			{
				get 
				{
					return m_eCNAlter_SKey ;					
				}
				set
				{
					m_eCNAlter_SKey = value ;	
				}
			}
		/// <summary>
		/// ECN变更记录
		/// ECN变更生产记录.Misc.ECN变更记录
		/// </summary>
		[DataMember(IsRequired=false)]
		private UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData m_eCNAlter;
		public UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData ECNAlter
		{
			get	
			{	
				return m_eCNAlter ;
			}
			set	
			{	
				m_eCNAlter = value ;
			}
		}		

			
		#endregion	

		#region Properties Outer Component
		
				/// <summary>
		/// ID
		/// ECN变更生产记录.Key.ID
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
		/// ECN变更生产记录.Sys.创建时间
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
		/// ECN变更生产记录.Sys.创建人
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
		/// ECN变更生产记录.Sys.修改时间
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
		/// ECN变更生产记录.Sys.修改人
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
		/// ECN变更生产记录.Sys.事务版本
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
		/// 是否修改
		/// ECN变更生产记录.Misc.是否修改
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_isAlter ;
		public System.String IsAlter
		{
			get	
			{	
				return m_isAlter  ;
			}
			set	
			{	
				m_isAlter = value ;	
			}
		}
		

				/// <summary>
		/// 组织编号
		/// ECN变更生产记录.Misc.组织编号
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_orgCode ;
		public System.String OrgCode
		{
			get	
			{	
				return m_orgCode  ;
			}
			set	
			{	
				m_orgCode = value ;	
			}
		}
		

				/// <summary>
		/// MO单号
		/// ECN变更生产记录.Misc.MO单号
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.String m_mONo ;
		public System.String MONo
		{
			get	
			{	
				return m_mONo  ;
			}
			set	
			{	
				m_mONo = value ;	
			}
		}
		

				/// <summary>
		/// MO订单数量
		/// ECN变更生产记录.Misc.MO订单数量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_mOQty ;
		public System.Decimal MOQty
		{
			get	
			{	
				return m_mOQty  ;
			}
			set	
			{	
				m_mOQty = value ;	
			}
		}
		

				/// <summary>
		/// 替换前单个子件用量
		/// ECN变更生产记录.Misc.替换前单个子件用量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_prePerUsageQty ;
		public System.Decimal PrePerUsageQty
		{
			get	
			{	
				return m_prePerUsageQty  ;
			}
			set	
			{	
				m_prePerUsageQty = value ;	
			}
		}
		

				/// <summary>
		/// 替换前子件总需求量
		/// ECN变更生产记录.Misc.替换前子件总需求量
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
		/// 单个变化差量
		/// ECN变更生产记录.Misc.单个变化差量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_diffPerUsageQty ;
		public System.Decimal DiffPerUsageQty
		{
			get	
			{	
				return m_diffPerUsageQty  ;
			}
			set	
			{	
				m_diffPerUsageQty = value ;	
			}
		}
		

				/// <summary>
		/// 变化总差量
		/// ECN变更生产记录.Misc.变化总差量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_diffUsageQty ;
		public System.Decimal DiffUsageQty
		{
			get	
			{	
				return m_diffUsageQty  ;
			}
			set	
			{	
				m_diffUsageQty = value ;	
			}
		}
		

				/// <summary>
		/// 替换后单个子件用量
		/// ECN变更生产记录.Misc.替换后单个子件用量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_postPerUsageQty ;
		public System.Decimal PostPerUsageQty
		{
			get	
			{	
				return m_postPerUsageQty  ;
			}
			set	
			{	
				m_postPerUsageQty = value ;	
			}
		}
		

				/// <summary>
		/// 替换后子件总需求量
		/// ECN变更生产记录.Misc.替换后子件总需求量
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
		/// MO累计入库数量
		/// ECN变更生产记录.Misc.MO累计入库数量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_mOTotalRcvQty ;
		public System.Decimal MOTotalRcvQty
		{
			get	
			{	
				return m_mOTotalRcvQty  ;
			}
			set	
			{	
				m_mOTotalRcvQty = value ;	
			}
		}
		

				/// <summary>
		/// 已发放数量
		/// ECN变更生产记录.Misc.已发放数量
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Decimal m_issuedQty ;
		public System.Decimal IssuedQty
		{
			get	
			{	
				return m_issuedQty  ;
			}
			set	
			{	
				m_issuedQty = value ;	
			}
		}
		

				/// <summary>
		/// 备料表行号
		/// ECN变更生产记录.Misc.备料表行号
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Int32 m_pickListDocLineNo ;
		public System.Int32 PickListDocLineNo
		{
			get	
			{	
				return m_pickListDocLineNo  ;
			}
			set	
			{	
				m_pickListDocLineNo = value ;	
			}
		}
		

				/// <summary>
		/// 是否虚拟件扩展出来
		/// ECN变更生产记录.Misc.是否虚拟件扩展出来
		/// </summary>
		[DataMember(IsRequired=false)]
		private System.Boolean m_isFromPhantomExpanding ;
		public System.Boolean IsFromPhantomExpanding
		{
			get	
			{	
				return m_isFromPhantomExpanding  ;
			}
			set	
			{	
				m_isFromPhantomExpanding = value ;	
			}
		}
		
		#endregion	

		#region Multi_Fields
																					
		#endregion 		
	}	

}

