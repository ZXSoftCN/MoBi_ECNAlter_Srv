﻿
	using System; 
	using System.Collections;
	using System.Collections.Generic ;
	using System.Runtime.Serialization;

namespace UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE
{
	/// <summary>
	/// ECN信息 缺省DTO 
	/// 
	/// </summary>
	[DataContract(Name = "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfoData", Namespace = "http://www.UFIDA.org/EntityData",IsReference=true)]	
	[Serializable]
    [KnownType("GetKnownTypes")]
	public partial class ECNInfoData : UFSoft.UBF.Business.DataTransObjectBase
	{

	    public static IList<Type> GetKnownTypes()
        {
            IList<Type> knownTypes = new List<Type>();
            
                        
                        
                        
                        
                        
                        
                                        knownTypes.Add(typeof(List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData>));
            
                knownTypes.Add(typeof(UFSoft.UBF.Util.Data.MultiLangDataDict));
            return knownTypes;
        }
		/// <summary>
		/// Default Constructor
		/// </summary>
		public ECNInfoData()
		{
			initData() ;
		}
		private void initData()
		{
			//设置默认值
	     			
	     			
	     			
	     			
	     			
	     							SysVersion= 0; 			     			
	     			


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
			get { return "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo" ;}
		}
		#endregion


		
		#region Properties Inner Component
	        					/// <summary>
		/// ECN变更记录
		/// ECN信息.Misc.ECN变更记录
		/// </summary>
		[DataMember(IsRequired=false)]
		private List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData> m_eCNAlter;
		public List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData> ECNAlter
		{
			get	
			{	
				if (m_eCNAlter == null)
				{
					List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData> m_list = new List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData>() ;
					m_eCNAlter = m_list;
				}
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
		/// ECN信息.Key.ID
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
		/// ECN信息.Sys.创建时间
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
		/// ECN信息.Sys.创建人
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
		/// ECN信息.Sys.修改时间
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
		/// ECN信息.Sys.修改人
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
		/// ECN信息.Sys.事务版本
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
		/// ECN信息.Misc.ECN单号
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
		
		#endregion	

		#region Multi_Fields
								
		#endregion 		
	}	

}
