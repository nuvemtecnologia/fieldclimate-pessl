using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Rain
    {
        public List<double> vals { get; set; }
        public double sum { get; set; }
    }
}