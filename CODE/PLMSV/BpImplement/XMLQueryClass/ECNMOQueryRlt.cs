using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{

    [XmlRoot("ECNWHQueryRlt", Namespace = "", IsNullable = true)]
    public class ECNMOQueryRlt
    {
        [XmlAttribute]
        public string OrgCode { get; set; }

        [XmlArrayItem("BOMMaster")]
        public List<BOMMaster> BomMasters { get; set; }
    }

}
