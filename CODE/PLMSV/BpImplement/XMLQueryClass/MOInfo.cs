using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
    public class MOInfo
    {
        [XmlAttribute]
        public string OrgCode { get; set; }

        [XmlAttribute]
        public string MONo { get; set; }

        [XmlAttribute]
        public string BOMVersion { get; set; }

        [XmlAttribute]
        public int StatusCode { get; set; }

        [XmlAttribute]
        public string StatusName { get; set; }

        [XmlAttribute]
        public decimal MOQty { get; set; }

        [XmlAttribute]
        public int DocLineNo { get; set; }//备料单行号。区分主键，当存在虚拟件展开子件时会出现有多个相同料品的备料行.

        [XmlAttribute]
        public string ItemCode { get; set; }//备料料号

        [XmlAttribute]
        public string ItemVersionNo { get; set; }//备料子件料号版本

        [XmlAttribute]
        public decimal PrePerUsageQty { get; set; }

        [XmlAttribute]
        public decimal PreUsageQty { get; set; }

        [XmlAttribute]
        public decimal FinishedQty { get; set; }

        [XmlAttribute]
        public decimal FetchedQty { get; set; }

        [XmlAttribute]
        public bool IsFromPhantomExpanding { get; set; }//来源虚拟件展开

        [XmlAttribute]
        public string PhantomItemCode { get; set; }//来源虚拟件料品编码

        [XmlAttribute]
        public string PhantomItemName { get; set; }//来源虚拟件料品名称

        [XmlAttribute]
        public decimal PostPerUsageQty { get; set; }

        [XmlAttribute]
        public decimal PostUsageQty { get; set; }
    }
}
