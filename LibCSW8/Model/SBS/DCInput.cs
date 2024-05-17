using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSW8Test.Model.SBS
{
    public class DCInput
    {
        public double MinVoltage { get; set; }
        public double WarningVoltage { get; set; }
        public double MaxVoltage { get; set; }
        public double VoltageHysteresis { get; set; }
    }
}
