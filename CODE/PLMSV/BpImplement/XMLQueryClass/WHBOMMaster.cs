using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
     public class WHBOMMaster
    {
        [XmlAttribute]
        public string ItemMasterCode { get; set; }

        [XmlAttribute]
        public string BOMVersionCode { get; set; }

        [XmlAttribute]
        public string BOMType { get; set; }

        [XmlAttribute]
        public decimal OnWayQty { get; set; }

        [XmlAttribute]
        public decimal OnWhQty { get; set; }

        [XmlAttribute]
        public decimal OnWhTransQty { get; set; }

        [XmlAttribute]
        public decimal MORequestQty { get; set; }

        [XmlArrayItem("WHBOMComponent")]
        public List<WHBOMComponent> WHComponents { get; set; }
    }
}
