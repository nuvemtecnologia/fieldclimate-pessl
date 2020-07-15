namespace Fieldclimate.Pessl.Domain.Model
{
    public class Info
    {
        public int device_id { get; set; }
        public string device_name { get; set; }
        public string uid { get; set; }
        public object firmware { get; set; }
        public object hardware { get; set; }
        public string programmed { get; set; }
        public string description { get; set; }
        public int? apn_table { get; set; }
        public int? max_time { get; set; }
    }
}