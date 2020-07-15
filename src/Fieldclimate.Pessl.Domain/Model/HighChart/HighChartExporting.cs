using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartExporting
    {
        [JsonProperty("enabled")] public bool Enabled { get; set; }
    }
}