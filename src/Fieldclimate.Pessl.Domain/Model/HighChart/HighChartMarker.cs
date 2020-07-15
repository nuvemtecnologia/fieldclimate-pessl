using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartMarker
    {
        [JsonProperty("enabled")] public bool Enabled { get; set; }
    }
}