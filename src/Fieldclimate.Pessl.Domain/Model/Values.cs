using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Values
    {
        public List<double> avg { get; set; }
        public List<int> sum { get; set; }
        public List<double?> max { get; set; }
        public List<int> last { get; set; }
        public List<double?> min { get; set; }
        public List<double?> result { get; set; }
    }
}