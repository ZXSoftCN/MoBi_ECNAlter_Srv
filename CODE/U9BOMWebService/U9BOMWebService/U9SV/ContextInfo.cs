using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;

namespace UFIDA.U9.Cust.VW.PLM.BOMCommonSV
{
    [XmlRoot("ContextInfo", Namespace = "", IsNullable = true)]
    public class ContextInfo
    {
        [XmlAttribute]
        public string EnterpriseCode { get; set; }

        [XmlAttribute]
        public string CultureName { get; set; }

        [XmlAttribute]
        public string UserID { get; set; }

        [XmlAttribute]
        public string OrgCode { get; set; }

        [XmlAttribute]
        public string IssueOrgCodes { get; set; }

        //http://localhost/U9/Services/
        [XmlAttribute]
        public string URI { get; set; }
    }
}