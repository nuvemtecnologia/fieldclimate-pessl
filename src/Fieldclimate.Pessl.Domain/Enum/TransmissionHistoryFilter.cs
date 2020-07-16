using System.ComponentModel;

namespace Fieldclimate.Pessl.Domain.Enum
{
    /// <summary>
    /// Filter out station history by its flag
    /// </summary>
    public enum TransmissionHistoryFilter
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("unknown")]
        Unknown, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("success")]
        Success, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("resync")]
        Resync, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("registration")]
        Registration,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("no_data")]
        NoData, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("xml_error")]
        XmlError, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("fw_update")]
        FwUpdate,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("apn_update")]
        ApnUpdate
    }
}