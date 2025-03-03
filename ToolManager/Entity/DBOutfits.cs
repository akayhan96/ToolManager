using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToolManager.Entity
{
    // Root elementi DBOutfits
    [XmlRoot("DBOutfits")]
    public class DBOutfits
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("version")]
        public int Version { get; set; } // Eğer her zaman sayı ise int olmalı

        [XmlElement("Outfit")]
        public List<Outfit> Outfits { get; set; } = new List<Outfit>(); // Listeyi baştan initialize ettik
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
