using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ToolManager.Entity
{
    [XmlRoot("tooltree")]
    public class ToolTree
    {
        [XmlElement("node")]
        public List<Node> Nodes { get; set; }
    }

    public class Node
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("enabled")]
        public int Enabled { get; set; }

        [XmlElement("node")]
        public List<Node> SubNodes { get; set; }
    }

}
