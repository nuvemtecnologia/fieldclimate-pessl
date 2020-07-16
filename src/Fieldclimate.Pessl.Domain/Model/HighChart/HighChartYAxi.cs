using System.Collections.Generic;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class HighChartYAxi
    {
        [JsonProperty("title")] public HighChartTitle2 Title { get; set; }

        [JsonProperty("labels")] public HighChartLabels2 Labels { get; set; }

        [JsonProperty("opposite")] public bool? Opposite { get; set; }

        [JsonProperty("min")] public int? Min { get; set; }

        [JsonProperty("max")] public int? Max { get; set; }

        [JsonProperty("tickPositions")] public List<int> TickPositions { get; set; }

        [JsonProperty("gridLineWidth")] public int? GridLineWidth { get; set; }

        [JsonProperty("height")] public string Height { get; set; }
    }
}