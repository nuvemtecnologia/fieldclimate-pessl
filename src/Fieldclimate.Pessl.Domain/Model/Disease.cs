using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Disease
    {
        public string key { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public Settings settings { get; set; }
        public List<string> results { get; set; }
    }
}