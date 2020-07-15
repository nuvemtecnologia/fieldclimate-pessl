using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartTooltip
    {
        [JsonProperty("xDateFormat")] public string XDateFormat { get; set; }

        [JsonProperty("useHTML")] public bool UseHTML { get; set; }

        [JsonProperty("headerFormat")] public string HeaderFormat { get; set; }

        [JsonProperty("pointFormat")] public string PointFormat { get; set; }

        [JsonProperty("footerFormat")] public string FooterFormat { get; set; }
    }
}