using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    public enum TimePeriod
    {
        [Description("h")]
        hour,
        
        [Description("d")]
        days,
        
        [Description("w")]
        weeks,
        
        [Description("m")]
        months
    }
}