using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{

    [XmlRoot("ECNDiffRequest", Namespace = "", IsNullable = true)]
    public class ECNDiffRequest
    {
        [XmlAttribute]
        public string ECNDocNo { get; set; }

        [XmlArrayItem("BOMMaster")]
        public List<BOMMaster> BomMasters { get; set; }
    }
}
