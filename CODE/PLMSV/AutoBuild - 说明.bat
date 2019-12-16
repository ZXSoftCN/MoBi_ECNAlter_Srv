
copy .\BpImplement\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.Deploy.dll  D:\UFIDA\U9V25\Porta\ApplicationLib
copy .\BpImplement\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.Deploy.pdb  D:\UFIDA\U9V25\Porta\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.Agent.dll  D:\UFIDA\U9V25\Porta\ApplicationLib
copy .\BpAgent\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.Agent.pdb  D:\UFIDA\U9V25\Porta\ApplicationLib

copy .\BpImplement\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.Deploy.dll  D:\UFIDA\U9V25\Porta\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.Deploy.pdb  D:\UFIDA\U9V25\Porta\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.dll  D:\UFIDA\U9V25\Porta\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.pdb  D:\UFIDA\U9V25\Porta\ApplicationServer\Libs
copy .\BpImplement\bin\Debug\UFIDA.U9.Safor.VW.PLMSV.ubfsvc  D:\UFIDA\U9V25\Porta\ApplicationServer\Libs


copy .\BpImplement\UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNWHQuery.svc  D:\UFIDA\U9V25\Porta\Services
copy .\BpImplement\UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery.svc  D:\UFIDA\U9V25\Porta\Services
copy .\BpImplement\UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN.svc  D:\UFIDA\U9V25\Porta\Services
copy .\BpImplement\UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.IQueryPLMECN.svc  D:\UFIDA\U9V25\Porta\Services
copy .\BpImplement\UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV.IModifyMOPickList.svc  D:\UFIDA\U9V25\Porta\Services
copy .\BpImplement\UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV.IModifyBOMMater.svc  D:\UFIDA\U9V25\Porta\Services

echo 请手工将该bat文件打开，将下面这段内容与D:\UFIDA\U9V25\Porta\RestServices\web.config进行合并。
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="basicHttpBinding" contract="{type.Namespace.FullName}.IECNWHQuery" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="basicHttpBinding" contract="{type.Namespace.FullName}.IECNMOQuery" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="basicHttpBinding" contract="{type.Namespace.FullName}.ICreatePLMECN" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="basicHttpBinding" contract="{type.Namespace.FullName}.IQueryPLMECN" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="basicHttpBinding" contract="{type.Namespace.FullName}.IModifyMOPickList" /> 
	</service>
	<service name="{type.FullName}Stub"  behaviorConfiguration="U9SrvTypeBehaviors">
		<endpoint address="" behaviorConfiguration="U9RestSrvBehaviors" binding="basicHttpBinding" contract="{type.Namespace.FullName}.IModifyBOMMater" /> 
	</service>


pause