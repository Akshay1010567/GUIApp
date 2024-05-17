using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSW8Test.Model.GeneralConfiguration
{
    public class SNTP
    {
        public bool EnableSNTP { get; set; }
        public string? SNTPServer { get; set; }
        public int Port { get; set; }
        public bool SummerTime { get; set; }
    }
}
