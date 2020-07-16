using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [ExcludeFromCodeCoverage]
    public class HighChartItemStyle
    {
        [JsonProperty("fontSize")] public int FontSize { get; set; }
    }
}