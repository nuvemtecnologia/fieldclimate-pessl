using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    [ExcludeFromCodeCoverage]
    public class HighChartCredits
    {
        [JsonProperty("enabled")] public bool Enabled { get; set; }
    }
}