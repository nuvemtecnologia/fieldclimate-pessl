using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartStyle6
    {
        [JsonProperty("left")] public int Left { get; set; }

        [JsonProperty("top")] public int Top { get; set; }

        [JsonProperty("fontSize")] public string FontSize { get; set; }
    }
}