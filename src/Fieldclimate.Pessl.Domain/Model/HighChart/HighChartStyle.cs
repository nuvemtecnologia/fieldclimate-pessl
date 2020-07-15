using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartStyle
    {
        [JsonProperty("fontSize")] public string FontSize { get; set; }

        [JsonProperty("color")] public string Color { get; set; }

        [JsonProperty("background-color")] public string BackgroundColor { get; set; }

        [JsonProperty("padding")] public string Padding { get; set; }
    }
}