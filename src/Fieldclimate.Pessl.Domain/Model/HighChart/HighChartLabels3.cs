using System.Collections.Generic;
using Fieldclimate.Pessl.Domain.Model;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class HighChartLabels3
    {
        [JsonProperty("items")] public List<Item> Items { get; set; }

        [JsonProperty("style")] public Style7 Style { get; set; }
    }
}