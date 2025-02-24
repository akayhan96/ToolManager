using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToolManager.Entity
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    [XmlRoot("tecno")]
    public class ToolTecno
    {
        [XmlElement("msgdef")]
        public MsgDef MsgDef { get; set; }

        [XmlElement("tooldef")]
        public ToolDef ToolDef { get; set; }

        [XmlElement("toolview")]
        public ToolView ToolView { get; set; }
    }

    // 🔹 1️⃣ Mesaj Tanımları (msgdef)
    public class MsgDef
    {
        [XmlElement("message")]
        public List<Message> Messages { get; set; }
    }

    public class Message
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public int Id { get; set; }
    }

    // 🔹 2️⃣ Takım Tanımları (tooldef)
    public class ToolDef
    {
        [XmlElement("tool")]
        public Tool Tool { get; set; }

        [XmlElement("fielddef")]
        public List<FieldDef> FieldDefs { get; set; }
    }

    public class Tool
    {
        [XmlAttribute("version")]
        public int Version { get; set; }

        [XmlElement("field")]
        public List<Field> Fields { get; set; }
    }

    public class Field
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("length")]
        public int Length { get; set; }

        [XmlAttribute("comment")]
        public string Comment { get; set; }
    }

    public class FieldDef
    {
        [XmlAttribute("field")]
        public string Field { get; set; }

        [XmlAttribute("key")]
        public int Key { get; set; }

        [XmlElement("subs")]
        public List<SubField> SubFields { get; set; }
    }

    public class SubField
    {
        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("messageId")]
        public string MessageId { get; set; }

        [XmlAttribute("imageName")]
        public string ImageName { get; set; }
    }

    // 🔹 3️⃣ ToolView Tanımları
    public class ToolView
    {
        [XmlElement("tool")]
        public List<ToolViewItem> Tools { get; set; }
    }

    public class ToolViewItem
    {
        [XmlAttribute("codWork")]
        public string CodWork { get; set; }

        [XmlAttribute("codSide")]
        public string CodSide { get; set; }

        [XmlAttribute("codSubWork")]
        public string CodSubWork { get; set; }

        [XmlElement("key")]
        public List<KeyField> Keys { get; set; }

        [XmlElement("display")]
        public DisplayField Display { get; set; }

        [XmlElement("item")]
        public List<ItemField> Items { get; set; }

        [XmlElement("assign")]
        public List<AssignField> Assigns { get; set; }

        [XmlElement("group")]
        public List<GroupField> Groups { get; set; }
    }

    public class KeyField
    {
        [XmlAttribute("field")]
        public string Field { get; set; }

        [XmlAttribute("messageId")]
        public string MessageId { get; set; }
    }

    public class DisplayField
    {
        [XmlAttribute("field")]
        public string Field { get; set; }
    }

    public class ItemField
    {
        [XmlAttribute("field")]
        public string Field { get; set; }

        [XmlAttribute("messageId")]
        public string MessageId { get; set; }

        [XmlAttribute("suffix")]
        public string Suffix { get; set; }

        [XmlAttribute("min")]
        public int Min { get; set; }

        [XmlAttribute("max")]
        public int Max { get; set; }

        [XmlAttribute("values")]
        public string Values { get; set; }

    }

    public class AssignField
    {
        [XmlAttribute("field")]
        public string Field { get; set; }

        [XmlAttribute("value")]
        public int Value { get; set; }
    }

    public class GroupField
    {
        [XmlAttribute("messageId")]
        public string MessageId { get; set; }

        [XmlElement("item")]
        public List<ItemField> Items { get; set; }
    }



}
