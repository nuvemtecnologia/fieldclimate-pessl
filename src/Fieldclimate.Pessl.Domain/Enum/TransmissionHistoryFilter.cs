namespace Fieldclimate.Pessl.Domain.Enum
{
    public enum TransmissionHistoryFilter
    {
        unknown, 
        success, 
        resync, 
        registration,
        no_data, 
        xml_error, 
        fw_update,
        apn_update
    }
}