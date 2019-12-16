[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Name="UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV", Namespace="http://www.UFIDA.org", ConfigurationName="UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSV")]
public interface UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSV
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV/Do", ReplyAction="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV/DoRespo" +
        "nse")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV/DoServi" +
        "ceExceptionDetailFault", Name="ServiceExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceLostException), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV/DoServi" +
        "ceLostExceptionFault", Name="ServiceLostException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.Service.ServiceException), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV/DoServi" +
        "ceExceptionFault", Name="ServiceException", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF.Service")]
    [System.ServiceModel.FaultContractAttribute(typeof(UFSoft.UBF.ExceptionBase), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV/DoExcep" +
        "tionBaseFault", Name="ExceptionBase", Namespace="http://schemas.datacontract.org/2004/07/UFSoft.UBF")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.Exception), Action="http://www.UFIDA.org/UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV/DoExcep" +
        "tionFault", Name="Exception", Namespace="http://schemas.datacontract.org/2004/07/System")]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<object, object>))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.EntityNotExistException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.BusinessException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttrsContainerException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Business.AttributeInValidException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ExceptionBase.FormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.UnknownException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorDescriptor))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorLevel))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.ErrorMessage[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBase))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBase[]))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.ServiceModel.ExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceExceptionDetail))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceLostException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Service.ServiceException))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Exceptions.MessageBaseFormatState))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ThreadContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.ApplicationContext))]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(UFSoft.UBF.Util.Context.PlatformContext))]
    string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string itemInfo, string contextInfo, string itemModule);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVChannel : UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSV, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient : System.ServiceModel.ClientBase<UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSV>, UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSV
{
    
    public UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient()
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string Do(out UFSoft.UBF.Exceptions.MessageBase[] outMessages, object context, string itemInfo, string contextInfo, string itemModule)
    {
        return base.Channel.Do(out outMessages, context, itemInfo, contextInfo, itemModule);
    }
}
