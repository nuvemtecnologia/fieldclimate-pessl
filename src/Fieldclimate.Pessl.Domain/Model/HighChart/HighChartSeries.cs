using System.Collections.Generic;
using Fieldclimate.Pessl.Domain.Model;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class HighChartSeries
    {
        [JsonProperty("yAxis")] public int YAxis { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("visible")] public bool Visible { get; set; }

        [JsonProperty("color")] public string Color { get; set; }

        [JsonProperty("turboThreshold")] public int TurboThreshold { get; set; }

        [JsonProperty("groupId")] public string GroupId { get; set; }

        [JsonProperty("label")] public HighChartLabel2 Label { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("data")] public List<List<object>> Data { get; set; }

        [JsonProperty("tooltip")] public HighChartTooltip Tooltip { get; set; }

        [JsonProperty("lineWidth")] public int? LineWidth { get; set; }

        [JsonProperty("fillOpacity")] public double? FillOpacity { get; set; }

        [JsonProperty("linkedTo")] public string LinkedTo { get; set; }

        [JsonProperty("zIndex")] public int? ZIndex { get; set; }

        [JsonProperty("marker")] public HighChartMarker HighChartMarker { get; set; }

        [JsonProperty("grouping")] public bool? Grouping { get; set; }

        [JsonProperty("pointWidth")] public int? PointWidth { get; set; }

        [JsonProperty("pointPlacement")] public string PointPlacement { get; set; }

        [JsonProperty("borderColor")] public string BorderColor { get; set; }

        [JsonProperty("borderWidth")] public double? BorderWidth { get; set; }
    }
}