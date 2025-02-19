using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolManager.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("BushCfg")]
    public class BushCfg
    {
        [XmlArray("ToolTypes")]
        [XmlArrayItem("ElemStart")]
        public List<ElemStart> ToolTypes { get; set; }

        [XmlArray("SideTypes")]
        [XmlArrayItem("SubElem")]
        public List<SubElemSideType> SideTypes { get; set; }
    }

    public class ElemStart
    {
        [XmlAttribute("messageId")]
        public int MessageId { get; set; }

        [XmlAttribute("Color")]
        public string Color { get; set; }

        [XmlElement("SubElem")]
        public List<SubElem> SubElems { get; set; }
    }

    public class SubElem
    {
        [XmlAttribute("codWork")]
        public int CodWork { get; set; }
    }

    public class SubElemSideType
    {
        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("messageId")]
        public int MessageId { get; set; }
    }

}
