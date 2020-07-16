using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class SystemDisease
    {
        public string group { get; set; }
        public List<Disease> models { get; set; }
        public string title { get; set; }
        public bool active { get; set; }
    }
}