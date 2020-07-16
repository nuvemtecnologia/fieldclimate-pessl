using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [ExcludeFromCodeCoverage]
    public class HighChartChart
    {
        [JsonProperty("zoomType")] public string ZoomType { get; set; }

        [JsonProperty("marginTop")] public int MarginTop { get; set; }

        [JsonProperty("height")] public object Height { get; set; }

        [JsonProperty("marginRight")] public int MarginRight { get; set; }

        [JsonProperty("marginLeft")] public int MarginLeft { get; set; }

        [JsonProperty("style")] public HighChartStyle2 Style { get; set; }
    }
}