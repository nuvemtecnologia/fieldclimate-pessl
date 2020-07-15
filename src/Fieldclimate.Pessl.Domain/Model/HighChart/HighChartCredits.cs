using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartCredits
    {
        [JsonProperty("enabled")] public bool Enabled { get; set; }
    }
}