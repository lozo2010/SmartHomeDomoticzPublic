using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domoticz.Models
{
    public class Temperatures
    {

        [JsonProperty("ActTime")]
        public int ActTime { get; set; }

        [JsonProperty("AstrTwilightEnd")]
        public string AstrTwilightEnd { get; set; }

        [JsonProperty("AstrTwilightStart")]
        public string AstrTwilightStart { get; set; }

        [JsonProperty("CivTwilightEnd")]
        public string CivTwilightEnd { get; set; }

        [JsonProperty("CivTwilightStart")]
        public string CivTwilightStart { get; set; }

        [JsonProperty("DayLength")]
        public string DayLength { get; set; }

        [JsonProperty("NautTwilightEnd")]
        public string NautTwilightEnd { get; set; }

        [JsonProperty("NautTwilightStart")]
        public string NautTwilightStart { get; set; }

        [JsonProperty("ServerTime")]
        public string ServerTime { get; set; }

        [JsonProperty("SunAtSouth")]
        public string SunAtSouth { get; set; }

        [JsonProperty("Sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("Sunset")]
        public string Sunset { get; set; }

        [JsonProperty("app_version")]
        public string app_version { get; set; }

        [JsonProperty("result")]
        public IList<ResultTemp> result { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }

    public class ResultTemp
    {

        [JsonProperty("AddjMulti")]
        public double AddjMulti { get; set; }

        [JsonProperty("AddjMulti2")]
        public double AddjMulti2 { get; set; }

        [JsonProperty("AddjValue")]
        public double AddjValue { get; set; }

        [JsonProperty("AddjValue2")]
        public double AddjValue2 { get; set; }

        [JsonProperty("BatteryLevel")]
        public int BatteryLevel { get; set; }

        [JsonProperty("CustomImage")]
        public int CustomImage { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Favorite")]
        public int Favorite { get; set; }

        [JsonProperty("HardwareID")]
        public int HardwareID { get; set; }

        [JsonProperty("HardwareName")]
        public string HardwareName { get; set; }

        [JsonProperty("HardwareType")]
        public string HardwareType { get; set; }

        [JsonProperty("HardwareTypeVal")]
        public int HardwareTypeVal { get; set; }

        [JsonProperty("HaveTimeout")]
        public bool HaveTimeout { get; set; }

        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("LastUpdate")]
        public string LastUpdate { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Notifications")]
        public string Notifications { get; set; }

        [JsonProperty("PlanID")]
        public string PlanID { get; set; }

        [JsonProperty("PlanIDs")]
        public IList<int> PlanIDs { get; set; }

        [JsonProperty("Protected")]
        public bool Protected { get; set; }

        [JsonProperty("ShowNotifications")]
        public bool ShowNotifications { get; set; }

        [JsonProperty("SignalLevel")]
        public string SignalLevel { get; set; }

        [JsonProperty("SubType")]
        public string SubType { get; set; }

        [JsonProperty("Temp")]
        public double Temp { get; set; }

        [JsonProperty("Timers")]
        public string Timers { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("TypeImg")]
        public string TypeImg { get; set; }

        [JsonProperty("Unit")]
        public int Unit { get; set; }

        [JsonProperty("Used")]
        public int Used { get; set; }

        [JsonProperty("XOffset")]
        public string XOffset { get; set; }

        [JsonProperty("YOffset")]
        public string YOffset { get; set; }

        [JsonProperty("idx")]
        public string idx { get; set; }

        [JsonProperty("DewPoint")]
        public string DewPoint { get; set; }

        [JsonProperty("Humidity")]
        public int? Humidity { get; set; }

        [JsonProperty("HumidityStatus")]
        public string HumidityStatus { get; set; }
    }


}
