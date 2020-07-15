using Fieldclimate.Pessl.Domain.Model;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartLabel
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("align")] public string Align { get; set; }

        [JsonProperty("verticalAlign")] public string VerticalAlign { get; set; }

        [JsonProperty("y")] public int Y { get; set; }

        [JsonProperty("style")] public HighChartStyle4 Style { get; set; }
    }
}