using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{
    [XmlRoot("ECNDiffResponse", Namespace = "", IsNullable = true)]
    public class ECNDiffResponse
    {
        [XmlAttribute]
        public string ECNDocNo { get; set; }

        [XmlArrayItem("ECNBomMaster")]
        public List<ECNBomMaster> ECNBomMasters { get; set; }
    }
}
