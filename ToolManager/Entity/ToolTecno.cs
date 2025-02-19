using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToolManager.Entity
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Tecno));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Tecno)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "message")]
    public class Message
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }

    [XmlRoot(ElementName = "msgdef")]
    public class Msgdef
    {

        [XmlElement(ElementName = "message")]
        public List<Message> Message { get; set; }
    }

    [XmlRoot(ElementName = "tool")]
    public class Tool
    {

        [XmlElement(ElementName = "field")]
        public List<Field> Field { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [XmlElement(ElementName = "key")]
        public List<Key> Key { get; set; }

        [XmlElement(ElementName = "display")]
        public Display Display { get; set; }

        [XmlElement(ElementName = "item")]
        public Item Item { get; set; }

        [XmlElement(ElementName = "assign")]
        public List<Assign> Assign { get; set; }

        [XmlElement(ElementName = "group")]
        public List<Group> Group { get; set; }

        [XmlAttribute(AttributeName = "codWork")]
        public string CodWork { get; set; }

        [XmlAttribute(AttributeName = "codSide")]
        public string CodSide { get; set; }

        [XmlAttribute(AttributeName = "codSubWork")]
        public string CodSubWork { get; set; }
    }

    [XmlRoot(ElementName = "subs")]
    public class Subs
    {

        [XmlAttribute(AttributeName = "value")]
        public int Value { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }

        [XmlAttribute(AttributeName = "imageName")]
        public string ImageName { get; set; }
    }

    [XmlRoot(ElementName = "fielddef")]
    public class Fielddef
    {

        [XmlElement(ElementName = "subs")]
        public List<Subs> Subs { get; set; }

        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [XmlAttribute(AttributeName = "key")]
        public int Key { get; set; }
    }

    [XmlRoot(ElementName = "tooldef")]
    public class Tooldef
    {

        [XmlElement(ElementName = "tool")]
        public Tool Tool { get; set; }

        [XmlElement(ElementName = "fielddef")]
        public List<Fielddef> Fielddef { get; set; }
    }

    [XmlRoot(ElementName = "key")]
    public class Key
    {

        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }
    }

    [XmlRoot(ElementName = "display")]
    public class Display
    {

        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {

        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }

        [XmlAttribute(AttributeName = "min")]
        public int Min { get; set; }

        [XmlAttribute(AttributeName = "max")]
        public int Max { get; set; }

        [XmlAttribute(AttributeName = "suffix")]
        public string Suffix { get; set; }

        [XmlAttribute(AttributeName = "values")]
        public string Values { get; set; }

        [XmlAttribute(AttributeName = "defValue")]
        public int DefValue { get; set; }
    }

    [XmlRoot(ElementName = "assign")]
    public class Assign
    {

        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public int Value { get; set; }
    }

    [XmlRoot(ElementName = "group")]
    public class Group
    {

        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }

        [XmlAttribute(AttributeName = "messageId")]
        public string MessageId { get; set; }
    }

    [XmlRoot(ElementName = "toolview")]
    public class Toolview
    {

        [XmlElement(ElementName = "tool")]
        public List<Tool> Tool { get; set; }
    }

    [XmlRoot(ElementName = "tecno")]
    public class Tecno
    {

        [XmlElement(ElementName = "msgdef")]
        public Msgdef Msgdef { get; set; }

        [XmlElement(ElementName = "tooldef")]
        public Tooldef Tooldef { get; set; }

        [XmlElement(ElementName = "toolview")]
        public Toolview Toolview { get; set; }
    }


}
