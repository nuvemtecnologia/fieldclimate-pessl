using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class ForecastGeneral
    {
        public List<string> dates { get; set; }
        public List<Data> data { get; set; }
    }
}