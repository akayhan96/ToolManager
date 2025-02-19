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

    // Root elementi DBOutfits
    [XmlRoot("DBOutfits")]
    public class DBOutfits
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("Outfit")]
        public List<Outfit> Outfits { get; set; }
    }

    // Outfit sınıfı, DBOutfits içinde yer alan her bir Outfit öğesini temsil eder
    public class Outfit
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlElement("ToolName")]
        public List<ToolName> ToolNames { get; set; }
    }

    // ToolName sınıfı, Outfit içindeki ToolName öğelerini temsil eder
    public class ToolName
    {
        [XmlAttribute("group")]
        public int Group { get; set; }

        [XmlAttribute("position")]
        public int Position { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

}
