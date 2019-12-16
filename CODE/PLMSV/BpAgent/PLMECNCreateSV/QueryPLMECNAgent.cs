








namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.Proxy
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.IO;
	using System.ServiceModel;
	using System.Runtime.Serialization;
	using UFSoft.UBF;
	using UFSoft.UBF.Exceptions;
	using UFSoft.UBF.Util.Context;
	using UFSoft.UBF.Service;
	using UFSoft.UBF.Service.Base ;

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UFIDA.org", Name="UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.IQueryPLMECN")]
    public interface IQueryPLMECN
    {
		[ServiceKnownType(typeof(ApplicationContext))]
		[ServiceKnownType(typeof(PlatformContext))]
		[ServiceKnownType(typeof(ThreadContext))]
		[ServiceKnownType(typeof( UFSoft.UBF.Business.BusinessException))]
		[ServiceKnownType(typeof( UFSoft.UBF.Business.EntityNotExistException))]
		[ServiceKnownType(typeof( UFSoft.UBF.Business.AttributeInValidException))]
		[ServiceKnownType(typeof(UFSoft.UBF.Business.AttrsContainerException))]
		[ServiceKnownType(typeof(UFSoft.UBF.Exceptions.MessageBase))]
			[FaultContract(typeof(UFSoft.UBF.Service.ServiceLostException))]
		[FaultContract(typeof(UFSoft.UBF.Service.ServiceException))]
		[FaultContract(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
		[FaultContract(typeof(ExceptionBase))]
		[FaultContract(typeof(Exception))]
		[OperationContract()]
		System.String Do(IContext context, out IList<MessageBase> outMessages ,System.String eCNAlterInfo, System.String contextInfo);
    }
	[Serializable]    
    public class QueryPLMECNProxy : ServiceProxyBase//, UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.Proxy.IQueryPLMECN
    {
	#region Fields	
				private System.String eCNAlterInfo ;
						private System.String contextInfo ;
			
	#endregion	
		
	#region Properties
	
				

		/// <summary>
		/// ECN变更对比查询 (该属性可为空,且无默认值)
		/// ECN变更纪录对比查询.Misc.ECN变更对比查询
		/// </summary>
		/// <value>System.String</value>
		public System.String ECNAlterInfo
		{
			get	
			{	
				return this.eCNAlterInfo;
			}

			set	
			{	
				this.eCNAlterInfo = value;	
			}
		}		
						

		/// <summary>
		/// 执行上下文 (该属性可为空,且无默认值)
		/// ECN变更纪录对比查询.Misc.执行上下文
		/// </summary>
		/// <value>System.String</value>
		public System.String ContextInfo
		{
			get	
			{	
				return this.contextInfo;
			}

			set	
			{	
				this.contextInfo = value;	
			}
		}		
			
	#endregion	


	#region Constructors
        public QueryPLMECNProxy()
        {
        }
        #endregion
        
        #region 跨site调用
        public System.String Do(string targetSite)
        {
  			InitKeyList() ;
			System.String result = (System.String)InvokeBySite<UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.Proxy.IQueryPLMECN>(targetSite);
			return GetRealResult(result);
        }
        #endregion end跨site调用

		#region 跨组织调用
        public System.String Do(long targetOrgId)
        {
  			InitKeyList() ;
			System.String result = (System.String)InvokeByOrg<UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.Proxy.IQueryPLMECN>(targetOrgId);
			return GetRealResult(result);
        }
		#endregion end跨组织调用

		#region Public Method
		
        public System.String Do()
        {
  			InitKeyList() ;
 			System.String result = (System.String)InvokeAgent<UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.Proxy.IQueryPLMECN>();
			return GetRealResult(result);
        }
        
		protected override object InvokeImplement<T>(T oChannel)
        {
			IContext context = ContextManager.Context;			

            IQueryPLMECN channel = oChannel as IQueryPLMECN;
            if (channel != null)
            {
				return channel.Do(context, out returnMsgs, eCNAlterInfo, contextInfo);
	    }
            return  null;
        }
		#endregion
		
		//处理由于序列化导致的返回值接口变化，而进行返回值的实际类型转换处理．
		private System.String GetRealResult(System.String result)
		{

				return result ;
		}
		#region  Init KeyList 
		//初始化SKey集合--由于接口不一样.BP.SV都要处理
		private void InitKeyList()
		{
			System.Collections.Hashtable dict = new System.Collections.Hashtable() ;
										
		}
		#endregion 

    }
}



