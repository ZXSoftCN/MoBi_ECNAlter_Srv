using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
    public class BOMComponent
    {
        [XmlAttribute]
        public string PreItemCode { get; set; }

        [XmlAttribute]
        public string PreItemVersionCode { get; set; }

        [XmlAttribute]
        public string PreIssueUomCode { get; set; }

        [XmlAttribute]
        public decimal PreUsageQty { get; set; }

        [XmlAttribute]
        public decimal PreScrap { get; set; }

        [XmlAttribute]
        public decimal PreParentQty { get; set; }

        [XmlAttribute]
        public string ECNAction { get; set; }

        [XmlAttribute]
        public string PostItemCode { get; set; }

        [XmlAttribute]
        public string PostItemVersionCode { get; set; }

        [XmlAttribute]
        public string PostIssueUomCode { get; set; }

        [XmlAttribute]
        public decimal PostUsageQty { get; set; }

        [XmlAttribute]
        public decimal PostScrap { get; set; }

        [XmlAttribute]
        public decimal PostParentQty { get; set; }

        [XmlArrayItem("MOInfo")]
        public List<MOInfo> MOInfos { get; set; }
    }
}
