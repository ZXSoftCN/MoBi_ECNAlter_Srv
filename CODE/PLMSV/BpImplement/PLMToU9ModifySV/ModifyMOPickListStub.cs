﻿







namespace UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV
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

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UFIDA.org", Name="UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV.IModifyMOPickList")]
    public interface IModifyMOPickList
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
        System.String Do(IContext context ,out IList<MessageBase> outMessages ,System.String pLMECNInfo, System.String contextInfo);
    }

    [UFSoft.UBF.Service.ServiceImplement]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ModifyMOPickListStub : ServiceStubBase, IModifyMOPickList
    {
        #region IModifyMOPickList Members

        //[OperationBehavior]
        public System.String Do(IContext context ,out IList<MessageBase> outMessages, System.String pLMECNInfo, System.String contextInfo)
        {
			
			ICommonDataContract commonData = CommonDataContractFactory.GetCommonData(context, out outMessages);
			return DoEx(commonData, pLMECNInfo, contextInfo);
        }
        
        //[OperationBehavior]
        public System.String DoEx(ICommonDataContract commonData, System.String pLMECNInfo, System.String contextInfo)
        {
			this.CommonData = commonData ;
            try
            {
                BeforeInvoke("UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV.ModifyMOPickList");                
                ModifyMOPickList objectRef = new ModifyMOPickList();
		
				objectRef.PLMECNInfo = pLMECNInfo;
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
				FinallyInvoke("UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV.ModifyMOPickList");
            }
        }
	#endregion
    }
}
