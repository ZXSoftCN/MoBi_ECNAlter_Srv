[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Name="UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV", Namespace="http://www.UFIDA.org", ConfigurationName="UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSV")]
public interface UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSV
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV/Do", ReplyAction="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV/DoResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV/DoExceptionFau" +
        "lt", Name="Exception", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV/DoServiceLostE" +
        "xceptionFault", Name="ServiceLostException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV/DoServiceExcep" +
        "tionFault", Name="ServiceException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV/DoServiceExcep" +
        "tionDetailFault", Name="ServiceExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV/DoExceptionBas" +
        "eFault", Name="ExceptionBase", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.BusinessException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttrsContainerException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttributeInValidException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.EntityNotExistException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBase[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
    string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string bOMInfo, string contextInfo);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVChannel : UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSV, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient : System.ServiceModel.ClientBase<UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSV>, UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSV
{
    
    public UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient()
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string bOMInfo, string contextInfo)
    {
        return base.Channel.Do(out outMessages, context, bOMInfo, contextInfo);
    }
}
