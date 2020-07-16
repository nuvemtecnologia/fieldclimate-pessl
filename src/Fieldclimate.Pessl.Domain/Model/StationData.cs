using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class StationData
    {
        /// <summary>
        /// lists all the dates and times for requested data.
        /// </summary>
        public List<string> dates { get; set; }
        
        /// <summary>
        /// contains all measured and requested calculated data.The data is listed in the same chronological order as the dates/times. So, for example, the first data listed (for each category) was measured at the first listed date and time.
        /// </summary>
        public List<Data> data { get; set; }
    }
}