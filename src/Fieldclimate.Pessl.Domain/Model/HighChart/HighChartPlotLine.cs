using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartPlotLine
    {
        [JsonProperty("color")] public string Color { get; set; }

        [JsonProperty("width")] public int Width { get; set; }

        [JsonProperty("dashStyle")] public string DashStyle { get; set; }

        [JsonProperty("value")] public object Value { get; set; }

        [JsonProperty("label")] public HighChartLabel HighChartLabel { get; set; }
    }
}