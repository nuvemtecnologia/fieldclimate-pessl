using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    /// <summary>
    /// Device data grouped
    /// </summary>
    public enum DataGroup
    {
        /// <summary>
        /// raw
        /// </summary>
        [Description("raw")] Raw,

        /// <summary>
        /// hourly
        /// </summary>
        [Description("hourly")] Hourly,

        /// <summary>
        /// daily
        /// </summary>
        [Description("daily")] Daily,

        /// <summary>
        /// monthly
        /// </summary>
        [Description("monthly")] Monthly
    }
}