using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Values
    {
        public List<double?> avg { get; set; }
        public List<double?> sum { get; set; }
        public List<double?> max { get; set; }
        public List<double?> last { get; set; }
        public List<double?> min { get; set; }
        public List<double?> result { get; set; }
    }
}