using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSW8Test.Model.General
{
    public class SerializableTimeZone
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public TimeSpan BaseUtcOffset { get; set; }
        public bool IsDaylightSavingTime { get; set; }

        // Parameterless constructor for serialization
        public SerializableTimeZone() { }

        // Constructor to initialize from TimeZoneInfo
        public SerializableTimeZone(TimeZoneInfo timeZoneInfo)
        {
            Id = timeZoneInfo.Id;
            DisplayName = timeZoneInfo.DisplayName;
            BaseUtcOffset = timeZoneInfo.BaseUtcOffset;
            IsDaylightSavingTime = timeZoneInfo.IsDaylightSavingTime(DateTime.Now);
        }
    }
}
