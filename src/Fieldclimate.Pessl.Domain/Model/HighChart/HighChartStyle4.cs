using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartStyle4
    {
        [JsonProperty("fontSize")] public string FontSize { get; set; }

        [JsonProperty("color")] public string Color { get; set; }
    }
}