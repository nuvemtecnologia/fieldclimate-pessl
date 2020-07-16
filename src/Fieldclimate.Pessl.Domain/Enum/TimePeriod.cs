using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    /// <summary>
    /// TIME-PERIOD
    /// </summary>
    public enum TimePeriod
    {
        /// <summary>
        /// Read Xh which means X amount of hours
        /// </summary>
        [Description("h")]
        Hour,
        
        /// <summary>
        /// Read Xd which means X amount of days
        /// </summary>
        [Description("d")]
        Days,
        
        /// <summary>
        /// Read Xw which means X amount of weeks
        /// </summary>
        [Description("w")]
        Weeks,
        
        /// <summary>
        /// Read Xm which means X amount of months
        /// </summary>
        [Description("m")]
        Months
    }
}