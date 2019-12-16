using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using log4net;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel;
using UFIDA.U9.Cust.VW.PLM.BOMCommonSV;
using MyMVC;
using System.Xml.XPath;


namespace U9BOMWebService
{
    /// <summary>
    /// BOMCommon 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BOMCommon : System.Web.Services.WebService
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static string strConfig = AppDomain.CurrentDomain.BaseDirectory + "config.xml";
        
        [WebMethod]
        public string BaseDirectory()
        {
            return strConfig;
        }

        [WebMethod]
        public string debug()
        {
            string strItemModuleCode = string.Empty; 
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strConfig);

            XmlNodeList lstNode = xmlDoc.GetElementsByTagName("ItemModuleInfo");
            if(lstNode.Count > 0)
            {
                XmlNode xNodeItem = xmlDoc.GetElementsByTagName("ItemModuleInfo")[0];
                if(xNodeItem.Attributes.Count > 0)
                {
                    strItemModuleCode = xNodeItem.Attributes[0].Value;
                }
            }
            return strItemModuleCode;
        }

        [WebMethod(Description = "PLM对U9料品接口服务", BufferResponse = true, CacheDuration = 10)]
        public string ModifyU9ItemMasterSV(string _itemInfo)
        {
            string strResult = string.Empty;
            System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            string remoteAddress = GetU9SVURI(contextInfo, "InsertItemMaster");

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient client = new UFIDAU9CustVWPLMBOMCommonSVIInsertItemMasterSVClient(binding, endpoint);
            //UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient client = new UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient();
            UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(contextInfo);
            UFSoft.UBF.Exceptions.MessageBase[] msg = null;

            #region 测试用
            ItemInfo itemInfo = new ItemInfo();
            itemInfo.ItemMasters = new List<ItemMasterData>();
            ItemMasterData newData = new ItemMasterData();
            newData.ItemCode = "A001";
            newData.ItemName = "abc";
            itemInfo.ItemMasters.Add(newData);
            string strSerial = XmlHelper.XmlSerialize(itemInfo, Encoding.UTF8);

            if (string.IsNullOrEmpty(_itemInfo))
            {
                //_itemInfo = "<ItemInfo><ItemMasters><ItemMaster Effective=\"false\" ItemCode=\"3-DL-00-00-003\" ItemName=\"物料名称\" ItemForm=\"0\" VersionCode=\"A0.2\" Specs=\"规格\" UOMCode=\"118\" ItemFormAttribute=\"MakePart\" ItemProperty1=\"扩展属性1\" ItemProperty2=\"扩展属性xiugai2222\"></ItemMaster></ItemMasters></ItemInfo>";
                _itemInfo = "<ItemInfo><ItemMasters><ItemMaster Effective=\"false\" ItemCode=\"01010101-100\" ItemName=\"物料名称\" ItemForm=\"2001\" Specs=\"规格\" UOMCode=\"118\" ItemFormAttribute=\"MakePart\"></ItemMaster></ItemMasters></ItemInfo>";
            }
            
            #endregion
            try
            {
                strResult = client.Do(out msg, context, _itemInfo, contextInfoString, ItemModuleCode);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

            return strResult;
        }

        [WebMethod(Description = "PLM对接U9BOM服务", BufferResponse = true, CacheDuration = 10)]
        public string ModifyU9BOMSV(string _bominfo)
        {
            string strResult = string.Empty;
            System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            string remoteAddress = GetU9SVURI(contextInfo, "ModifyBOM");

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient client = new UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient(binding, endpoint);
            //UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient client = new UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient();
            UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(contextInfo);
            UFSoft.UBF.Exceptions.MessageBase[] msg = null;

            #region 测试用
            if (string.IsNullOrEmpty(_bominfo))
            {
                //_bominfo = "<BOMInfo><Masters><BOMMaster ItemMasterCode=\"8-AJ-00-00-011\" ItemVersionCode=\"\" BOMVersionCode=\"A4.0\" BOMType=\"1\" Explain=\"描述备注\"><Components><Component ItemCode=\"3-DL-00-00-004\" ItemVersionCode=\"A1.0\" IssueUomCode=\"ml\" UsageQty=\"2\" Scrap=\"0\" ParentQty=\"1\" IsPhantomPart=\"false\" Remark=\"备注\"></Component></Components></Masters></BOMInfo>";
                _bominfo = "<BOMInfo><Masters><BOMMaster ItemMasterCode=\"T-DA-01-10-004\" BOMVersionCode=\"A1.0\" ItemVersionCode=\"A1.0\" BOMType=\"0\" Explain=\"00\"><Components><Component ItemCode=\"3-JS-TA-10-730\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"3-JS-T8-04-988\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-TD-10-142\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"2-01-01-41-039\" IssueUomCode=\"PCS\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-133\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-989\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"3.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-TA-10-727\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"2-04-81-41-049\" IssueUomCode=\"each\" UsageQty=\"12.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-157\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-887\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-TA-10-733\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"2-09-18-41-030\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-TB-10-176\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"A-BQ-00-00-525\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-TA-10-720\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"2-03-26-41-001\" IssueUomCode=\"PCS\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-122\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-06-01-008\" IssueUomCode=\"m\" UsageQty=\"3.500000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-51-12-00-034\" IssueUomCode=\"each\" UsageQty=\"9.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-16-01-00-040\" ItemVersionCode=\"V1.2\" IssueUomCode=\"each\" UsageQty=\"10.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-12-00-072\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-123\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-140\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-09-00-406\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-07-01-496\" IssueUomCode=\"PCS\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-90-94-91-005\" IssueUomCode=\"each\" UsageQty=\"9.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-12-416\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-56-04-00-067\" IssueUomCode=\"PCS\" UsageQty=\"9.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-125\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-116\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-27-12-00-027\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-124\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-02-30-00-015\" IssueUomCode=\"kilograms\" UsageQty=\"0.006000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-16-01-00-055\" ItemVersionCode=\"V1.2\" IssueUomCode=\"each\" UsageQty=\"14.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-07-01-001\" IssueUomCode=\"PCS\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T6-00-056\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-09-18-41-040\" IssueUomCode=\"each\" UsageQty=\"12.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-72-03-00-033\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-121\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-06-02-004\" IssueUomCode=\"meters\" UsageQty=\"2.600000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-189\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"20.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-04-81-41-065\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-109\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-74-04-00-011\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-64-12-00-005\" IssueUomCode=\"each\" UsageQty=\"3.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-139\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-64-04-00-030\" IssueUomCode=\"each\" UsageQty=\"9.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-L1-00-327\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-11-00-083\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-PB-00-01-668\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-PB-00-01-669\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-138\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-136\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-00-00-069\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"6.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-137\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-02-878\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-64-04-00-029\" IssueUomCode=\"each\" UsageQty=\"8.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-616\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-12-00-074\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-06-04-009\" IssueUomCode=\"each\" UsageQty=\"60.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-67-08-00-005\" IssueUomCode=\"each\" UsageQty=\"8.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-12-00-087\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-731\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"22.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-108\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-TB-10-177\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"3-FJ-TB-10-175\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"8-18-06-13-107\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-TY-00-00-093\" ItemVersionCode=\"V1.6\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-186\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-130\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-187\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-131\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-TF-10-158\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"2-09-07-41-004\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-185\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-468\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-188\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-182\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"14.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-TA-10-732\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"6.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"8-18-06-13-128\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-TA-10-716\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"3-JS-T8-04-151\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-132\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-01-461\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"6.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-135\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-G1-00-399\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-142\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-09-18-41-021\" IssueUomCode=\"each\" UsageQty=\"12.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-01-602\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-11-866\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"28.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-00-136\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-159\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-07-06-00-187\" IssueUomCode=\"PCS\" UsageQty=\"16.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-11-876\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"28.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-TY-00-00-137\" ItemVersionCode=\"V1.1\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-192\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-115\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-158\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-114\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-TD-10-143\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\"/><Component ItemCode=\"3-FJ-T1-00-135\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-NC-00-01-196\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-141\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-07-01-41-009\" IssueUomCode=\"PCS\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-150\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"20.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-04-01-001\" IssueUomCode=\"PCS\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-148\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"14.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-16-01-00-044\" ItemVersionCode=\"V1.2\" IssueUomCode=\"each\" UsageQty=\"10.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-04-81-41-057\" IssueUomCode=\"each\" UsageQty=\"10.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-12-397\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-68-01-00-002\" IssueUomCode=\"PCS\" UsageQty=\"60.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-12-417\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-HA-01-00-026\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-19-06-00-505\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-02-01-01-100\" IssueUomCode=\"g\" UsageQty=\"75.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-68-02-00-053\" IssueUomCode=\"PCS\" UsageQty=\"150.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-02-02-01-051\" IssueUomCode=\"kilograms\" UsageQty=\"0.053700\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-72-03-00-024\" IssueUomCode=\"each\" UsageQty=\"8.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-09-18-41-022\" IssueUomCode=\"each\" UsageQty=\"108.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-120\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-03-01-41-002\" IssueUomCode=\"PCS\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-160\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-113\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-12-00-075\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-54-00-00-002\" IssueUomCode=\"PCS\" UsageQty=\"104.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-183\" ItemVersionCode=\"A2.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-24-01-00-044\" ItemVersionCode=\"V1.1\" IssueUomCode=\"each\" UsageQty=\"8.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-T8-04-795\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-129\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-565\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-01-01-00-079\" ItemVersionCode=\"V1.2\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-02-609\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-24-01-00-045\" ItemVersionCode=\"V1.1\" IssueUomCode=\"each\" UsageQty=\"28.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-04-54-41-004\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-NC-00-01-444\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-JS-TG-10-027\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-NC-00-01-445\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-07-06-599\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-118\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"C-01-01-00-001\" IssueUomCode=\"zhang\" UsageQty=\"5.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-119\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-TY-00-00-126\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-TY-00-00-135\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-FJ-T1-00-693\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-TY-00-00-113\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-11-00-098\" IssueUomCode=\"each\" UsageQty=\"10.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-TY-50-00-014\" ItemVersionCode=\"V1.1\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-112\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-51-09-00-013\" IssueUomCode=\"each\" UsageQty=\"14.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-111\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-110\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-127\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-NC-00-01-195\" ItemVersionCode=\"A1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"3-70-12-00-086\" IssueUomCode=\"each\" UsageQty=\"10.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"2-07-08-41-026\" IssueUomCode=\"PCS\" UsageQty=\"4.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-134\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-07-01-007\" IssueUomCode=\"PCS\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-12-398\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-07-06-602\" IssueUomCode=\"each\" UsageQty=\"1.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-117\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"A-01-07-06-081\" IssueUomCode=\"each\" UsageQty=\"8.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/><Component ItemCode=\"8-18-06-13-126\" ItemVersionCode=\"V1.0\" IssueUomCode=\"each\" UsageQty=\"2.000000\" ParentQty=\"1\" IsPhantomPart=\"false\" Scrap=\"\"/></Components></BOMMaster></Masters></BOMInfo>";
            }
            BOMInfo bominfoAll = new BOMInfo();
            try
            {
                bominfoAll = MyMVC.XmlSerializerHelper.XmlDeserialize<BOMInfo>(_bominfo, Encoding.Unicode);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }
            //string strTestInfo = "<Info OrgCode=\"01\" DocNo=\"Doc001\" BoxPerQty=\"50\" RepCompleteQty=\"1000\" Status=\"1\"></Info>";
            //string strBarCodes = "<BarCodes><BarCode IsBoxCode=\"true\" Qty=\"20\">123</BarCode></BarCodes>";

            //if (string.IsNullOrEmpty(_docinfoflag))
            //{
            //    _docinfoflag = strTestInfo;
            //}

            //if (string.IsNullOrEmpty(_barcodesflag))
            //{
            //    _barcodesflag = strBarCodes;
            //}
            #endregion

            try
            {
                strResult = client.Do(out msg, context, _bominfo, contextInfoString);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

            return strResult;
        }


        [WebMethod(Description = "PLMECN查询库存服务", BufferResponse = true, CacheDuration = 10)]
        public string ECNWHQuerySV(string _bominfo)
        {
            string strResult = string.Empty;
            System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            string remoteAddress = GetU9SVURI(contextInfo, "ECNWHQuery");

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNWHQueryClient client = new UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNWHQueryClient(binding, endpoint);
            UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(contextInfo);
            UFSoft.UBF.Exceptions.MessageBase[] msg = null;

            if (string.IsNullOrEmpty(_bominfo))
            {
                _bominfo = "<ECNQuery OrgCode=\"005\"><BomMasters><BOMMaster ItemMasterCode=\"002.01.0101.0001\" BOMVersionCode=\"A0\" BOMType=\"自制\"><!--BOM母件信息--><Components><BOMComponent PreItemCode=\"005.04.0401.0001\" PreItemVersionCode=\"\" PreIssueUomCode=\"Bottle01\" PreUsageQty=\"12\" PreScrap=\"0\" PreParentQty=\"1\" ECNAction=\"add\" PostItemCode=\"005.04.0401.0001\" PostItemVersionCode=\"\" PostIssueUomCode=\"Bottle01\" PostUsageQty=\"24\" PostScrap=\"0\" PostParentQty=\"1\"></BOMComponent></Components></BOMMaster></BomMasters></ECNQuery>";
            }
            try
            {
                strResult = client.Do(out msg, context, _bominfo, "");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

            return strResult;
        }

        [WebMethod(Description = "PLMECN查询MO服务", BufferResponse = true, CacheDuration = 10)]
        public string ECNMOQuerySV(string _bominfo)
        {
            string strResult = string.Empty;
            System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            string remoteAddress = GetU9SVURI(contextInfo, "ECNMOQuery");

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient client = new UFIDAU9SaforVWPLMSVPLMECNQuerySVIECNMOQueryClient(binding, endpoint);
            UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(contextInfo);
            UFSoft.UBF.Exceptions.MessageBase[] msg = null;

            if (string.IsNullOrEmpty(_bominfo))
            {
                _bominfo = "<ECNQuery OrgCode=\"04\"><BomMasters><BOMMaster ItemMasterCode=\"S-TR-24-10-021\" BOMVersionCode=\"A5.0\" BOMType=\"0\"><Components><BOMComponent PreItemCode=\"\" PreItemVersionCode=\"\" PreUsageQty=\"0\" PreScrap=\"0\" PreParentQty=\"1\" ECNAction=\"add\" PostItemCode=\"3-FJ-S2-10-159\" PostItemVersionCode=\"A1.0\" PostIssueUomCode=\"S101\" PostUsageQty=\"1\" PostScrap=\"0\" PostParentQty=\"1\"></BOMComponent></Components></BOMMaster></BomMasters></ECNQuery>";
            }
            try
            {
                strResult = client.Do(out msg, context, _bominfo, "");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

            return strResult;
        }


        [WebMethod(Description = "PLMECN变更提交服务", BufferResponse = true, CacheDuration = 10)]
        public string ECNCreateSV(string _bominfo)
        {
            string strResult = string.Empty;
            System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            string remoteAddress = GetU9SVURI(contextInfo, "ECNInfoCreate");

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient client = new UFIDAU9SaforVWPLMSVPLMECNCreateSVICreatePLMECNClient(binding, endpoint);
            UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(contextInfo);
            UFSoft.UBF.Exceptions.MessageBase[] msg = null;

            if (string.IsNullOrEmpty(_bominfo))
            {
                _bominfo = "<ECNAlterRequest ECNDocNo=\"100001\"><ECNBomMasters><ECNBomMaster ItemMasterCode=\"005.04.0403.0002\" BOMVersionCode=\"A0\" BOMType=\"自制\"><ECNComponents><ECNBOMComponent PreItemCode=\"005.01.0.0013\" PreItemVersionCode=\"0\" PreIssueUomCode=\"W013\" PreUsageQty=\"0.001123\" PreScrap=\"0\" PreParentQty=\"1\" ECNAction=\"add\"  PostItemCode=\"005.01.0.0013\" PostItemVersionCode=\"0\" PostIssueUomCode=\"W013\" PostUsageQty=\"0.001123\" PostScrap=\"0\" PostParentQty=\"1\"><ECNMOInfos><ECNMOInfo IsAlter=\"Y\" OrgCode=\"005\" MONo=\"MO-0191\" MOQty=\"5\" MOTotalRcvQty=\"0\" PrePerUsageQty=\"0.001123\" PreUsageQty=\"1\" DiffPerUsageQty=\"0\" DiffUsageQty=\"0\" PostPerUsageQty=\"0\" PostUsageQty=\"0\" IssuedQty=\"0\" /></ECNMOInfos></ECNBOMComponent></ECNComponents></ECNBomMaster></ECNBomMasters></ECNAlterRequest> ";
            }
            try
            {
                strResult = client.Do(out msg, context, _bominfo, "");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

            return strResult;
        }

        [WebMethod(Description = "查询ECN变更差异服务", BufferResponse = true, CacheDuration = 10)]
        public string QueryPLMECN(string _bominfo)
        {
            string strResult = string.Empty;
            System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            string remoteAddress = GetU9SVURI(contextInfo, "QueryPLMECN");

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            UFIDAU9SaforVWPLMSVPLMECNCreateSVIQueryPLMECNClient client = new UFIDAU9SaforVWPLMSVPLMECNCreateSVIQueryPLMECNClient(binding, endpoint);
            UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(contextInfo);
            UFSoft.UBF.Exceptions.MessageBase[] msg = null;

            if (string.IsNullOrEmpty(_bominfo))
            {
                _bominfo = "<ECNAlterRequest ECNDocNo=\"100001\"></ECNAlterRequest>";
            }
            try
            {
                strResult = client.Do(out msg, context, _bominfo, "");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

            return strResult;
        }

        [WebMethod(Description = "更新备料表及BOM服务", BufferResponse = true, CacheDuration = 10)]
        public string ModifyMOPickList(string _bominfo)
        {
            string strResult = string.Empty;
            System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            string remoteAddress = GetU9SVURI(contextInfo, "ModifyMOPickList");

            EndpointAddress endpoint = new EndpointAddress(remoteAddress);
            UFIDAU9SaforVWPLMSVPLMToU9ModifySVIModifyMOPickListClient client = new UFIDAU9SaforVWPLMSVPLMToU9ModifySVIModifyMOPickListClient(binding, endpoint);
            UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(contextInfo);
            UFSoft.UBF.Exceptions.MessageBase[] msg = null;

            if (string.IsNullOrEmpty(_bominfo))
            {
                _bominfo = "<PLMECNInfo ECNDocNo=\"100001\" ActionType=\"0\"></PLMECNInfo>";
            }
            try
            {
                strResult = client.Do(out msg, context, _bominfo, "");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

            return strResult;
        }

        //[WebMethod(Description = "创建BOM", BufferResponse = true, CacheDuration = 10)]
        //public string CreateU9BOMSV(string _bominfo)
        //{
        //    string strResult = string.Empty;

        //    if (string.IsNullOrEmpty(_bominfo))
        //    {
        //        log.Error(string.Format("创建BOM失败：传入参数BOMInfo为空。"));
        //        strResult = string.Format("<ResultInfo Error={0} />", "创建BOM失败：传入参数BOMInfo为空。");
        //        return strResult;
        //    }
        //    BOMInfo bominfoAll = new BOMInfo();
        //    try
        //    {
        //        bominfoAll = XmlHelper.XmlDeserialize<BOMInfo>(_bominfo, Encoding.Unicode);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(string.Format("反序列化BOMInfo失败：{0}",_bominfo));
        //        strResult = string.Format("<ResultInfo Error={0} />", string.Format("反序列化BOMInfo失败：{0}", _bominfo));
        //        return strResult;
        //    }

        //    System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
        //    binding.SendTimeout = new TimeSpan(0, 50, 0);
        //    string remoteAddress = GetU9SVURI(bominfoAll,"CreateBOM");

        //    EndpointAddress endpoint = new EndpointAddress(remoteAddress);
        //    UFIDAU9CustVWPLMBOMCommonSVICreateBOMSVClient client = new UFIDAU9CustVWPLMBOMCommonSVICreateBOMSVClient(binding, endpoint);
        //    //UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient client = new UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient();
        //    UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(bominfoAll);
        //    UFSoft.UBF.Exceptions.MessageBase[] msg = null;

        //    #region 测试用
        //    //string strTestInfo = "<Info OrgCode=\"01\" DocNo=\"Doc001\" BoxPerQty=\"50\" RepCompleteQty=\"1000\" Status=\"1\"></Info>";
        //    //string strBarCodes = "<BarCodes><BarCode IsBoxCode=\"true\" Qty=\"20\">123</BarCode></BarCodes>";

        //    //if (string.IsNullOrEmpty(_docinfoflag))
        //    //{
        //    //    _docinfoflag = strTestInfo;
        //    //}

        //    //if (string.IsNullOrEmpty(_barcodesflag))
        //    //{
        //    //    _barcodesflag = strBarCodes;
        //    //}
        //    #endregion
        //    try
        //    {
        //        strResult = client.Do(out msg, context, _bominfo);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //        throw ex;
        //    }

        //    return strResult;
        //}

        //[WebMethod(Description = "删除子件BOM", BufferResponse = true, CacheDuration = 10)]
        //public string DelU9BOMComponentSV(string _bominfo)
        //{
        //    string strResult = string.Empty;

        //    if (string.IsNullOrEmpty(_bominfo))
        //    {
        //        log.Error(string.Format("删除BOM子件失败：传入参数BOMInfo为空。"));
        //        strResult = string.Format("<ResultInfo Error={0} />", "删除BOM子件失败：传入参数BOMInfo为空。");
        //        return strResult;
        //    }
        //    BOMInfo bominfoAll = new BOMInfo();
        //    try
        //    {
        //        bominfoAll = XmlHelper.XmlDeserialize<BOMInfo>(_bominfo, Encoding.Unicode);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(string.Format("反序列化BOMInfo失败：{0}", _bominfo));
        //        strResult = string.Format("<ResultInfo Error={0} />", string.Format("反序列化BOMInfo失败：{0}", _bominfo));
        //        return strResult;
        //    }

        //    System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
        //    binding.SendTimeout = new TimeSpan(0, 50, 0);
        //    string remoteAddress = GetU9SVURI(bominfoAll, "DelBOMComponent");

        //    EndpointAddress endpoint = new EndpointAddress(remoteAddress);
        //    UFIDAU9CustVWPLMBOMCommonSVIDelBOMComponentSVClient client = new UFIDAU9CustVWPLMBOMCommonSVIDelBOMComponentSVClient(binding, endpoint);
        //    //UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient client = new UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient();
        //    UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(bominfoAll);
        //    UFSoft.UBF.Exceptions.MessageBase[] msg = null;

        //    #region 测试用
        //    //string strTestInfo = "<Info OrgCode=\"01\" DocNo=\"Doc001\" BoxPerQty=\"50\" RepCompleteQty=\"1000\" Status=\"1\"></Info>";
        //    //string strBarCodes = "<BarCodes><BarCode IsBoxCode=\"true\" Qty=\"20\">123</BarCode></BarCodes>";

        //    //if (string.IsNullOrEmpty(_docinfoflag))
        //    //{
        //    //    _docinfoflag = strTestInfo;
        //    //}

        //    //if (string.IsNullOrEmpty(_barcodesflag))
        //    //{
        //    //    _barcodesflag = strBarCodes;
        //    //}
        //    #endregion
        //    try
        //    {
        //        strResult = client.Do(out msg, context, _bominfo);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //        throw ex;
        //    }

        //    return strResult;
        //}

        //[WebMethod(Description = "创建修改BOM", BufferResponse = true, CacheDuration = 10)]
        //public string CreateModifyU9BOMSV(string _bominfo)
        //{
        //    string strResult = string.Empty;

        //    if (string.IsNullOrEmpty(_bominfo))
        //    {
        //        log.Error(string.Format("创建BOM失败：传入参数BOMInfo为空。"));
        //        strResult = string.Format("<ResultInfo Error={0} />", "修改BOM失败：传入参数BOMInfo为空。");
        //        return strResult;
        //    }
        //    BOMInfo bominfoAll = new BOMInfo();
        //    try
        //    {
        //        bominfoAll = XmlHelper.XmlDeserialize<BOMInfo>(_bominfo, Encoding.Unicode);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(string.Format("反序列化BOMInfo失败：{0}", _bominfo));
        //        strResult = string.Format("<ResultInfo Error={0} />", string.Format("反序列化BOMInfo失败：{0}", _bominfo));
        //        return strResult;
        //    }

        //    System.ServiceModel.Channels.Binding binding = GetU9ServerBinding();
        //    binding.SendTimeout = new TimeSpan(0, 50, 0);
        //    string remoteAddress = GetU9SVURI(bominfoAll, "ModifyBOM");

        //    EndpointAddress endpoint = new EndpointAddress(remoteAddress);
        //    UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient client = new UFIDAU9CustVWPLMBOMCommonSVIModifyBOMSVClient(binding, endpoint);
        //    //UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient client = new UFIDAU9CustFormeBarCodeCreateBarCodeSVICreateTempCompleteInDocSVClient();
        //    UFSoft.UBF.Util.Context.ThreadContext context = CreateContextObj(bominfoAll);
        //    UFSoft.UBF.Exceptions.MessageBase[] msg = null;

        //    #region 测试用
        //    //string strTestInfo = "<Info OrgCode=\"01\" DocNo=\"Doc001\" BoxPerQty=\"50\" RepCompleteQty=\"1000\" Status=\"1\"></Info>";
        //    //string strBarCodes = "<BarCodes><BarCode IsBoxCode=\"true\" Qty=\"20\">123</BarCode></BarCodes>";

        //    //if (string.IsNullOrEmpty(_docinfoflag))
        //    //{
        //    //    _docinfoflag = strTestInfo;
        //    //}

        //    //if (string.IsNullOrEmpty(_barcodesflag))
        //    //{
        //    //    _barcodesflag = strBarCodes;
        //    //}
        //    #endregion
        //    try
        //    {
        //        strResult = client.Do(out msg, context, _bominfo);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //        throw ex;
        //    }

        //    return strResult;
        //}
        #region 内部方法
        public ContextInfo contextInfo {
            get
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strConfig);
                XPathNavigator xNav = xmlDoc.CreateNavigator();
                xNav.MoveToRoot();
                xNav.MoveToFirstChild();
                xNav.MoveToFirstChild();
                string strContext = xNav.OuterXml;
                ContextInfo contextinfoAll = new ContextInfo();
                try
                {
                    contextinfoAll = XmlHelper.XmlDeserialize<ContextInfo>(strContext, Encoding.Unicode);
                }
                catch (Exception ex)
                {
                    log.Error(string.Format("反序列化ContextInfo失败：{0}", strContext));
                }
                return contextinfoAll;
            }
        }

        public string contextInfoString
        {
            get
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strConfig);
                XPathNavigator xNav = xmlDoc.CreateNavigator();
                xNav.MoveToRoot();
                xNav.MoveToFirstChild();
                xNav.MoveToFirstChild();
                string strContext = xNav.OuterXml;
                return strContext;
            }
        }

        public string ItemModuleCode
        {
            get
            {
                string strItemModuleCode = string.Empty;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strConfig);

                XmlNodeList lstNode = xmlDoc.GetElementsByTagName("ItemModuleInfo");
                if (lstNode.Count > 0)
                {
                    XmlNode xNodeItem = xmlDoc.GetElementsByTagName("ItemModuleInfo")[0];
                    if (xNodeItem.Attributes.Count > 0)
                    {
                        strItemModuleCode = xNodeItem.Attributes[0].Value;
                    }
                }
                return strItemModuleCode;
            }
        }

        public List<KeyValuePair<string, long>> VWOrgCollection = new List<KeyValuePair<string, long>>();

        public static UFSoft.UBF.Util.Context.ThreadContext CreateContextObj()
        {
            XmlDocument xmldocInfo = new XmlDocument();
            xmldocInfo.LoadXml(strConfig);

            // 实例化应用上下文对象
            UFSoft.UBF.Util.Context.ThreadContext thContext = new UFSoft.UBF.Util.Context.ThreadContext();

            System.Collections.Generic.Dictionary<object, object> ns = new Dictionary<object, object>();
            ns.Add("OrgID", "1001111070101466");  //组织
            ns.Add("UserID", "1001003208765772"); //用户
            ns.Add("CultureName", "zh-CN");         //语言
            ns.Add("EnterpriseID", "001");          //企业
            ns.Add("DefaultCultureName", "zh_CN");
            ns.Add("Support_CultureNameList", "zh-CN");

            thContext.nameValueHas = ns;
            return thContext;
        }

        public UFSoft.UBF.Util.Context.ThreadContext CreateContextObj(ContextInfo _contextinfo)
        {
            if (VWOrgCollection.Count <= 0)
            {
                VWOrgCollection.Add(new KeyValuePair<string, long>("01", 1000806040266936));//摩比发展
                VWOrgCollection.Add(new KeyValuePair<string, long>("02", 1000806040266944));//摩比测试
                VWOrgCollection.Add(new KeyValuePair<string, long>("03", 1000806040266943));//摩比吉安

                VWOrgCollection.Add(new KeyValuePair<string, long>("04", 1000806040266976));//摩比深圳
                VWOrgCollection.Add(new KeyValuePair<string, long>("05", 1001411111955249));//摩比西安
                VWOrgCollection.Add(new KeyValuePair<string, long>("06", 1002303074597517));//摩比香港
                VWOrgCollection.Add(new KeyValuePair<string, long>("07", 1003110033161980));//摩比新材料
                VWOrgCollection.Add(new KeyValuePair<string, long>("08", 1003201029587035));//摩比通信
                VWOrgCollection.Add(new KeyValuePair<string, long>("09", 1003403146151987));//摩比物业
                VWOrgCollection.Add(new KeyValuePair<string, long>("10", 1003412167656950));//摩比光明
                VWOrgCollection.Add(new KeyValuePair<string, long>("11", 1003711078176858));//摩比新材料分公司
                VWOrgCollection.Add(new KeyValuePair<string, long>("12", 1003806157584945));//摩比武汉
                VWOrgCollection.Add(new KeyValuePair<string, long>("13", 1003708296014709));//摩比吉安子公司
                VWOrgCollection.Add(new KeyValuePair<string, long>("14", 1003708296012556));//摩比吉安分公司

                //本地测试
                VWOrgCollection.Add(new KeyValuePair<string, long>("W", 1001501160110021));//万亨达企业集团
                VWOrgCollection.Add(new KeyValuePair<string, long>("WZB", 1001503270024296));//总部周边
                VWOrgCollection.Add(new KeyValuePair<string, long>("WZB10", 1001503270025246));//投资中心
                VWOrgCollection.Add(new KeyValuePair<string, long>("WZZ", 1001501160110243));//制造事业群
                VWOrgCollection.Add(new KeyValuePair<string, long>("WZZ10", 1001501160110465));//热传事业处
                VWOrgCollection.Add(new KeyValuePair<string, long>("WZZ20", 1001501160110688));//熔铝事业处
                VWOrgCollection.Add(new KeyValuePair<string, long>("005", 1001708155996922));//熔铝事业处
            }
            string strOrgID = string.Empty;
            foreach (var item in VWOrgCollection)
            {
                if (string.Equals(item.Key,_contextinfo.OrgCode))
                {
                    strOrgID = item.Value.ToString();
                    break;
                }
            }
            //strUserID = "1001401310000005";//本地测试

            // 实例化应用上下文对象
            UFSoft.UBF.Util.Context.ThreadContext thContext = new UFSoft.UBF.Util.Context.ThreadContext();

            System.Collections.Generic.Dictionary<object, object> ns = new Dictionary<object, object>();
            ns.Add("OrgID", strOrgID);  //组织
            ns.Add("UserID", _contextinfo.UserID); //用户
            //ns.Add("UserCode", strUserCode);//用户代码
            //ns.Add("UserName", strUserName);//用户名称
            ns.Add("CultureName", _contextinfo.CultureName);         //语言
            ns.Add("EnterpriseID", _contextinfo.EnterpriseCode);          //企业
            ns.Add("DefaultCultureName", _contextinfo.CultureName);
            ns.Add("Support_CultureNameList", _contextinfo.CultureName);

            thContext.nameValueHas = ns;
            return thContext;
        }

        public Binding GetU9ServerBinding()
        {
            System.ServiceModel.Channels.CustomBinding binding = new System.ServiceModel.Channels.CustomBinding();
            TextMessageEncodingBindingElement bindelement_Text = new TextMessageEncodingBindingElement(System.ServiceModel.Channels.MessageVersion.Soap11, System.Text.Encoding.UTF8);
            bindelement_Text.MaxReadPoolSize = 256;
            bindelement_Text.MaxWritePoolSize = 256;
            bindelement_Text.ReaderQuotas.MaxStringContentLength = 2147483647;
            bindelement_Text.ReaderQuotas.MaxArrayLength = 16384000;
            bindelement_Text.ReaderQuotas.MaxBytesPerRead = 4096000;
            bindelement_Text.ReaderQuotas.MaxNameTableCharCount = 2097152;

            System.ServiceModel.Channels.HttpTransportBindingElement bindelement_Http = new System.ServiceModel.Channels.HttpTransportBindingElement();
            bindelement_Http.MaxReceivedMessageSize = 2097152;
            bindelement_Http.MaxBufferSize = 2097152;
            bindelement_Http.MaxBufferPoolSize = 2097152;

            binding.Elements.Add(bindelement_Text);
            binding.Elements.Add(bindelement_Http);

            return binding;

        }

        public Binding GetU9ServerBasicBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2097152;
            binding.ReaderQuotas.MaxStringContentLength = 2097152;
            binding.ReaderQuotas.MaxArrayLength = 16384000;
            binding.ReaderQuotas.MaxBytesPerRead = 4096000;
            binding.ReaderQuotas.MaxNameTableCharCount = 2097152;
            binding.SendTimeout = new TimeSpan(0, 5, 0);
            binding.OpenTimeout = new TimeSpan(0, 5, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 5, 0);
            binding.CloseTimeout = new TimeSpan(0, 5, 0);

            return binding;

        }

        public static string GetValueByConfig(string _condition, string _flag)
        {
            string strResult = string.Empty;
            XmlDocument xmldocInfo = new XmlDocument();
            xmldocInfo.LoadXml(_condition);
            XmlNode xnodeInfo = xmldocInfo.SelectSingleNode("descendant::Condition");
            foreach (XmlAttribute xattr in xnodeInfo.Attributes)
            {
                if (xattr.Name == _flag)
                {
                    strResult = xattr.Value;
                    break;
                }
            }

            return strResult;
        }

        private List<KeyValuePair<string, string>> lstSrvCollection = new List<KeyValuePair<string, string>>();

        public string GetU9SVURI(ContextInfo _contextinfo,string _srvname)
        {
            
            string strResult = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(_contextinfo.URI))
                {
                    throw new Exception("ContextInfo中URL服务地址为空");
                }
                if (lstSrvCollection.Count <= 0)
                {
                    lstSrvCollection.Add(new KeyValuePair<string, string>("CreateBOM", "UFIDA.U9.Cust.VW.PLM.BOMCommonSV.ICreateBOMSV.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("ModifyBOM", "UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IModifyBOMSV.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("DelBOMComponent", "UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IDelBOMComponentSV.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("InsertItemMaster", "UFIDA.U9.Cust.VW.PLM.BOMCommonSV.IInsertItemMasterSV.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("ECNWHQuery", "UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNWHQuery.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("ECNMOQuery", "UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV.IECNMOQuery.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("ECNInfoCreate", "UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.ICreatePLMECN.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("QueryPLMECN", "UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV.IQueryPLMECN.svc"));
                    lstSrvCollection.Add(new KeyValuePair<string, string>("ModifyMOPickList", "UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV.IModifyMOPickList.svc"));
                }
                foreach (var item in lstSrvCollection)
                {
                    if (string.Equals(item.Key, _srvname))
                    {
                        strResult = string.Format(@"{0}/{1}", _contextinfo.URI, item.Value);
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                strResult = string.Format("<ResultInfo Error={0} />",ex.Message);
                return strResult;
            }
            return strResult;
        }

        #endregion
    }
}
