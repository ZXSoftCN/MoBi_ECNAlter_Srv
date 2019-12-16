using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV
{
    [XmlRoot("PLMECNInfo", Namespace = "", IsNullable = true)]
    public class PLMECNInfo
    {
        [XmlAttribute]
        public string ECNDocNo { get; set; }

        [XmlAttribute]
        public string ActionType { get; set; }
    }
}
