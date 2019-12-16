﻿







namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.Runtime.Serialization;
	using System.IO;
	using UFSoft.UBF.Util.Context;
	using UFSoft.UBF;
	using UFSoft.UBF.Exceptions;
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
        System.String Do(IContext context ,out IList<MessageBase> outMessages ,System.String eCNAlterInfo, System.String contextInfo);
    }

    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class QueryPLMECNStub : ServiceStubBase, IQueryPLMECN
    {
        #region IQueryPLMECN Members

        //[OperationBehavior]
        public System.String Do(IContext context ,out IList<MessageBase> outMessages, System.String eCNAlterInfo, System.String contextInfo)
        {
			
			ICommonDataContract commonData = CommonDataContractFactory.GetCommonData(context, out outMessages);
			return DoEx(commonData, eCNAlterInfo, contextInfo);
        }
        
        //[OperationBehavior]
        public System.String DoEx(ICommonDataContract commonData, System.String eCNAlterInfo, System.String contextInfo)
        {
			this.CommonData = commonData ;
            try
            {
                BeforeInvoke("UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.QueryPLMECN");                
                QueryPLMECN objectRef = new QueryPLMECN();
		
				objectRef.ECNAlterInfo = eCNAlterInfo;
				objectRef.ContextInfo = contextInfo;

				//处理返回类型.
				System.String result = objectRef.Do();
				return result ;
						return result;

	        }
			catch (System.Exception e)
            {
				DealException(e);
				throw;
            }
            finally
            {
				FinallyInvoke("UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.QueryPLMECN");
            }
        }
	#endregion
    }
}