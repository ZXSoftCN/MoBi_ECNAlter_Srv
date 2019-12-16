using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
    public class WHBOMComponent
    {
        [XmlAttribute]
        public string PreItemCode { get; set; }

        [XmlAttribute]
        public string PreItemVersionCode { get; set; }

        [XmlAttribute]
        public string Uom { get; set; }

        [XmlAttribute]
        public decimal OnWayQty { get; set; }

        [XmlAttribute]
        public decimal OnWhQty { get; set; }

        [XmlAttribute]
        public decimal OnWhTransQty { get; set; }

        [XmlAttribute]
        public decimal MORequestQty { get; set; }
    }
}
