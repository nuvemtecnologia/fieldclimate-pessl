namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Networking
    {
        public string type { get; set; }
        public string mnc { get; set; }
        public string mcc { get; set; }
        public string mcc_sim { get; set; }
        public string mnc_sim { get; set; }
        public string apn { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool roaming { get; set; }
        public string provider { get; set; }
        public string provider_sim { get; set; }
        public string ssid { get; set; }
        public string meid { get; set; }
        public Modem modem { get; set; }
        public string country { get; set; }
        public object imei { get; set; }
        public object simid { get; set; }
    }
}