using System.Xml.Serialization;
using System.IO;
using System.Runtime.CompilerServices;
using CSW8Test.Parser;
using CSW8Test;

public class Program
{
    private static void Main(string[] args)
    {
        ConfigurationHandler.CreateDummyData();

        /*
         * Serialize to XML
         */

        //ConfigurationHandler.Save();

        //Console.WriteLine("Serialized to XML");


        /*
         * Deserialize from XML
         */

        //ConfigurationHandler.Read();
        

        //Console.WriteLine("Deserialized from XML");

        ConfigurationHandler.SystemConfiguration.GeneralConfig.Language = CSW8Test.Model.Enums.Language.English; 

        ConfigurationHandler.Save();
        Console.WriteLine("Serialized to XML");

    }
}