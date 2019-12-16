

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Name="UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery", Namespace="http://www.UFIDA.org", ConfigurationName="UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQuery")]
public interface UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQuery
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery/Do", ReplyAction="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery/DoResponse" +
        "")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery/DoServiceL" +
        "ostExceptionFault", Name="ServiceLostException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery/DoServiceE" +
        "xceptionFault", Name="ServiceException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery/DoServiceE" +
        "xceptionDetailFault", Name="ServiceExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery/DoExceptio" +
        "nBaseFault", Name="ExceptionBase", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery/DoExceptio" +
        "nFault", Name="Exception", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.BusinessException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttrsContainerException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttributeInValidException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.EntityNotExistException))]
    string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string bOMItemInfo, string contextInfo);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryChannel : UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQuery, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient : System.ServiceModel.ClientBase<UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQuery>, UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQuery
{
    
    public UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient()
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string bOMItemInfo, string contextInfo)
    {
        return base.Channel.Do(out outMessages, context, bOMItemInfo, contextInfo);
    }
}
