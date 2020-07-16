using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Iso
    {
        [JsonProperty("639-1")] public string ISO_639_1 { get; set; }
        [JsonProperty("639-2")] public string ISO_639_2 { get; set; }
    }
}