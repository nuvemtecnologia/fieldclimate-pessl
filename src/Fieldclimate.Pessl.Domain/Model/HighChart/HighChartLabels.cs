using FieldClimate.Pessl.Domain.Model.HighChart;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class HighChartLabels
    {
        [JsonProperty("style")] public HighChartStyle3 Style { get; set; }
    }
}