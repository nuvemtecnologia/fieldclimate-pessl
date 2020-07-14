using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class StationData
    {
        public List<string> dates { get; set; }
        public List<Datum> data { get; set; }
    }
}