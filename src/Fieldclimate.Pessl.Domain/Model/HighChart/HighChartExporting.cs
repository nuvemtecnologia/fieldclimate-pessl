using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [ExcludeFromCodeCoverage]
    public class HighChartExporting
    {
        [JsonProperty("enabled")] public bool Enabled { get; set; }
    }
}