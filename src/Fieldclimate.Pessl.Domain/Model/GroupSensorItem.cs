using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class GroupSensorItem
    {
        public string Id { get; set; }
        
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("unit")] public string Unit { get; set; }

        /// <summary>
        /// Pode ser bool, List<string>
        /// </summary>
        [JsonProperty("units")] public dynamic Units { get; set; }

        [JsonProperty("code")] public int Code { get; set; }

        [JsonProperty("group")] public int Group { get; set; }

        [JsonProperty("decimals")] public int Decimals { get; set; }

        [JsonProperty("divider")] public int Divider { get; set; }

        [JsonProperty("power")] public int Power { get; set; }

        [JsonProperty("multiplier")] public int Multiplier { get; set; }

        [JsonProperty("size")] public string Size { get; set; }

        [JsonProperty("vals")] public Vals Vals { get; set; }

        [JsonProperty("aggr")] public Aggr Aggr { get; set; }

        [JsonProperty("desc")] public string Desc { get; set; }
    }
}