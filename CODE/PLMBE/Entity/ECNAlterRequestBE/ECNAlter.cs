using System;
using System.Collections;
using System.Collections.Generic ;
using System.Runtime.Serialization;

namespace UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE
{
	
	/// <summary>
	/// 实体: ECN变更记录
	/// 
	/// </summary>
	[Serializable]	
	public  partial class ECNAlter : UFSoft.UBF.Business.BusinessEntity
	{





		#region Create Instance
		/// <summary>
		/// Constructor
		/// </summary>
		public ECNAlter(){
		}


		    
		/// <summary>
		/// Create Instance With Parent 
		/// </summary>
		/// <returns>Instance</returns>
		public  static ECNAlter Create(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo parentEntity) {
			ECNAlter entity = (ECNAlter)UFSoft.UBF.Business.Entity.Create(CurrentClassKey, parentEntity);
			if (parentEntity == null)
				throw new ArgumentNullException("parentEntity");
			entity.ECNInfo = parentEntity ;
			parentEntity.ECNAlter.Add(entity) ;
			return entity;
		}
	
		/// <summary>
		/// use for Serialization
		/// </summary>
		protected ECNAlter(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
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
		public  static ECNAlter CreateDefault(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo parentEntity) {
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
            get { return "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter"; }    
        }
		//private static UFSoft.UBF.PL.IClassKey _currentClassKey;
		//由于可能每次访问时的Enterprise不一样，所以每次重取.
		private static UFSoft.UBF.PL.IClassKey CurrentClassKey
		{
			get {
				return  UFSoft.UBF.PL.ClassKeyFacatory.CreateKey("UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter");
			}
		}
		


		#endregion 

		#region EntityKey
		/// <summary>
		/// Strong Class ECNAlter EntityKey 
		/// </summary>
		[Serializable()]
	    [DataContract(Name = "EntityKey", Namespace = "UFSoft.UBF.Business.BusinessEntity")]
		public new partial class EntityKey : UFSoft.UBF.Business.BusinessEntity.EntityKey
		{
			public EntityKey(long id): this(id, "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter")
			{}
			//Construct using by freamwork.
			protected EntityKey(long id , string entityType):base(id,entityType)
			{}
			/// <summary>
			/// 得到当前Key所对应的Entity．(Session级有缓存,性能不用考虑．)
			/// </summary>
			public new ECNAlter GetEntity()
			{
				return (ECNAlter)base.GetEntity();
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
		public new partial class EntityFinder : UFSoft.UBF.Business.BusinessEntity.EntityFinder<ECNAlter> 
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
		public partial class EntityList :UFSoft.UBF.Business.Entity.EntityList<ECNAlter>{
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
		    //private ECNAlter ContainerEntity ;
		    public  new ECNAlter ContainerEntity 
		    {
				get { return  (ECNAlter)base.ContainerEntity ;}
				set { base.ContainerEntity = value ;}
		    }
		    
		    public EntityOriginal(ECNAlter container)
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
			/// ECN变更记录.Key.ID
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
			/// ECN变更记录.Sys.创建时间
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
			/// ECN变更记录.Sys.创建人
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
			/// ECN变更记录.Sys.修改时间
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
			/// ECN变更记录.Sys.修改人
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
			/// ECN变更记录.Sys.事务版本
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
			/// ECN单号 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.ECN单号
			/// </summary>
			/// <value></value>
			public  System.String ECNDocNo
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ECNDocNo");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 物料编码 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.物料编码
			/// </summary>
			/// <value></value>
			public  System.String ItemMasterCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ItemMasterCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// BOM版本号 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.BOM版本号
			/// </summary>
			/// <value></value>
			public  System.String BOMVersionCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("BOMVersionCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// BOM种类 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.BOM种类
			/// </summary>
			/// <value></value>
			public  System.String BOMType
			{
				get
				{
					System.String value  = (System.String)base.GetValue("BOMType");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换前子件物料编码 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.替换前子件物料编码
			/// </summary>
			/// <value></value>
			public  System.String PreItemCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("PreItemCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换前物料版本号 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.替换前物料版本号
			/// </summary>
			/// <value></value>
			public  System.String PreItemVersionCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("PreItemVersionCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换前单位 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.替换前单位
			/// </summary>
			/// <value></value>
			public  System.String PreIssueUomCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("PreIssueUomCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换前用量 (该属性可为空,但有默认值)
			/// ECN变更记录.Misc.替换前用量
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
			/// 替换前损耗率 (该属性可为空,但有默认值)
			/// ECN变更记录.Misc.替换前损耗率
			/// </summary>
			/// <value></value>
			public  System.Decimal PreScrap
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PreScrap");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换前母件底数 (该属性可为空,但有默认值)
			/// ECN变更记录.Misc.替换前母件底数
			/// </summary>
			/// <value></value>
			public  System.Decimal PreParentQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PreParentQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// ECN事件 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.ECN事件
			/// </summary>
			/// <value></value>
			public  System.String ECNAction
			{
				get
				{
					System.String value  = (System.String)base.GetValue("ECNAction");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换后子件物料编码 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.替换后子件物料编码
			/// </summary>
			/// <value></value>
			public  System.String PostItemCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("PostItemCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换后物料版本号 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.替换后物料版本号
			/// </summary>
			/// <value></value>
			public  System.String PostItemVersionCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("PostItemVersionCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换后单位 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.替换后单位
			/// </summary>
			/// <value></value>
			public  System.String PostIssueUomCode
			{
				get
				{
					System.String value  = (System.String)base.GetValue("PostIssueUomCode");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换后用量 (该属性可为空,但有默认值)
			/// ECN变更记录.Misc.替换后用量
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
			/// 替换后损耗率 (该属性可为空,但有默认值)
			/// ECN变更记录.Misc.替换后损耗率
			/// </summary>
			/// <value></value>
			public  System.Decimal PostScrap
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PostScrap");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// 替换后母件底数 (该属性可为空,但有默认值)
			/// ECN变更记录.Misc.替换后母件底数
			/// </summary>
			/// <value></value>
			public  System.Decimal PostParentQty
			{
				get
				{
					System.Decimal value  = (System.Decimal)base.GetValue("PostParentQty");
					return value;
						}
			}
		



				
			/// <summary>
			///  OrginalData属性。只可读。
			/// ECN信息 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.ECN信息
			/// </summary>
			/// <value></value>
			public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo ECNInfo
			{
				get
				{
					if (ECNInfoKey == null)
						return null ;
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo value =  (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo)ECNInfoKey.GetEntity();
					return value ;
				}
			}
		


   		private UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.EntityKey m_ECNInfoKey ;
		/// <summary>
		/// EntityKey 属性
		/// ECN信息 的Key (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.ECN信息
		/// </summary>
		/// <value></value>
		public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.EntityKey ECNInfoKey
		{
			get 
			{
				object obj = base.GetValue("ECNInfo") ;
				if (obj == null || (Int64)obj==UFSoft.UBF.PL.Tool.Constant.ID_NULL_Flag || (Int64)obj==0)
					return null ;
				Int64 key = (System.Int64)obj ;
				if (m_ECNInfoKey==null || m_ECNInfoKey.ID != key )
					m_ECNInfoKey = new UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.EntityKey(key); 
				return m_ECNInfoKey ;
			}
		}

		

			#endregion

			#region List member						
		
			
			private List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo> m_ECNAlterMOInfo  ;
			/// <summary>
			/// ECN变更生产记录 (该属性可为空,且无默认值)
			/// ECN变更记录.Misc.ECN变更生产记录
			/// </summary>
			/// <value></value>
			public  List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo> ECNAlterMOInfo
			{
				get
				{
					if (m_ECNAlterMOInfo == null)
						m_ECNAlterMOInfo = new List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo>();
					m_ECNAlterMOInfo.Clear();	
					foreach (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo child in ContainerEntity.ECNAlterMOInfo)
					{
						if (child.SysState != UFSoft.UBF.PL.Engine.ObjectState.Inserted)
							m_ECNAlterMOInfo.Add(child);
					}
					foreach (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo child in ContainerEntity.ECNAlterMOInfo.DelLists)
					{
						m_ECNAlterMOInfo.Add(child);
					}
					return m_ECNAlterMOInfo;
				}
			}
			#endregion

			#region Be List member						
			#endregion



		    
		}
		#endregion 







		#region member					
		
			/// <summary>
		/// ID (该属性不可为空,且无默认值)
		/// ECN变更记录.Key.ID
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
		/// ECN变更记录.Sys.创建时间
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
		/// ECN变更记录.Sys.创建人
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
		/// ECN变更记录.Sys.修改时间
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
		/// ECN变更记录.Sys.修改人
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
		/// ECN变更记录.Sys.事务版本
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
		/// ECN单号 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.ECN单号
		/// </summary>
		/// <value></value>
			public  System.String ECNDocNo
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ECNDocNo");
				return value;
				}
				set
			{
				
								base.SetValue("ECNDocNo", value);
						 
			}
		}
	



		
			/// <summary>
		/// 物料编码 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.物料编码
		/// </summary>
		/// <value></value>
			public  System.String ItemMasterCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ItemMasterCode");
				return value;
				}
				set
			{
				
								base.SetValue("ItemMasterCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// BOM版本号 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.BOM版本号
		/// </summary>
		/// <value></value>
			public  System.String BOMVersionCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("BOMVersionCode");
				return value;
				}
				set
			{
				
								base.SetValue("BOMVersionCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// BOM种类 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.BOM种类
		/// </summary>
		/// <value></value>
			public  System.String BOMType
		{
			get
			{
				System.String value  = (System.String)base.GetValue("BOMType");
				return value;
				}
				set
			{
				
								base.SetValue("BOMType", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换前子件物料编码 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.替换前子件物料编码
		/// </summary>
		/// <value></value>
			public  System.String PreItemCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("PreItemCode");
				return value;
				}
				set
			{
				
								base.SetValue("PreItemCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换前物料版本号 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.替换前物料版本号
		/// </summary>
		/// <value></value>
			public  System.String PreItemVersionCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("PreItemVersionCode");
				return value;
				}
				set
			{
				
								base.SetValue("PreItemVersionCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换前单位 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.替换前单位
		/// </summary>
		/// <value></value>
			public  System.String PreIssueUomCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("PreIssueUomCode");
				return value;
				}
				set
			{
				
								base.SetValue("PreIssueUomCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换前用量 (该属性可为空,但有默认值)
		/// ECN变更记录.Misc.替换前用量
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
		/// 替换前损耗率 (该属性可为空,但有默认值)
		/// ECN变更记录.Misc.替换前损耗率
		/// </summary>
		/// <value></value>
			public  System.Decimal PreScrap
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PreScrap");
				return value;
				}
				set
			{
				
								base.SetValue("PreScrap", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换前母件底数 (该属性可为空,但有默认值)
		/// ECN变更记录.Misc.替换前母件底数
		/// </summary>
		/// <value></value>
			public  System.Decimal PreParentQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PreParentQty");
				return value;
				}
				set
			{
				
								base.SetValue("PreParentQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// ECN事件 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.ECN事件
		/// </summary>
		/// <value></value>
			public  System.String ECNAction
		{
			get
			{
				System.String value  = (System.String)base.GetValue("ECNAction");
				return value;
				}
				set
			{
				
								base.SetValue("ECNAction", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换后子件物料编码 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.替换后子件物料编码
		/// </summary>
		/// <value></value>
			public  System.String PostItemCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("PostItemCode");
				return value;
				}
				set
			{
				
								base.SetValue("PostItemCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换后物料版本号 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.替换后物料版本号
		/// </summary>
		/// <value></value>
			public  System.String PostItemVersionCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("PostItemVersionCode");
				return value;
				}
				set
			{
				
								base.SetValue("PostItemVersionCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换后单位 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.替换后单位
		/// </summary>
		/// <value></value>
			public  System.String PostIssueUomCode
		{
			get
			{
				System.String value  = (System.String)base.GetValue("PostIssueUomCode");
				return value;
				}
				set
			{
				
								base.SetValue("PostIssueUomCode", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换后用量 (该属性可为空,但有默认值)
		/// ECN变更记录.Misc.替换后用量
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
		/// 替换后损耗率 (该属性可为空,但有默认值)
		/// ECN变更记录.Misc.替换后损耗率
		/// </summary>
		/// <value></value>
			public  System.Decimal PostScrap
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PostScrap");
				return value;
				}
				set
			{
				
								base.SetValue("PostScrap", value);
						 
			}
		}
	



		
			/// <summary>
		/// 替换后母件底数 (该属性可为空,但有默认值)
		/// ECN变更记录.Misc.替换后母件底数
		/// </summary>
		/// <value></value>
			public  System.Decimal PostParentQty
		{
			get
			{
				System.Decimal value  = (System.Decimal)base.GetValue("PostParentQty");
				return value;
				}
				set
			{
				
								base.SetValue("PostParentQty", value);
						 
			}
		}
	



		
			/// <summary>
		/// ECN信息 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.ECN信息
		/// </summary>
		/// <value></value>
			public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo ECNInfo
		{
			get
			{
				object  obj = this.GetRelation("ECNInfo");
				if (obj == null)
				{
					return null ;
				}
				else
				{
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo value  = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo)obj;
					return value;
				 }
			}
				internal set
			{
				
				this.SetRelation("ECNInfo", value);
					 
			}
		}
	


   		private UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.EntityKey m_ECNInfoKey ;
		/// <summary>
		/// ECN信息 的Key (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.ECN信息
		/// </summary>
		/// <value></value>
		public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.EntityKey ECNInfoKey
		{
			get 
			{
				object obj = base.GetValue("ECNInfo") ;
				if (obj == null || (Int64)obj==UFSoft.UBF.PL.Tool.Constant.ID_NULL_Flag || (Int64)obj==0)
					return null ;
				Int64 key = (System.Int64)obj ;
				if (m_ECNInfoKey==null || m_ECNInfoKey.ID != key )
					m_ECNInfoKey = new UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo.EntityKey(key); 
				return m_ECNInfoKey ;
			}
			set
			{	
				if (ECNInfoKey==value)
					return ;
				this.SetRelation("ECNInfo", null);
				m_ECNInfoKey = value ;
				if (value != null) 
				{
					base.SetValue("ECNInfo",value.ID);
				}
				else
					base.SetValue("ECNInfo",UFSoft.UBF.PL.Tool.Constant.ID_NULL_Flag);
			}
		}

	

		#endregion

		#region List member						
	
		
		private UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo.EntityList m_ECNAlterMOInfo  ;
		/// <summary>
		/// ECN变更生产记录 (该属性可为空,且无默认值)
		/// ECN变更记录.Misc.ECN变更生产记录
		/// </summary>
		/// <value></value>
		public  UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo.EntityList ECNAlterMOInfo
		{
			get
			{
				if (m_ECNAlterMOInfo == null)
					m_ECNAlterMOInfo = new UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo.EntityList("ECNAlter",this,"ECNAlterMOInfo",(IList)this.GetRelation("ECNAlterMOInfo"));
				else
					m_ECNAlterMOInfo.InnerList = (IList)this.GetRelation("ECNAlterMOInfo");
				return m_ECNAlterMOInfo;
			}
		}
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
		public  static string Res_EntityNameS {	get {return EntityRes.GetResource("UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter")  ;}	}
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
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ECNDocNo")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ECNDocNo　{ get { return EntityRes.GetResource("ECNDocNo");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ECNAlterMOInfo")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ECNAlterMOInfo　{ get { return EntityRes.GetResource("ECNAlterMOInfo");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ItemMasterCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ItemMasterCode　{ get { return EntityRes.GetResource("ItemMasterCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("BOMVersionCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_BOMVersionCode　{ get { return EntityRes.GetResource("BOMVersionCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("BOMType")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_BOMType　{ get { return EntityRes.GetResource("BOMType");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PreItemCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PreItemCode　{ get { return EntityRes.GetResource("PreItemCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PreItemVersionCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PreItemVersionCode　{ get { return EntityRes.GetResource("PreItemVersionCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PreIssueUomCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PreIssueUomCode　{ get { return EntityRes.GetResource("PreIssueUomCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PreUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PreUsageQty　{ get { return EntityRes.GetResource("PreUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PreScrap")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PreScrap　{ get { return EntityRes.GetResource("PreScrap");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PreParentQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PreParentQty　{ get { return EntityRes.GetResource("PreParentQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ECNAction")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ECNAction　{ get { return EntityRes.GetResource("ECNAction");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostItemCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostItemCode　{ get { return EntityRes.GetResource("PostItemCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostItemVersionCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostItemVersionCode　{ get { return EntityRes.GetResource("PostItemVersionCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostIssueUomCode")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostIssueUomCode　{ get { return EntityRes.GetResource("PostIssueUomCode");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostUsageQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostUsageQty　{ get { return EntityRes.GetResource("PostUsageQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostScrap")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostScrap　{ get { return EntityRes.GetResource("PostScrap");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("PostParentQty")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_PostParentQty　{ get { return EntityRes.GetResource("PostParentQty");　}　}
		/// <summary>
		/// 这种已经被取消，请使用这块代码的人自己调整程序，改为引用EntityRes.GetResource("ECNInfo")的方式取资源
		/// </summary>
		[Obsolete("")]
		public string Res_ECNInfo　{ get { return EntityRes.GetResource("ECNInfo");　}　}
		#endregion 



		#region EntityResource 实体的属性名称及相应显示名称资源访问方法
		public class EntityRes
		{
			/// <summary>
			/// EntityName的名称
			/// </summary>
			public static string BE_Name { get { return "ECNAlter";　}　}
			
			/// <summary>
			/// Entity　的全名. 
			/// </summary>
			public static string BE_FullName { get { return "UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter";　}　}
		
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
			/// 属性: ECN单号 的名称
			/// </summary>
			public static string ECNDocNo　{ get { return "ECNDocNo";　}　}
				
			/// <summary>
			/// 属性: ECN变更生产记录 的名称
			/// </summary>
			public static string ECNAlterMOInfo　{ get { return "ECNAlterMOInfo";　}　}
				
			/// <summary>
			/// 属性: 物料编码 的名称
			/// </summary>
			public static string ItemMasterCode　{ get { return "ItemMasterCode";　}　}
				
			/// <summary>
			/// 属性: BOM版本号 的名称
			/// </summary>
			public static string BOMVersionCode　{ get { return "BOMVersionCode";　}　}
				
			/// <summary>
			/// 属性: BOM种类 的名称
			/// </summary>
			public static string BOMType　{ get { return "BOMType";　}　}
				
			/// <summary>
			/// 属性: 替换前子件物料编码 的名称
			/// </summary>
			public static string PreItemCode　{ get { return "PreItemCode";　}　}
				
			/// <summary>
			/// 属性: 替换前物料版本号 的名称
			/// </summary>
			public static string PreItemVersionCode　{ get { return "PreItemVersionCode";　}　}
				
			/// <summary>
			/// 属性: 替换前单位 的名称
			/// </summary>
			public static string PreIssueUomCode　{ get { return "PreIssueUomCode";　}　}
				
			/// <summary>
			/// 属性: 替换前用量 的名称
			/// </summary>
			public static string PreUsageQty　{ get { return "PreUsageQty";　}　}
				
			/// <summary>
			/// 属性: 替换前损耗率 的名称
			/// </summary>
			public static string PreScrap　{ get { return "PreScrap";　}　}
				
			/// <summary>
			/// 属性: 替换前母件底数 的名称
			/// </summary>
			public static string PreParentQty　{ get { return "PreParentQty";　}　}
				
			/// <summary>
			/// 属性: ECN事件 的名称
			/// </summary>
			public static string ECNAction　{ get { return "ECNAction";　}　}
				
			/// <summary>
			/// 属性: 替换后子件物料编码 的名称
			/// </summary>
			public static string PostItemCode　{ get { return "PostItemCode";　}　}
				
			/// <summary>
			/// 属性: 替换后物料版本号 的名称
			/// </summary>
			public static string PostItemVersionCode　{ get { return "PostItemVersionCode";　}　}
				
			/// <summary>
			/// 属性: 替换后单位 的名称
			/// </summary>
			public static string PostIssueUomCode　{ get { return "PostIssueUomCode";　}　}
				
			/// <summary>
			/// 属性: 替换后用量 的名称
			/// </summary>
			public static string PostUsageQty　{ get { return "PostUsageQty";　}　}
				
			/// <summary>
			/// 属性: 替换后损耗率 的名称
			/// </summary>
			public static string PostScrap　{ get { return "PostScrap";　}　}
				
			/// <summary>
			/// 属性: 替换后母件底数 的名称
			/// </summary>
			public static string PostParentQty　{ get { return "PostParentQty";　}　}
				
			/// <summary>
			/// 属性: ECN信息 的名称
			/// </summary>
			public static string ECNInfo　{ get { return "ECNInfo";　}　}
		
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
			this.exdMultiLangAttrs.Add("ECNDocNo","ECNDocNo");
			this.exdMultiLangAttrs.Add("ItemMasterCode","ItemMasterCode");
			this.exdMultiLangAttrs.Add("BOMVersionCode","BOMVersionCode");
			this.exdMultiLangAttrs.Add("BOMType","BOMType");
			this.exdMultiLangAttrs.Add("PreItemCode","PreItemCode");
			this.exdMultiLangAttrs.Add("PreItemVersionCode","PreItemVersionCode");
			this.exdMultiLangAttrs.Add("PreIssueUomCode","PreIssueUomCode");
			this.exdMultiLangAttrs.Add("PreUsageQty","PreUsageQty");
			this.exdMultiLangAttrs.Add("PreScrap","PreScrap");
			this.exdMultiLangAttrs.Add("PreParentQty","PreParentQty");
			this.exdMultiLangAttrs.Add("ECNAction","ECNAction");
			this.exdMultiLangAttrs.Add("PostItemCode","PostItemCode");
			this.exdMultiLangAttrs.Add("PostItemVersionCode","PostItemVersionCode");
			this.exdMultiLangAttrs.Add("PostIssueUomCode","PostIssueUomCode");
			this.exdMultiLangAttrs.Add("PostUsageQty","PostUsageQty");
			this.exdMultiLangAttrs.Add("PostScrap","PostScrap");
			this.exdMultiLangAttrs.Add("PostParentQty","PostParentQty");
			this.exdMultiLangAttrs.Add("ECNInfo","ECNInfo");
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
		private void DeSerializeKey(ECNAlterData data)
		{
		
			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			

			
	
			//Entity中没有EntityKey集合，不用处理。
		}
		
		#endregion 	
        public override void FromEntityData(UFSoft.UBF.Business.DataTransObjectBase dto)
        {
			ECNAlterData data = dto as ECNAlterData ;
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
		public void FromEntityData(ECNAlterData data)
		{
			this.FromEntityData(data,new Hashtable());
		}
		//used by ubf..
		public void FromEntityData(ECNAlterData data,IDictionary dict)
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
		
								this.SetTypeValue("ECNDocNo",data.ECNDocNo);
		
								this.SetTypeValue("ItemMasterCode",data.ItemMasterCode);
		
								this.SetTypeValue("BOMVersionCode",data.BOMVersionCode);
		
								this.SetTypeValue("BOMType",data.BOMType);
		
								this.SetTypeValue("PreItemCode",data.PreItemCode);
		
								this.SetTypeValue("PreItemVersionCode",data.PreItemVersionCode);
		
								this.SetTypeValue("PreIssueUomCode",data.PreIssueUomCode);
		
								this.SetTypeValue("PreUsageQty",data.PreUsageQty);
		
								this.SetTypeValue("PreScrap",data.PreScrap);
		
								this.SetTypeValue("PreParentQty",data.PreParentQty);
		
								this.SetTypeValue("ECNAction",data.ECNAction);
		
								this.SetTypeValue("PostItemCode",data.PostItemCode);
		
								this.SetTypeValue("PostItemVersionCode",data.PostItemVersionCode);
		
								this.SetTypeValue("PostIssueUomCode",data.PostIssueUomCode);
		
								this.SetTypeValue("PostUsageQty",data.PostUsageQty);
		
								this.SetTypeValue("PostScrap",data.PostScrap);
		
								this.SetTypeValue("PostParentQty",data.PostParentQty);
		
			#endregion 

			#region 组件内属性
	
					if (data.ECNAlterMOInfo != null)
			{	
				foreach(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData obj in data.ECNAlterMOInfo )
				{
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo child = dict[obj] as UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo;
					if (child == null)
					{
						if (obj.ID>0)
						{
							if (obj.SysState != UFSoft.UBF.PL.Engine.ObjectState.Inserted)
								child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo)(new UFSoft.UBF.Business.BusinessEntity.EntityKey(obj.ID,obj.SysEntityType).GetEntity());
							if (child==null) child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo)UFSoft.UBF.Business.Entity.CreateTransientObjWithKey(obj.SysEntityType,this,obj.ID,true) ;
						}
						else
						{
							 child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo)UFSoft.UBF.Business.Entity.CreateTransientObjWithKey(obj.SysEntityType,this,null,true) ;
						}
						
						child.FromEntityData(obj,dict);
					}
					if (child.SysState == UFSoft.UBF.PL.Engine.ObjectState.Deleted)
					{
						this.ECNAlterMOInfo.Remove(child);
						this.ECNAlterMOInfo.DelLists.Add(child);
					}
					else
						this.ECNAlterMOInfo.Add(child);
				}
			}
	     

					if (data.ECNInfo!=null)
			{
				UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo child = dict[data.ECNInfo] as UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo ;
				if (child == null)
				{
					if (data.ECNInfo.ID>0)
					{
						if (data.ECNInfo.SysState != UFSoft.UBF.PL.Engine.ObjectState.Inserted)
							child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo)(new UFSoft.UBF.Business.BusinessEntity.EntityKey(data.ECNInfo.ID,data.ECNInfo.SysEntityType).GetEntity());
						if (child==null) child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo)UFSoft.UBF.Business.Entity.CreateTransientObjWithKey(data.ECNInfo.SysEntityType,null,data.ECNInfo.ID,true) ;
					}
					else
					{
 						child = (UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo)UFSoft.UBF.Business.Entity.CreateTransientObjWithKey(data.ECNInfo.SysEntityType,null,null,true) ;				
 					}
					
					child.FromEntityData(data.ECNInfo,dict);
				}
				this.ECNInfo = child ;
			}
	     

			#endregion 
			this.NeedPersistable = m_isNeedPersistable ;
			dict[data] = this;
		}

		/// <summary>
		/// Create EntityData From Entity
		/// </summary>
		public ECNAlterData ToEntityData()
		{
			return ToEntityData(null,null);
		}
		/// <summary>
		/// Create EntityData From Entity - used by ubf 
		/// </summary>
		public ECNAlterData ToEntityData(ECNAlterData data, IDictionary dict){
			if (data == null)
				data = new ECNAlterData();
			
			if (dict == null ) dict = new Hashtable() ;
			//就直接用ID,如果不同实体会出现相同ID，则到时候要改进。? ID一定要有。
			dict["UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlter"+this.ID.ToString()] = data;
		
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
				object obj =this.GetValue("ECNDocNo");
				if (obj != null)
					data.ECNDocNo=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ItemMasterCode");
				if (obj != null)
					data.ItemMasterCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("BOMVersionCode");
				if (obj != null)
					data.BOMVersionCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("BOMType");
				if (obj != null)
					data.BOMType=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PreItemCode");
				if (obj != null)
					data.PreItemCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PreItemVersionCode");
				if (obj != null)
					data.PreItemVersionCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PreIssueUomCode");
				if (obj != null)
					data.PreIssueUomCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PreUsageQty");
				if (obj != null)
					data.PreUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PreScrap");
				if (obj != null)
					data.PreScrap=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PreParentQty");
				if (obj != null)
					data.PreParentQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("ECNAction");
				if (obj != null)
					data.ECNAction=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostItemCode");
				if (obj != null)
					data.PostItemCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostItemVersionCode");
				if (obj != null)
					data.PostItemVersionCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostIssueUomCode");
				if (obj != null)
					data.PostIssueUomCode=(System.String)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostUsageQty");
				if (obj != null)
					data.PostUsageQty=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostScrap");
				if (obj != null)
					data.PostScrap=(System.Decimal)obj;
			}
	     
	    
			{
				object obj =this.GetValue("PostParentQty");
				if (obj != null)
					data.PostParentQty=(System.Decimal)obj;
			}
	     
			#endregion 

			#region 组件内属性 -Entity,"复杂值对象",枚举,实体集合.
	
			if (this.ECNAlterMOInfo != null)
			{	
				List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData> listECNAlterMOInfo = new List<UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData>();
				//必然要访问集合中实体。没办法直接去取实体里面的ID。
				foreach(UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo obj in this.ECNAlterMOInfo ){
					if (obj == null)
						continue;
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData old = dict["UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfo"+obj.ID.ToString()] as UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNAlterMOInfoData;
					listECNAlterMOInfo.Add((old != null) ? old : obj.ToEntityData(null, dict));
				}
				data.ECNAlterMOInfo = listECNAlterMOInfo;
			}	
			{
				object oID = this.GetValue("ECNInfo");
				if (oID != null && (Int64)oID > 0 )
				{
					UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfoData _ECNInfo = dict["UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfo"+oID.ToString()] as UFIDA.U9.Safor.VW.PLMBE.ECNAlterRequestBE.ECNInfoData;			
					data.ECNInfo = (_ECNInfo != null) ? _ECNInfo : (this.ECNInfo==null?null:this.ECNInfo.ToEntityData(null,dict));
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