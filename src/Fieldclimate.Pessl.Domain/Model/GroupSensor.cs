using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class GroupSensor
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("group")] public string Group { get; set; }

        [JsonProperty("sensors")] public IEnumerable<GroupSensorItem> Sensors { get; set; }
    }
}