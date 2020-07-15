using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartItemStyle
    {
        [JsonProperty("fontSize")] public int FontSize { get; set; }
    }
}