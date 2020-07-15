using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Licenses
    {
        public bool AnimalProduction { get; set; }
        public bool Forecast { get; set; }
        public List<object> models { get; set; }
    }
}