using System;
using System.Collections.Generic;
using System.Text;

namespace Domoticz.Models
{
    public class DevicesDomoticz
    {
        public int ActTime { get; set; }
        public string AstrTwilightEnd { get; set; }
        public string AstrTwilightStart { get; set; }
        public string CivTwilightEnd { get; set; }
        public string CivTwilightStart { get; set; }
        public string DayLength { get; set; }
        public string NautTwilightEnd { get; set; }
        public string NautTwilightStart { get; set; }
        public string ServerTime { get; set; }
        public string SunAtSouth { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string app_version { get; set; }
        public IList<ResultDevicesDomoticz> result { get; set; }
        public string status { get; set; }
        public string title { get; set; }
    }
}
