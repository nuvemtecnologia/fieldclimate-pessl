using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Geo
    {
        public List<double> coordinates { get; set; }
        public string type { get; set; }
    }
}