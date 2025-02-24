using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ToolManager.Entity
{
    // DBTools root element
    [XmlRoot("DBTools")]
    public class DBTools
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("ToolData")]
        public List<ToolData> ToolDataList { get; set; }
    }

    // ToolData class, each ToolData entry represents a tool's detailed information
    public class ToolData
    {
        [XmlElement("ToolField")]
        public List<ToolField> ToolFields { get; set; }
    }

    // ToolField class, represents individual fields in ToolData
    public class ToolField
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
