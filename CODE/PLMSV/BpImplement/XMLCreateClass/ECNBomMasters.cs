using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{
    public class ECNBomMaster
    {
        [XmlAttribute]
        public string ItemMasterCode { get; set; }

        [XmlAttribute]
        public string BOMVersionCode { get; set; }

        [XmlAttribute]
        public string BOMType { get; set; }

        [XmlIgnore]
        public long ECNAtlerID { get; set; }

        [XmlArrayItem("ECNBOMComponent")]
        public List<ECNBOMComponent> ECNComponents { get; set; }
    }
}
