using FieldClimate.Pessl.Domain.Model.HighChart;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class HighChartLegend
    {
        [JsonProperty("backgroundColor")] public string BackgroundColor { get; set; }

        [JsonProperty("enabled")] public bool Enabled { get; set; }

        [JsonProperty("align")] public string Align { get; set; }

        [JsonProperty("verticalAlign")] public string VerticalAlign { get; set; }

        [JsonProperty("layout")] public string Layout { get; set; }

        [JsonProperty("y")] public int Y { get; set; }

        [JsonProperty("x")] public int X { get; set; }

        [JsonProperty("itemDistance")] public int ItemDistance { get; set; }

        [JsonProperty("itemMarginBottom")] public int ItemMarginBottom { get; set; }

        [JsonProperty("itemStyle")] public HighChartItemStyle HighChartItemStyle { get; set; }
    }
}