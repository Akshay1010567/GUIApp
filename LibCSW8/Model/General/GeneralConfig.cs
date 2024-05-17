using CSW8Test.Model.Enums;
using CSW8Test.Model.General;
using System.Runtime.Serialization;

namespace CSW8Test.Model.GeneralConfiguration
{
    public class GeneralConfig
    {
        public string? SystemName { get; set; } 
        public string? ContactPerson { get; set; }
        public string? Hotline { get; set; }
        public string? LoginCode { get; set; }
        public Language Language { get; set; }
        public BasicColor BasicColor { get; set; }
        public SerializableTimeZone Timezone { get; set; }
        public bool AudibleSignal { get; set; }
        public DateTime InstallationDate { get; set; }

        public Network? NetworkConfig { get; set; }

        public SNTP? SNTPConfig { get; set; }


    }
}
