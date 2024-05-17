using CSW8Test.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSW8Test.Model.SBS
{
    public class InverterInput
    {
        public InverterType InverterType { get; set; }
        public double MinRMSVoltage { get; set; }
        public double MinFrequency { get; set; }
        public double MaxRMSVoltage { get; set; }
        public double MaxFrequency { get; set; }
        public double VoltageHysteresis { get; set; }
        public double FrequencyHysteresis { get; set; }
    }
}
