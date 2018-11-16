using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domoticz.Models
{
    public class LightSwitch
    {

        [JsonProperty("result")]
        public IList<ResultLightSwitch> result { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
    public class ResultLightSwitch
    {

        [JsonProperty("DimmerLevels")]
        public string DimmerLevels { get; set; }

        [JsonProperty("IsDimmer")]
        public bool IsDimmer { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SubType")]
        public string SubType { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("idx")]
        public string idx { get; set; }
    }
}
