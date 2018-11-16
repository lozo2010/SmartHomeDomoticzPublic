using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domoticz.Models
{
    public class TargetSetpoint
    {

        [JsonProperty("value")]
        public double value { get; set; }

        [JsonProperty("scale")]
        public string scale { get; set; }
    }

    public class PayloadTermostato
    {
        [JsonProperty("targetSetpoint")]
        public TargetSetpoint targetSetpoint { get; set; }

    }
}