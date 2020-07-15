using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class StationDisease
    {
        public List<string> dates { get; set; } 
        public List<Data> data { get; set; } 

    }
}