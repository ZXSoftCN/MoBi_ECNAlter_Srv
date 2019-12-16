using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;

namespace UFIDA.U9.Cust.VW.PLM.BOMCommonSV
{
    public class BOMComponent
    {
        [XmlIgnore]
        public bool IsCheck { get; set; }

        [XmlIgnore]
        public string IsValid { get; set; }

        [XmlAttribute]
        public int SeqNo { get; set; }

        [XmlAttribute]
        public string ItemCode { get; set; }

        [XmlAttribute]
        public string ItemVersionCode { get; set; }

        [XmlAttribute]
        public string IssueUomCode { get; set; }

        [XmlAttribute]
        public decimal UsageQty { get; set; }
        
        [XmlAttribute]
        public decimal ParentQty { get; set; }

        [XmlAttribute]
        public bool IsPhantomPart { get; set; }

        [XmlAttribute]
        public string Remark { get; set; }
    }
}
