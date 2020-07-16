using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class HighChartTitle
    {
        [JsonProperty("floating")] public bool Floating { get; set; }

        [JsonProperty("align")] public string Align { get; set; }

        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("style")] public HighChartStyle HighChartStyle { get; set; }

        [JsonProperty("x")] public int X { get; set; }

        [JsonProperty("y")] public int Y { get; set; }

        [JsonProperty("useHTML")] public bool UseHTML { get; set; }
    }
}