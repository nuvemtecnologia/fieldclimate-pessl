using System;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class DateStation
    {
        public DateTimeOffset min_date { get; set; }
        public DateTimeOffset max_date { get; set; }
    }
}