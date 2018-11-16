using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domoticz.Models
{
    public class ResultJson
    {

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
