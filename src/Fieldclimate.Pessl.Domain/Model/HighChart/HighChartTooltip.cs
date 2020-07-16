using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class HighChartTooltip
    {
        [JsonProperty("xDateFormat")] public string XDateFormat { get; set; }

        [JsonProperty("useHTML")] public bool UseHtml { get; set; }

        [JsonProperty("headerFormat")] public string HeaderFormat { get; set; }

        [JsonProperty("pointFormat")] public string PointFormat { get; set; }

        [JsonProperty("footerFormat")] public string FooterFormat { get; set; }
    }
}