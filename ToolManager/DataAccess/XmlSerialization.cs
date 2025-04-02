using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToolManager.DataAccess
{
    public class XmlSerialization
    {
        public static T Deserialize<T>(string xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(xmlFile))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static void Serialize<T>(T objectToSerialize, string xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(xmlFile))
            {
                serializer.Serialize(writer, objectToSerialize);
            }
        }
    }
}
