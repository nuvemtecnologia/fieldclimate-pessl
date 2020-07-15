using FieldClimate.Pessl.Domain.Model.HighChart;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Item
    {
        [JsonProperty("html")] public string Html { get; set; }

        [JsonProperty("style")] public HighChartStyle6 Style { get; set; }
    }
}