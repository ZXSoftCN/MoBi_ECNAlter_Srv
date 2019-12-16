using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{

    [XmlRoot("ECNAlterRequest", Namespace = "", IsNullable = true)]
    public class ECNAlterRequest
    {
        [XmlAttribute]
        public string ECNDocNo { get; set; }

        [XmlArrayItem("ECNBomMaster")]
        public List<ECNBomMaster> ECNBomMasters { get; set; }
    }

}
