using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace MVVM
{
    public class DataService
    {
        public SystemConfiguration LoadConfiguration(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The configuration file was not found.", filePath);

            XmlSerializer serializer = new XmlSerializer(typeof(SystemConfiguration));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                return (SystemConfiguration)serializer.Deserialize(fileStream);
            }
        }

        public void SaveConfiguration(SystemConfiguration configuration, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SystemConfiguration));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, configuration);
            }
        }
    }
}
