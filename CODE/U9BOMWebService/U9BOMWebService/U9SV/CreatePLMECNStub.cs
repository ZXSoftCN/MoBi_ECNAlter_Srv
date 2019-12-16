

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Name="UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN", Namespace="http://www.UFIDA.org", ConfigurationName="UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECN")]
public interface UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECN
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN/Do", ReplyAction="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN/DoRespo" +
        "nse")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN/DoServi" +
        "ceLostExceptionFault", Name="ServiceLostException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN/DoServi" +
        "ceExceptionFault", Name="ServiceException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN/DoServi" +
        "ceExceptionDetailFault", Name="ServiceExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN/DoExcep" +
        "tionBaseFault", Name="ExceptionBase", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action="http://www.UFIDA.org/UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN/DoExcep" +
        "tionFault", Name="Exception", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
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
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBase[]))]
    string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string eCNAlterRequest, string contextInfo);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNChannel : UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECN, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient : System.ServiceModel.ClientBase<UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECN>, UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECN
{
    
    public UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient()
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string eCNAlterRequest, string contextInfo)
    {
        return base.Channel.Do(out outMessages, context, eCNAlterRequest, contextInfo);
    }
}
