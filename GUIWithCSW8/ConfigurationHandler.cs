using CSW8Test.Model;
using CSW8Test.Model.Enums;
using CSW8Test.Model.GeneralConfiguration;
using CSW8Test.Model.SBS;
using CSW8Test.Parser;

namespace CSW8Test
{
    public static class ConfigurationHandler
    {
        private static SystemConfiguration? systemConfiguration;

        private static string filePath = Directory.GetCurrentDirectory() + "\\config.xml";

        public static SystemConfiguration SystemConfiguration 
        {
            get => systemConfiguration;
            set => systemConfiguration = value;
        }

        public static void Initialize()
        {
            systemConfiguration = new SystemConfiguration();
            systemConfiguration.GeneralConfig = new GeneralConfig();
            systemConfiguration.SBSCOnfig = new SBSConfiguration();

            #region General Config
            systemConfiguration.GeneralConfig.SystemName = "MainframeV2";
            systemConfiguration.GeneralConfig.ContactPerson = "Akshay Doe";
            
            systemConfiguration.GeneralConfig.Hotline = "+1234567890";
            systemConfiguration.GeneralConfig.LoginCode = "ABCD1234";
            systemConfiguration.GeneralConfig.Language = Language.English; // Assuming Language is an enum                       
            systemConfiguration.GeneralConfig.BasicColor = BasicColor.Blue; // Assuming BasicColor is an enum                    
            systemConfiguration.GeneralConfig.Timezone = new Model.General.SerializableTimeZone(TimeZoneInfo.Local); // Using TimeZoneInfo
            systemConfiguration.GeneralConfig.AudibleSignal = true;
            systemConfiguration.GeneralConfig.InstallationDate = new DateTime(2023, 1, 15);
            systemConfiguration.GeneralConfig.NetworkConfig = new Network
            {
                IpAddress = "192.168.1.1",
                SubnetAddress = "255.255.255.1",
                GatewayAddress = "127.0.0.1",
                Modbus = false
            };

            systemConfiguration.GeneralConfig.SNTPConfig = new SNTP
            {
                EnableSNTP = false,
                Port = 0,
                SNTPServer = "",
                SummerTime = false
            };

            #endregion

            #region SBS Config

            systemConfiguration.SBSCOnfig.DCInputConfig = new Model.SBS.DCInput
            {
                MaxVoltage = 10.0,
                MinVoltage = 0.0,
                VoltageHysteresis = 5.0,
                WarningVoltage = 9.0
            };

            
            systemConfiguration.SBSCOnfig.InverterInputConfig = new Model.SBS.InverterInput
            {
                VoltageHysteresis = 5.0,
                FrequencyHysteresis = 25,
                InverterType = InverterType.MT_MWR_48_230_2F,
                MaxFrequency = 50,
                MaxRMSVoltage = 10.0,
                MinFrequency = 5,
                MinRMSVoltage = 1.0
            };

            #endregion
        }

        public static bool Save()
        {
            bool retVal = false;

            XmlParser.SerializeToXml(systemConfiguration, filePath);
            retVal = true;

            return retVal;
        }

        public static bool Read()
        {
            bool retVal = false;

            systemConfiguration = (SystemConfiguration)XmlParser.DeserializeFromXml<SystemConfiguration>(filePath);
            retVal = true;

            return retVal;
        }





    }
}
