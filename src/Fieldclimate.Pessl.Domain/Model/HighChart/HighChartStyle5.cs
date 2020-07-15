using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartStyle5
    {
        [JsonProperty("color")] public string Color { get; set; }

        [JsonProperty("backgroundColor")] public string BackgroundColor { get; set; }

        [JsonProperty("fontSize")] public string FontSize { get; set; }
    }
}