using System;
using System.Collections;
using System.Collections.Generic ;
using System.Runtime.Serialization;

namespace UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE
{
	
	/// <summary>
	/// 实体: ECN变更生产记录
	/// 
	/// </summary>
	[Serializable]	
	public  partial class ECNAlterMOInfo : UFSoft.UBF.Business.BusinessEntity
	{





		#region Create Instance
		/// <summary>
		/// Constructor
		/// </summary>
		public ECNAlterMOInfo(){
		}


		    
		/// <summary>
		/// Create Instance With Parent 
		/// </summary>
		/// <returns>Instance</returns>
		public  static ECNAlterMOInfo Create(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter parentEntity) {
			ECNAlterMOInfo entity = (ECNAlterMOInfo)UFSoft.UBF.Business.Entity.Create(CurrentClassKey, parentEntity);
			if (parentEntity == null)
				throw new ArgumentNullException("parentEntity");
			entity.ECNAlter = parentEntity ;
			parentEntity.ECNAlterMOInfo.Add(entity) ;
			return entity;
		}
	
		/// <summary>
		/// use for Serialization
		/// </summary>
		protected ECNAlterMOInfo(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
			:base(info,context)
		{
		}
		protected override bool IsMainEntity
		{
			get { return false ;}
		}
		#endregion

		#region Create Default 
	    
		/// <summary>
		/// Create Instance With Parent 
		/// </summary>
		/// <returns>Instance</returns>
        [Obsolete("仅用于开发的测试用例时期.正式版返回NULL.不可使用.")]
		public  static ECNAlterMOInfo CreateDefault(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter parentEntity) {
		#if Test		
			return CreateDefault_Extend(parentEntity);
		#else 
		    return null;
		#endif
		}
	
		#endregion

		#region ClassKey
		protected override string ClassKey_FullName
        {
            get { return "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo"; }    
        }
		//private static UFSoft.UBF.PL.IClassKey _currentClassKey;
		//由于可能每次访问时的Enterprise不一样，所以每次重取.
		private static UFSoft.UBF.PL.IClassKey CurrentClassKey
		{
			get {
				return  UFSoft.UBF.PL.ClassKeyFacatory.CreateKey("UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo");
			}
		}
		


		#endregion 

		#region EntityKey
		/// <summary>
		/// Strong Class ECNAlterMOInfo EntityKey 
		/// </summary>
		[Serializable()]
	    [DataContract(Name = "EntityKey", Namespace = "UFSoft.UBF.Business.BusinessEntity")]
		public new partial class EntityKey : UFSoft.UBF.Business.BusinessEntity.EntityKey
		{
			public EntityKey(long id): this(id, "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo")
			{}
			//Construct using by freamwork.
			protected EntityKey(long id , string entityType):base(id,entityType)
			{}
			/// <summary>
			/// 得到当前Key所对应的Entity．(Session级有缓存,性能不用考虑．)
			/// </summary>
			public new ECNAlterMOInfo GetEntity()
			{
				return (ECNAlterMOInfo)base.GetEntity();
			}
			public static bool operator ==(EntityKey obja, EntityKey objb)
			{
				if (object.ReferenceEquals(obja, null))
				{
					if (object.ReferenceEquals(objb, null))
						return true;
					return false;
				}
				return obja.Equals(objb);
			}
			public static bool operator !=(EntityKey obja, EntityKey objb)
			{
				return !(obja == objb);
			}
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
			public override bool Equals(object obj)
			{
				return base.Equals(obj);
			}
		}
		protected override UFSoft.UBF.Business.BusinessEntity.EntityKey CreateEntityKey()
		{
			return new EntityKey(this.ID);
		}
		/// <summary>
		/// Strong Class EntityKey Property
		/// </summary>
		public new EntityKey Key
		{
			get
			{
				return base.Key as EntityKey;
			}
		}
		#endregion

		#region Finder
		/// <summary>
		/// Strong Class EntityFinder
		/// </summary>
		public new partial class EntityFinder : UFSoft.UBF.Business.BusinessEntity.EntityFinder<ECNAlterMOInfo> 
		{
		    public EntityFinder():base(CurrentClassKey)
			{
			}
			public new EntityList FindAll(string opath, params UFSoft.UBF.PL.OqlParam[] oqlParameters)
			{
				return new EntityList(base.FindAll(opath, oqlParameters));                
			}
			public new EntityList FindAll(UFSoft.UBF.PL.ObjectQueryOptions options, string opath, params UFSoft.UBF.PL.OqlParam[] oqlParameters)
			{
				return new EntityList(base.FindAll(options,opath, oqlParameters));                
			}









						
		}

		//private static EntityFinder _finder  ;

		/// <summary>
		/// Finder
		/// </summary>
		public static EntityFinder Finder {
			get {
				//if (_finder == null)
				//	_finder =  new EntityFinder() ;
				return new EntityFinder() ;
			}
		}
		#endregion
			
		#region List

		/// <summary>
		/// EntityList
		/// </summary>
		public partial class EntityList :UFSoft.UBF.Business.Entity.EntityList<ECNAlterMOInfo>{
		    #region constructor 
		    /// <summary>
		    /// EntityList 无参的构造方法,用于其它特殊情况
		    /// </summary>
		    public EntityList()
		    {
		    }

		    /// <summary>
		    /// EntityList Constructor With Collection .主要用于查询返回实体集时使用.
		    /// </summary>
		    public EntityList(IList list) : base(list)
		    { 
		    }
		    
		    /// <summary>
		    ///  EntityList Constructor , used by  peresidence
		    /// </summary>
		    /// <param name="childAttrName">this EntityList's child Attribute Name</param>
		    /// <param name="parentEntity">this EntityList's Parent Entity </param>
		    /// <param name="parentAttrName">Parent Entity's Attribute Name with this EntityList's </param>
		    /// <param name="list">list </param>
		    public EntityList(string childAttrName,UFSoft.UBF.Business.BusinessEntity parentEntity, string parentAttrName, IList list)
			    :base(childAttrName,parentEntity,parentAttrName,list) 
		    { 
			
		    }

		    #endregion 
		    //用于一对多关联.	
		    internal IList InnerList
		    {
		    	//get { return this.innerList; }
		    	set {
		    		if (value != null)
		    		    this.innerList = value; 
		    	}
		    }
		    protected override bool IsMainEntity
		    {
			    get { return false ;}
		    }
		}
		#endregion
		
		#region Typeed OriginalData
		/// <summary>
		/// 当前实体对象的旧数据对象(为上次更新后的数据)
		/// </summary>
		public new EntityOriginal OriginalData
		{
			get {
				return (EntityOriginal)base.OriginalData;
			}
            protected set
            {
				base.OriginalData = value ;
            }
		}
		protected override UFSoft.UBF.Business.BusinessEntity.EntityOriginal CreateOriginalData()
		{
			return new EntityOriginal(this);
		}
		
		public new partial class EntityOriginal: UFSoft.UBF.Business.Entity.EntityOriginal
		{
		    //private ECNAlterMOInfo ContainerEntity ;
		    public  new ECNAlterMOInfo ContainerEntity 
		    {
				get { return  (ECNAlterMOInfo)base.ContainerEntity ;}
				set { base.ContainerEntity = value ;}
		    }
		    
		    public EntityOriginal(ECNAlterMOInfo container)
		    {
				if (container == null )
					throw new ArgumentNullException("container") ;
				ContainerEntity = container ;
				base.innerData = container.OldValues ;
				InitInnerData();
		    }
	




			#region member					
			
			/// <summary>
			///  OrginalData属性。只可读。
			/// ID (该属性不可为空,且无默认值)
			/// ECN变更生产记录.Key.ID
			/// </summary>
			/// <value></value>
			public  System.Int64 ID
			{
				get
				{
					System.Int64 value  = (System.Int64)base.GetValue("ID");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 创建时间 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Sys.创建时间
			/// </summary>
			/// <value></value>
			public  System.DateTime CreatedOn
			{
				get
				{
					object obj = base.GetValue("CreatedOn");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 创建人 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Sys.创建人
			/// </summary>
			/// <value></value>
			public  System.String CreatedBy
			{
				get
				{
					System.String value  = (System.String)base.GetValue("CreatedBy");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 修改时间 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Sys.修改时间
			/// </summary>
			/// <value></value>
			public  System.DateTime ModifiedOn
			{
				get
				{
					object obj = base.GetValue("ModifiedOn");
					if (obj == null)
						return System.DateTime.MinValue;
					else
					       return (System.DateTime)obj;
				}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 修改人 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Sys.修改人
			/// </summary>
			/// <value></value>
			public  System.String ModifiedBy
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ModifiedBy");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 事务版本 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Sys.事务版本
			/// </summary>
			/// <value></value>
			public  System.Int64 SysVersion
			{
				get
				{
					System.Int64 value  = (System.Int64)base.GetValue("SysVersion");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// ECN变更记录 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Misc.ECN变更记录
			/// </summary>
			/// <value></value>
			public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter ECNAlter
			{
				get
				{
					if (ECNAlterKey == null)
						return null ;
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter value =  (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter)ECNAlterKey.GetEntity();
					return value ;
				}
			}
		


   		private UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter.EntityKey m_ECNAlterKey ;
		/// <summary>
		/// EntityKey 属性
		/// ECN变更记录 的Key (该属性可为空,且无默认值)
		/// ECN变更生产记录.Misc.ECN变更记录
		/// </summary>
		/// <value></value>
		public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter.EntityKey ECNAlterKey
		{
			get 
			{
				object obj = base.GetValue("ECNAlter") ;
				if (obj == null || (Int64)obj==UFSoft.UBF.PL.Tool.Constant.ID_NULL_Flag || (Int64)obj==0)
					return null ;
				Int64 key = (System.Int64)obj ;
				if (m_ECNAlterKey==null || m_ECNAlterKey.ID != key )
					m_ECNAlterKey = new UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter.EntityKey(key); 
				return m_ECNAlterKey ;
			}
		}

				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 是否修改 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Misc.是否修改
			/// </summary>
			/// <value></value>
			public  System.String IsAlter
			{
				get
				{
					System.String value  = (System.String)base.GetValue("IsAlter");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 组织编号 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Misc.组织编号
			/// </summary>
			/// <value></value>
			public  System.String OrgCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("OrgCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// MO单号 (该属性可为空,且无默认值)
			/// ECN变更生产记录.Misc.MO单号
			/// </summary>
			/// <value></value>
			public  System.String MONo
			{
				get
				{
					System.String value  = (System.String)base.GetValue("MONo");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// MO订单数量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.MO订单数量
			/// </summary>
			/// <value></value>
			public  System.Decimal MOQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("MOQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换前单个子件用量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.替换前单个子件用量
			/// </summary>
			/// <value></value>
			public  System.Decimal PrePerUsageQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PrePerUsageQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换前子件总需求量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.替换前子件总需求量
			/// </summary>
			/// <value></value>
			public  System.Decimal PreUsageQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PreUsageQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 单个变化差量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.单个变化差量
			/// </summary>
			/// <value></value>
			public  System.Decimal DiffPerUsageQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("DiffPerUsageQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 变化总差量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.变化总差量
			/// </summary>
			/// <value></value>
			public  System.Decimal DiffUsageQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("DiffUsageQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换后单个子件用量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.替换后单个子件用量
			/// </summary>
			/// <value></value>
			public  System.Decimal PostPerUsageQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PostPerUsageQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换后子件总需求量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.替换后子件总需求量
			/// </summary>
			/// <value></value>
			public  System.Decimal PostUsageQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PostUsageQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// MO累计入库数量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.MO累计入库数量
			/// </summary>
			/// <value></value>
			public  System.Decimal MOTotalRcvQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("MOTotalRcvQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 已发放数量 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.已发放数量
			/// </summary>
			/// <value></value>
			public  System.Decimal IssuedQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("IssuedQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 备料表行号 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.备料表行号
			/// </summary>
			/// <value></value>
			public  System.Int32 PickListDocLineNo
			{
				get
				{
					System.Int32 value  = (System.Int32)base.GetValue("PickListDocLineNo");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 是否虚拟件扩展出来 (该属性可为空,但有默认值)
			/// ECN变更生产记录.Misc.是否虚拟件扩展出来
			/// </summary>
			/// <value></value>
			public  System.Boolean IsFromPhantomExpanding
			{
				get
				{
					System.Boolean value  = (System.Boolean)base.GetValue("IsFromPhantomExpanding");
					return value;
						}
			}
		



		

			#endregion

			#region List member						
			#endregion

			#region Be List member						
			#endregion



		    
		}
		#endregion 







		#region member					
		
			/// <summary>
		/// ID (该属性不可为空,且无默认值)
		/// ECN变更生产记录.Key.ID
		/// </summary>
		/// <value></value>
	 
		public new System.Int64 ID
		{
			get
			{
				System.Int64 value  = (System.Int64)base.GetValue("ID");
				return value;
				}
				set
			{
				
								base.SetValue("ID", value);
						 
			}
		}
	



		
			/// <summary>
		/// 创建时间 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Sys.创建时间
		/// </summary>
		/// <value></value>
			public  System.DateTime CreatedOn
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("CreatedOn");
				return value;
				}
				set
			{
				
								base.SetValue("CreatedOn", value);
						 
			}
		}
	



		
			/// <summary>
		/// 创建人 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Sys.创建人
		/// </summary>
		/// <value></value>
			public  System.String CreatedBy
		{
			get
			{
				System.String value  = (System.String)base.GetValue("CreatedBy");
				return value;
				}
				set
			{
				
								base.SetValue("CreatedBy", value);
						 
			}
		}
	



		
			/// <summary>
		/// 修改时间 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Sys.修改时间
		/// </summary>
		/// <value></value>
			public  System.DateTime ModifiedOn
		{
			get
			{
				System.DateTime value  = (System.DateTime)base.GetValue("ModifiedOn");
				return value;
				}
				set
			{
				
								base.SetValue("ModifiedOn", value);
						 
			}
		}
	



		
			/// <summary>
		/// 修改人 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Sys.修改人
		/// </summary>
		/// <value></value>
			public  System.String ModifiedBy
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ModifiedBy");
				return value;
				}
				set
			{
				
								base.SetValue("ModifiedBy", value);
						 
			}
		}
	



		
			/// <summary>
		/// 事务版本 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Sys.事务版本
		/// </summary>
		/// <value></value>
			public  System.Int64 SysVersion
		{
			get
			{
				System.Int64 value  = (System.Int64)base.GetValue("SysVersion");
				return value;
				}
				set
			{
				
								base.SetValue("SysVersion", value);
						 
			}
		}
	



		
			/// <summary>
		/// ECN变更记录 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Misc.ECN变更记录
		/// </summary>
		/// <value></value>
			public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter ECNAlter
		{
			get
			{
				object  obj = this.GetRelation("ECNAlter");
				if (obj == null)
				{
					return null ;
				}
				else
				{
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter value  = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter)obj;
					return value;
				 }
			}
				internal set
			{
				
				this.SetRelation("ECNAlter", value);
					 
			}
		}
	


   		private UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter.EntityKey m_ECNAlterKey ;
		/// <summary>
		/// ECN变更记录 的Key (该属性可为空,且无默认值)
		/// ECN变更生产记录.Misc.ECN变更记录
		/// </summary>
		/// <value></value>
		public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter.EntityKey ECNAlterKey
		{
			get 
			{
				object obj = base.GetValue("ECNAlter") ;
				if (obj == null || (Int64)obj==UFSoft.UBF.PL.Tool.Constant.ID_NULL_Flag || (Int64)obj==0)
					return null ;
				Int64 key = (System.Int64)obj ;
				if (m_ECNAlterKey==null || m_ECNAlterKey.ID != key )
					m_ECNAlterKey = new UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter.EntityKey(key); 
				return m_ECNAlterKey ;
			}
			set
			{	
				if (ECNAlterKey==value)
					return ;
				this.SetRelation("ECNAlter", null);
				m_ECNAlterKey = value ;
				if (value != null) 
				{
					base.SetValue("ECNAlter",value.ID);
				}
				else
					base.SetValue("ECNAlter",UFSoft.UBF.PL.Tool.Constant.ID_NULL_Flag);
			}
		}

		
			/// <summary>
		/// 是否修改 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Misc.是否修改
		/// </summary>
		/// <value></value>
			public  System.String IsAlter
		{
			get
			{
				System.String value  = (System.String)base.GetValue("IsAlter");
				return value;
				}
				set
			{
				
								base.SetValue("IsAlter", value);
						 
			}
		}
	



		
			/// <summary>
		/// 组织编号 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Misc.组织编号
		/// </summary>
		/// <value></value>
			public  System.String OrgCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("OrgCode");
				return value;
				}
				set
			{
				
								base.SetValue("OrgCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// MO单号 (该属性可为空,且无默认值)
		/// ECN变更生产记录.Misc.MO单号
		/// </summary>
		/// <value></value>
			public  System.String MONo
		{
			get
			{
				System.String value  = (System.String)base.GetValue("MONo");
				return value;
				}
				set
			{
				
								base.SetValue("MONo", value);
						 
			}
		}
	



		
			/// <summary>
		/// MO订单数量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.MO订单数量
		/// </summary>
		/// <value></value>
			public  System.Decimal MOQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("MOQty");
				return value;
				}
				set
			{
				
								base.SetValue("MOQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换前单个子件用量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.替换前单个子件用量
		/// </summary>
		/// <value></value>
			public  System.Decimal PrePerUsageQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PrePerUsageQty");
				return value;
				}
				set
			{
				
								base.SetValue("PrePerUsageQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换前子件总需求量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.替换前子件总需求量
		/// </summary>
		/// <value></value>
			public  System.Decimal PreUsageQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PreUsageQty");
				return value;
				}
				set
			{
				
								base.SetValue("PreUsageQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 单个变化差量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.单个变化差量
		/// </summary>
		/// <value></value>
			public  System.Decimal DiffPerUsageQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("DiffPerUsageQty");
				return value;
				}
				set
			{
				
								base.SetValue("DiffPerUsageQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 变化总差量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.变化总差量
		/// </summary>
		/// <value></value>
			public  System.Decimal DiffUsageQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("DiffUsageQty");
				return value;
				}
				set
			{
				
								base.SetValue("DiffUsageQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换后单个子件用量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.替换后单个子件用量
		/// </summary>
		/// <value></value>
			public  System.Decimal PostPerUsageQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PostPerUsageQty");
				return value;
				}
				set
			{
				
								base.SetValue("PostPerUsageQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换后子件总需求量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.替换后子件总需求量
		/// </summary>
		/// <value></value>
			public  System.Decimal PostUsageQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PostUsageQty");
				return value;
				}
				set
			{
				
								base.SetValue("PostUsageQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// MO累计入库数量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.MO累计入库数量
		/// </summary>
		/// <value></value>
			public  System.Decimal MOTotalRcvQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("MOTotalRcvQty");
				return value;
				}
				set
			{
				
								base.SetValue("MOTotalRcvQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 已发放数量 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.已发放数量
		/// </summary>
		/// <value></value>
			public  System.Decimal IssuedQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("IssuedQty");
				return value;
				}
				set
			{
				
								base.SetValue("IssuedQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// 备料表行号 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.备料表行号
		/// </summary>
		/// <value></value>
			public  System.Int32 PickListDocLineNo
		{
			get
			{
				System.Int32 value  = (System.Int32)base.GetValue("PickListDocLineNo");
				return value;
				}
				set
			{
				
								base.SetValue("PickListDocLineNo", value);
						 
			}
		}
	



		
			/// <summary>
		/// 是否虚拟件扩展出来 (该属性可为空,但有默认值)
		/// ECN变更生产记录.Misc.是否虚拟件扩展出来
		/// </summary>
		/// <value></value>
			public  System.Boolean IsFromPhantomExpanding
		{
			get
			{
				System.Boolean value  = (System.Boolean)base.GetValue("IsFromPhantomExpanding");
				return value;
				}
				set
			{
				
								base.SetValue("IsFromPhantomExpanding", value);
						 
			}
		}
	



	

		#endregion

		#region List member						
		#endregion

		#region Be List member						
		#endregion
		
		#region ModelResource 其余去除，保留EntityName
		/// <summary>
		/// Entity的显示名称资源-请使用EntityRes.GetResource(EntityRes.BE_FullName)的方式取 Entity的显示名称资源.
		/// </summary>
		[Obsolete("")]
		public  string Res_EntityName {	get {return Res_EntityNameS ;}	}
		/// <summary>
		/// Entity的显示名称资源-请使用EntityRes.GetResource(EntityRes.BE_FullName)的方式取 Entity的显示名称资源.
		/// </summary>
		[Obsolete("")]
		public  static string Res_EntityNameS {	get {return EntityRes.GetResource("UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo")  ;}	}
		#endregion 		

		#region ModelResource,这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource()内部类的方式取资源
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ID")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ID　{ get { return EntityRes.GetResource("ID");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("CreatedOn")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_CreatedOn　{ get { return EntityRes.GetResource("CreatedOn");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("CreatedBy")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_CreatedBy　{ get { return EntityRes.GetResource("CreatedBy");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ModifiedOn")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ModifiedOn　{ get { return EntityRes.GetResource("ModifiedOn");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ModifiedBy")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ModifiedBy　{ get { return EntityRes.GetResource("ModifiedBy");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("SysVersion")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_SysVersion　{ get { return EntityRes.GetResource("SysVersion");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ECNAlter")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ECNAlter　{ get { return EntityRes.GetResource("ECNAlter");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("IsAlter")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_IsAlter　{ get { return EntityRes.GetResource("IsAlter");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("OrgCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_OrgCode　{ get { return EntityRes.GetResource("OrgCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("MONo")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_MONo　{ get { return EntityRes.GetResource("MONo");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("MOQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_MOQty　{ get { return EntityRes.GetResource("MOQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PrePerUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PrePerUsageQty　{ get { return EntityRes.GetResource("PrePerUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PreUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PreUsageQty　{ get { return EntityRes.GetResource("PreUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("DiffPerUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_DiffPerUsageQty　{ get { return EntityRes.GetResource("DiffPerUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("DiffUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_DiffUsageQty　{ get { return EntityRes.GetResource("DiffUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostPerUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostPerUsageQty　{ get { return EntityRes.GetResource("PostPerUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostUsageQty　{ get { return EntityRes.GetResource("PostUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("MOTotalRcvQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_MOTotalRcvQty　{ get { return EntityRes.GetResource("MOTotalRcvQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("IssuedQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_IssuedQty　{ get { return EntityRes.GetResource("IssuedQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PickListDocLineNo")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PickListDocLineNo　{ get { return EntityRes.GetResource("PickListDocLineNo");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("IsFromPhantomExpanding")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_IsFromPhantomExpanding　{ get { return EntityRes.GetResource("IsFromPhantomExpanding");　}　}
		#endregion 



		#region EntityResource 实体的属性名称及相应显示名称资源访问方法
		public class EntityRes
		{
			/// <summary>
			/// EntityName的名称
			/// </summary>
			public static string BE_Name { get { return "ECNAlterMOInfo";　}　}
			
			/// <summary>
			/// Entity　的全名. 
			/// </summary>
			public static string BE_FullName { get { return "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo";　}　}
		
			/// <summary>
			/// 属性: ID 的名称
			/// </summary>
			public static string ID　{ get { return "ID";　}　}
				
			/// <summary>
			/// 属性: 创建时间 的名称
			/// </summary>
			public static string CreatedOn　{ get { return "CreatedOn";　}　}
				
			/// <summary>
			/// 属性: 创建人 的名称
			/// </summary>
			public static string CreatedBy　{ get { return "CreatedBy";　}　}
				
			/// <summary>
			/// 属性: 修改时间 的名称
			/// </summary>
			public static string ModifiedOn　{ get { return "ModifiedOn";　}　}
				
			/// <summary>
			/// 属性: 修改人 的名称
			/// </summary>
			public static string ModifiedBy　{ get { return "ModifiedBy";　}　}
				
			/// <summary>
			/// 属性: 事务版本 的名称
			/// </summary>
			public static string SysVersion　{ get { return "SysVersion";　}　}
				
			/// <summary>
			/// 属性: ECN变更记录 的名称
			/// </summary>
			public static string ECNAlter　{ get { return "ECNAlter";　}　}
				
			/// <summary>
			/// 属性: 是否修改 的名称
			/// </summary>
			public static string IsAlter　{ get { return "IsAlter";　}　}
				
			/// <summary>
			/// 属性: 组织编号 的名称
			/// </summary>
			public static string OrgCode　{ get { return "OrgCode";　}　}
				
			/// <summary>
			/// 属性: MO单号 的名称
			/// </summary>
			public static string MONo　{ get { return "MONo";　}　}
				
			/// <summary>
			/// 属性: MO订单数量 的名称
			/// </summary>
			public static string MOQty　{ get { return "MOQty";　}　}
				
			/// <summary>
			/// 属性: 替换前单个子件用量 的名称
			/// </summary>
			public static string PrePerUsageQty　{ get { return "PrePerUsageQty";　}　}
				
			/// <summary>
			/// 属性: 替换前子件总需求量 的名称
			/// </summary>
			public static string PreUsageQty　{ get { return "PreUsageQty";　}　}
				
			/// <summary>
			/// 属性: 单个变化差量 的名称
			/// </summary>
			public static string DiffPerUsageQty　{ get { return "DiffPerUsageQty";　}　}
				
			/// <summary>
			/// 属性: 变化总差量 的名称
			/// </summary>
			public static string DiffUsageQty　{ get { return "DiffUsageQty";　}　}
				
			/// <summary>
			/// 属性: 替换后单个子件用量 的名称
			/// </summary>
			public static string PostPerUsageQty　{ get { return "PostPerUsageQty";　}　}
				
			/// <summary>
			/// 属性: 替换后子件总需求量 的名称
			/// </summary>
			public static string PostUsageQty　{ get { return "PostUsageQty";　}　}
				
			/// <summary>
			/// 属性: MO累计入库数量 的名称
			/// </summary>
			public static string MOTotalRcvQty　{ get { return "MOTotalRcvQty";　}　}
				
			/// <summary>
			/// 属性: 已发放数量 的名称
			/// </summary>
			public static string IssuedQty　{ get { return "IssuedQty";　}　}
				
			/// <summary>
			/// 属性: 备料表行号 的名称
			/// </summary>
			public static string PickListDocLineNo　{ get { return "PickListDocLineNo";　}　}
				
			/// <summary>
			/// 属性: 是否虚拟件扩展出来 的名称
			/// </summary>
			public static string IsFromPhantomExpanding　{ get { return "IsFromPhantomExpanding";　}　}
		
			/// <summary>
			/// 获取显示名称资源方法
			/// </summary>
			public static string GetResource(String attrName){
				if (attrName == BE_Name || attrName== BE_FullName)
					return UFSoft.UBF.Business.Tool.ExtendHelpAPI.GetEntityResource(BE_FullName);
																																										
				return UFSoft.UBF.Business.Tool.ExtendHelpAPI.GetAttrResource(BE_FullName, attrName);
			}

		}
		#endregion 


		#region EntityObjectBuilder 持久化性能优化
        private Dictionary<string, string> multiLangAttrs = null;
        private Dictionary<string, string> exdMultiLangAttrs = null;
        private string col_ID_Name = string.Empty;

        public override  Dictionary<string, string> MultiLangAttrs
        {
			get
			{
				return multiLangAttrs;
			}
        }
        public override  Dictionary<string, string> ExdMultiLangAttrs
        {
			get
			{
				return exdMultiLangAttrs;
			}
        }
        public override string Col_ID_Name
        {
			get
			{
				return col_ID_Name;
			}
        }  
        public override void IniData()
        {
			this.multiLangAttrs = new Dictionary<string, string>();
			this.exdMultiLangAttrs = new Dictionary<string, string>();
	
			this.col_ID_Name ="ID";
			this.exdMultiLangAttrs.Add("ID","ID");
			this.exdMultiLangAttrs.Add("CreatedOn","CreatedOn");
			this.exdMultiLangAttrs.Add("CreatedBy","CreatedBy");
			this.exdMultiLangAttrs.Add("ModifiedOn","ModifiedOn");
			this.exdMultiLangAttrs.Add("ModifiedBy","ModifiedBy");
			this.exdMultiLangAttrs.Add("SysVersion","SysVersion");
			this.exdMultiLangAttrs.Add("ECNAlter","ECNAlter");
			this.exdMultiLangAttrs.Add("IsAlter","IsAlter");
			this.exdMultiLangAttrs.Add("OrgCode","OrgCode");
			this.exdMultiLangAttrs.Add("MONo","MONo");
			this.exdMultiLangAttrs.Add("MOQty","MOQty");
			this.exdMultiLangAttrs.Add("PrePerUsageQty","PrePerUsageQty");
			this.exdMultiLangAttrs.Add("PreUsageQty","PreUsageQty");
			this.exdMultiLangAttrs.Add("DiffPerUsageQty","DiffPerUsageQty");
			this.exdMultiLangAttrs.Add("DiffUsageQty","DiffUsageQty");
			this.exdMultiLangAttrs.Add("PostPerUsageQty","PostPerUsageQty");
			this.exdMultiLangAttrs.Add("PostUsageQty","PostUsageQty");
			this.exdMultiLangAttrs.Add("MOTotalRcvQty","MOTotalRcvQty");
			this.exdMultiLangAttrs.Add("IssuedQty","IssuedQty");
			this.exdMultiLangAttrs.Add("PickListDocLineNo","PickListDocLineNo");
			this.exdMultiLangAttrs.Add("IsFromPhantomExpanding","IsFromPhantomExpanding");
        }
	#endregion 




		
		
		#region override SetTypeValue method(Use By UICommonCRUD OR Weakly Type Operation)
		public override void SetTypeValue(object propName, object value)
		{
			
			string propstr = propName.ToString();
			switch(propstr)
			{
			
																																																															

				default:
					//调用基类的实现，最终Entity基类为SetValue()
					base.SetTypeValue(propName,value);
					return;
			}
		}
		#endregion


	


		#region EntityData exchange
		
		#region  DeSerializeKey -ForEntityPorpertyType
		//反序化Key到Data的ID中 --由FromEntityData自动调用一次。实际可以分离,由跨组织服务去调用.
		private void DeSerializeKey(ECNAlterMOInfoData data)
		{
		
			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			
	
			//Entity中没有EntityKey集合，不用处理。
		}
		
		#endregion 	
        public override void FromEntityData(UFSoft.UBF.Business.DataTransObjectBase dto)
        {
			ECNAlterMOInfoData data = dto as ECNAlterMOInfoData ;
			if (data == null)
				return ;
            this.FromEntityData(data) ;
        }

        public override UFSoft.UBF.Business.DataTransObjectBase ToEntityDataBase()
        {
            return this.ToEntityData();
        }
		/// <summary>
		/// Copy Entity From EntityData
		/// </summary>
		public void FromEntityData(ECNAlterMOInfoData data)
		{
			this.FromEntityData(data,new Hashtable());
		}
		//used by ubf..
		public void FromEntityData(ECNAlterMOInfoData data,IDictionary dict)
		{
			if (data == null)
				return;
			bool m_isNeedPersistable = this.NeedPersistable ;
			this.NeedPersistable = false ;
			
			//this.innerData.ChangeEventEnabled = false;
			//this.innerRelation.RelationEventEnabled = false;
				
			if (dict == null ) dict = new Hashtable() ;
			dict[data] = this;
			this.SysState = data.SysState ;
			DeSerializeKey(data);
			#region 组件外属性
		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

		
			//ID与系统字段不处理 --Sysversion需要处理。

								this.SetTypeValue("SysVersion",data.SysVersion);
		
								this.SetTypeValue("IsAlter",data.IsAlter);
		
								this.SetTypeValue("OrgCode",data.OrgCode);
		
								this.SetTypeValue("MONo",data.MONo);
		
								this.SetTypeValue("MOQty",data.MOQty);
		
								this.SetTypeValue("PrePerUsageQty",data.PrePerUsageQty);
		
								this.SetTypeValue("PreUsageQty",data.PreUsageQty);
		
								this.SetTypeValue("DiffPerUsageQty",data.DiffPerUsageQty);
		
								this.SetTypeValue("DiffUsageQty",data.DiffUsageQty);
		
								this.SetTypeValue("PostPerUsageQty",data.PostPerUsageQty);
		
								this.SetTypeValue("PostUsageQty",data.PostUsageQty);
		
								this.SetTypeValue("MOTotalRcvQty",data.MOTotalRcvQty);
		
								this.SetTypeValue("IssuedQty",data.IssuedQty);
		
								this.SetTypeValue("PickListDocLineNo",data.PickListDocLineNo);
		
								this.SetTypeValue("IsFromPhantomExpanding",data.IsFromPhantomExpanding);
		
			#endregion 

			#region 组件内属性
	
					if (data.ECNAlter!=null)
			{
				UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter child = dict[data.ECNAlter] as UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter ;
				if (child == null)
				{
					if (data.ECNAlter.ID>0)
					{
						if (data.ECNAlter.SysState != UFSoft.UBF.PL.Engine.ObjectState.Inserted)
							child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter)(new UFSoft.UBF.Business.BusinessEntity.EntityKey(data.ECNAlter.ID,data.ECNAlter.SysEntityType).GetEntity());
						if (child==null) child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter)UFSoft.UBF.Business.Entity.CreateTransientObjWithKey(data.ECNAlter.SysEntityType,null,data.ECNAlter.ID,true) ;
					}
					else
					{
 						child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter)UFSoft.UBF.Business.Entity.CreateTransientObjWithKey(data.ECNAlter.SysEntityType,null,null,true) ;				
 					}
					
					child.FromEntityData(data.ECNAlter,dict);
				}
				this.ECNAlter = child ;
			}
	     

			#endregion 
			this.NeedPersistable = m_isNeedPersistable ;
			dict[data] = this;
		}

		/// <summary>
		/// Create EntityData From Entity
		/// </summary>
		public ECNAlterMOInfoData ToEntityData()
		{
			return ToEntityData(null,null);
		}
		/// <summary>
		/// Create EntityData From Entity - used by ubf 
		/// </summary>
		public ECNAlterMOInfoData ToEntityData(ECNAlterMOInfoData data, IDictionary dict){
			if (data == null)
				data = new ECNAlterMOInfoData();
			
			if (dict == null ) dict = new Hashtable() ;
			//就直接用ID,如果不同实体会出现相同ID，则到时候要改进。? ID一定要有。
			dict["UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo"+this.ID.ToString()] = data;
		
			data.SysState = this.SysState ;
			#region 组件外属性 -BusinessEntity,"简单值对象",简单类型,多语言.不可能存在一对多.没有集合可能.
	    
			{
				object obj =this.GetValue("ID");
				if (obj != null)
					data.ID=(System.Int64)obj;
			}
	     
	    
			{
				object obj =this.GetValue("CreatedOn");
				if (obj != null)
					data.CreatedOn=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("CreatedBy");
				if (obj != null)
					data.CreatedBy=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ModifiedOn");
				if (obj != null)
					data.ModifiedOn=(System.DateTime)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ModifiedBy");
				if (obj != null)
					data.ModifiedBy=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("SysVersion");
				if (obj != null)
					data.SysVersion=(System.Int64)obj;
			}
	     
	    
			{
				object obj =this.GetValue("IsAlter");
				if (obj != null)
					data.IsAlter=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("OrgCode");
				if (obj != null)
					data.OrgCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("MONo");
				if (obj != null)
					data.MONo=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("MOQty");
				if (obj != null)
					data.MOQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PrePerUsageQty");
				if (obj != null)
					data.PrePerUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PreUsageQty");
				if (obj != null)
					data.PreUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("DiffPerUsageQty");
				if (obj != null)
					data.DiffPerUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("DiffUsageQty");
				if (obj != null)
					data.DiffUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostPerUsageQty");
				if (obj != null)
					data.PostPerUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostUsageQty");
				if (obj != null)
					data.PostUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("MOTotalRcvQty");
				if (obj != null)
					data.MOTotalRcvQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("IssuedQty");
				if (obj != null)
					data.IssuedQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PickListDocLineNo");
				if (obj != null)
					data.PickListDocLineNo=(System.Int32)obj;
			}
	     
	    
			{
				object obj =this.GetValue("IsFromPhantomExpanding");
				if (obj != null)
					data.IsFromPhantomExpanding=(System.Boolean)obj;
			}
	     
			#endregion 

			#region 组件内属性 -Entity,"复杂值对象",枚举,实体集合.
	
			{
				object oID = this.GetValue("ECNAlter");
				if (oID != null && (Int64)oID > 0 )
				{
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData _ECNAlter = dict["UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter"+oID.ToString()] as UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterData;			
					data.ECNAlter = (_ECNAlter != null) ? _ECNAlter : (this.ECNAlter==null?null:this.ECNAlter.ToEntityData(null,dict));
				}
			}
	

			#endregion 
			return data ;
		}

		#endregion
	



	
        #region EntityValidator 
	//实体检验： 含自身检验器检验，内嵌属性类型的检验以及属性类型上的校验器的检验。
        private bool SelfEntityValidator()
        {
        





















			//调用实体自身校验器代码.
            return true; 
        }
		//校验属性是否为空的检验。主要是关联对象的效验
		public override void SelfNullableVlidator()
		{
			base.SelfNullableVlidator();
		
			
		}
			    
	#endregion 
	
	
		#region 应用版型代码区
		#endregion 


	}	
}