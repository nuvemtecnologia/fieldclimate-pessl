using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public enum ChartType
    {
        /// <summary>
        /// image
        /// </summary>
        [Description("image")] Image = 1,

        /// <summary>
        /// multiple images
        /// </summary>
        [Description("images")] Images = 2,

        /// <summary>
        /// highchart
        /// </summary>
        [Description("highchart")] Highchart = 3
    }
}