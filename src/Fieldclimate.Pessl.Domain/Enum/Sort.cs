using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    /// <summary>
    /// SORT
    /// </summary>
    public enum Sort
    {
        /// <summary>
        /// ascended sort
        /// </summary>
        [Description("asc")] Asc,

        /// <summary>
        /// descended sort
        /// </summary>
        [Description("desc")] Desc
    }
}