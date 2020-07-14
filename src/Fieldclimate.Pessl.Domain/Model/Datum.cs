using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Datum
    {
        public string name { get; set; }
        public string name_original { get; set; }
        public string type { get; set; }
        public int decimals { get; set; }
        public object unit { get; set; }
        public int ch { get; set; }
        public int code { get; set; }
        public int group { get; set; }
        public string serial { get; set; }
        public string mac { get; set; }
        public string registered { get; set; }
        public Vals vals { get; set; }
        public List<string> aggr { get; set; }
        public Values values { get; set; }
    }
}