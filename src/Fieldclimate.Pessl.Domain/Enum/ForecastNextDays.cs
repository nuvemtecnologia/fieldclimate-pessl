using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    /// <summary>
    /// Get general weather forecast for the next 3 or 7 days
    /// </summary>
    public enum ForecastNextDays
    {
        /// <summary>
        /// next 3 days
        /// </summary>
        [Description("general3")] General3 = 3,

        /// <summary>
        /// next 7 days
        /// </summary>
        [Description("general7")] General7 = 7
    }
}