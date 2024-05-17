using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSW8Test.Model.GeneralConfiguration
{
    public class Network
    {
        public string? IpAddress { get; set; }
        public string? SubnetAddress { get; set; }
        public string? GatewayAddress { get; set; }
        public bool Modbus { get; set; }
    }
}
