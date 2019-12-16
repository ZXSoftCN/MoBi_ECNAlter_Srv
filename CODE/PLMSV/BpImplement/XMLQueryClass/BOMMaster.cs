using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
    public class BOMMaster
    {
        [XmlAttribute]
        public string ItemMasterCode { get; set; }

        [XmlAttribute]
        public string BOMVersionCode { get; set; }

        [XmlAttribute]
        public string BOMType { get; set; }

        [XmlArrayItem("BOMComponent")]
        public List<BOMComponent> Components { get; set; }
    }
}
