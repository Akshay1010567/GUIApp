using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace CSW8Test.Parser
{
    public static class XmlParser
    {
        public static bool SerializeToXml(object obj, string filePath)
        {
            bool retVal = false;

            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, obj);
                retVal = true;
            }

            return retVal;

        }

        public static object? DeserializeFromXml<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return serializer.Deserialize(reader);
            }
        }


    }
}
