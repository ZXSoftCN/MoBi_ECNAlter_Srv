
echo reset IIS
echo iisreset

echo beging copy componet dll to portal and appserver

copy .\Entity\bin\Debug\UFIDA.U9.Safor.VW.PLMBE.Deploy.dll  E:\yonyou\U9V30\Portal\ApplicationLib
copy .\Entity\bin\Debug\UFIDA.U9.Safor.VW.PLMBE.Deploy.pdb  E:\yonyou\U9V30\Portal\ApplicationLib

copy .\Entity\bin\Debug\UFIDA.U9.Safor.VW.PLMBE.dll  E:\yonyou\U9V30\Portal\ApplicationServer\Libs

copy .\Entity\bin\Debug\UFIDA.U9.Safor.VW.PLMBE.pdb  E:\yonyou\U9V30\Portal\ApplicationServer\Libs

copy .\Entity\bin\Debug\UFIDA.U9.Safor.VW.PLMBE.Deploy.dll  E:\yonyou\U9V30\Portal\ApplicationServer\Libs

copy .\Entity\bin\Debug\UFIDA.U9.Safor.VW.PLMBE.Deploy.pdb  E:\yonyou\U9V30\Portal\ApplicationServer\Libs



echo begin run build component Script
echo DIR1: .\..\..\SQL\\Unconfiged\MetadataScript\
echo DIR2: .\..\..\SQL\\Unconfiged\DBScript\
echo .\..\..\..\..\..\..\..\yonyou\UBFV28\U9.VOB.Product.UBF\UBFStudio2.8\Runtime\\..\DBScriptExecutor.exe -connStr "User Id=sa;Password=as;Data Source=LEOWORKCENTRE;Initial Catalog=U9V30;packet size=4096;Max Pool size=1500;persist security info=True" -NotDropDB -NotWriteLog -ExecuteDelete .\..\..\..\..\MyProject\摩比\二期(ECN对接项目)\项目管理\Dev\SQL\\Unconfiged\MetadataScript\ .\..\..\..\..\MyProject\摩比\二期(ECN对接项目)\项目管理\Dev\SQL\\Unconfiged\DBScript\

echo componet  buid end
pause

