using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    /// <summary>
    /// forecast image type
    /// </summary>
    public enum ForecastOptionImage
    {
        /// <summary>
        /// Get localized 7 days forecast pictoprint in JPG format
        /// </summary>
        [Description("pictoprint")] Pictoprint,
        
        /// <summary>
        /// Get localized 7 and 14 days forecast overviews in PNG format
        /// </summary>
        [Description("meteogram_agro")]
        MeteogramAgro,
        
        /// <summary>
        /// Get localized 7 and 14 days forecast overviews in PNG format
        /// </summary>
        [Description("meteogram_one")]
        MeteogramOne,
        
        /// <summary>
        /// Get localized 7 and 14 days forecast overviews in PNG format
        /// </summary>
        [Description("meteogram_14day")]
        Meteogram14Day
    }
}