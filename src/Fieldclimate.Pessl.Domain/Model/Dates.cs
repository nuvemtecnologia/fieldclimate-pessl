using System;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Dates
    {
        public DateTimeOffset min_date { get; set; }
        public DateTimeOffset max_date { get; set; }
        public DateTimeOffset created_at { get; set; }
        public DateTimeOffset last_communication { get; set; }
    }
}