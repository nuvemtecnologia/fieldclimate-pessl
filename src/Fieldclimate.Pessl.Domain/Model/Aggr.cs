using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Aggr
    {
        [JsonProperty("avg")] public int Avg { get; set; }

        [JsonProperty("max")] public int Max { get; set; }

        [JsonProperty("min")] public int Min { get; set; }
    }
}