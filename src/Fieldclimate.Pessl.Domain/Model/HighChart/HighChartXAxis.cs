using System.Collections.Generic;
using Fieldclimate.Pessl.Domain.Model;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class HighChartXAxis
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("gridLineWidth")] public int GridLineWidth { get; set; }

        [JsonProperty("crosshair")] public bool Crosshair { get; set; }

        [JsonProperty("labels")] public HighChartLabels HighChartLabels { get; set; }

        [JsonProperty("lineWidth")] public int LineWidth { get; set; }

        [JsonProperty("plotLines")] public List<HighChartPlotLine> PlotLines { get; set; }
    }
}