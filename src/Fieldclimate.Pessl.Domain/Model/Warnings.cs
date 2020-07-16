using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Warnings
    {
        public List<string> sensors { get; set; }
        public List<SmsNumber> sms_numbers { get; set; }
    }
}