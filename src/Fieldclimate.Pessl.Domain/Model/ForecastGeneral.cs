using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class ForecastGeneral
    {
        public List<string> dates { get; set; }
        public List<Datum> data { get; set; }
    }
}