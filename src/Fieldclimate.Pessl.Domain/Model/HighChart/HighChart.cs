using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fieldclimate.Pessl.Domain.Model;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [ExcludeFromCodeCoverage]
    public class HighChart
    {
        [JsonProperty("sources")] public List<string> Sources { get; set; }

        [JsonProperty("credits")] public HighChartCredits HighChartCredits { get; set; }

        [JsonProperty("exporting")] public HighChartExporting HighChartExporting { get; set; }

        [JsonProperty("title")] public HighChartTitle HighChartTitle { get; set; }

        [JsonProperty("subtitle")] public string Subtitle { get; set; }

        [JsonProperty("legend")] public HighChartLegend HighChartLegend { get; set; }

        [JsonProperty("tooltip")] public HighChartTooltip HighChartTooltip { get; set; }

        [JsonProperty("chart")] public HighChartChart HighChartChart { get; set; }

        [JsonProperty("xAxis")] public HighChartXAxis HighChartXAxis { get; set; }

        [JsonProperty("yAxis")] public List<HighChartYAxi> YAxis { get; set; }

        [JsonProperty("series")] public List<HighChartSeries> Series { get; set; }

        [JsonProperty("labels")] public HighChartLabels3 Labels { get; set; }
    }
}