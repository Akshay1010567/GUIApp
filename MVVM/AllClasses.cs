using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MVVM
{
    [XmlRoot("SystemConfiguration")]
    public class SystemConfiguration
    {
        public GeneralConfig GeneralConfig { get; set; }
        public SBSCOnfig SBSCOnfig { get; set; }
    }

    public class GeneralConfig
    {
        public string SystemName { get; set; }
        public string ContactPerson { get; set; }
        public string Hotline { get; set; }
        public string LoginCode { get; set; }
        public string Language { get; set; }
        public string BasicColor { get; set; }
        public Timezone Timezone { get; set; }
        public bool AudibleSignal { get; set; }
        public DateTime InstallationDate { get; set; }
        public NetworkConfig NetworkConfig { get; set; }
        public SNTPConfig SNTPConfig { get; set; }
    }

    public class Timezone
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string BaseUtcOffset { get; set; }
        public bool IsDaylightSavingTime { get; set; }
    }

    public class NetworkConfig
    {
        public string IpAddress { get; set; }
        public string SubnetAddress { get; set; }
        public string GatewayAddress { get; set; }
        public bool Modbus { get; set; }
    }

    public class SNTPConfig
    {
        public bool EnableSNTP { get; set; }
        public string SNTPServer { get; set; }
        public int Port { get; set; }
        public bool SummerTime { get; set; }
    }

    public class SBSCOnfig
    {
        public InverterInputConfig InverterInputConfig { get; set; }
        public DCInputConfig DCInputConfig { get; set; }

        public SBSCOnfig()
        {
            InverterInputConfig = new InverterInputConfig();
            DCInputConfig = new DCInputConfig();
        }
    }

    public class InverterInputConfig
    {
        public string InverterType { get; set; }
        public int MinRMSVoltage { get; set; }
        public int MinFrequency { get; set; }
        public int MaxRMSVoltage { get; set; }
        public int MaxFrequency { get; set; }
        public int VoltageHysteresis { get; set; }
        public int FrequencyHysteresis { get; set; }
    }

    public class DCInputConfig
    {
        public double MinVoltage { get; set; }
        public int WarningVoltage { get; set; }
        public double MaxVoltage { get; set; }
        public int VoltageHysteresis { get; set; }
    }
}
