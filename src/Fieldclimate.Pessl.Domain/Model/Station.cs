using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class Name
    {
        public string original { get; set; }
        public string custom { get; set; }
    }

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

    public class Dates
    {
        public string min_date { get; set; }
        public string max_date { get; set; }
        public string created_at { get; set; }
        public string last_communication { get; set; }
    }

    public class Geo
    {
        public List<double> coordinates { get; set; }
        public string type { get; set; }
    }

    public class Position
    {
        public double altitude { get; set; }
        public Geo geo { get; set; }
        public string timezoneCode { get; set; }
    }

    public class Config
    {
        public int timezone_offset { get; set; }
        public bool dst { get; set; }
        public double precision_reduction { get; set; }
        public int scheduler { get; set; }
        public string schedulerOld { get; set; }
        public int fixed_transfer_interval { get; set; }
        public int rain_monitor { get; set; }
        public int water_level_monitor { get; set; }
        public int data_interval { get; set; }
        public int activity_mode { get; set; }
        public int measuring_interval { get; set; }
        public int logging_interval { get; set; }
        public int? switch_input { get; set; }
    }

    public class Metadata
    {
        public string last_battery { get; set; }
    }

    public class Rain7D
    {
        public List<double> vals { get; set; }
        public double sum { get; set; }
    }

    public class Rain48H
    {
        public List<double> vals { get; set; }
        public double sum { get; set; }
    }

    public class Rain24H
    {
        public List<double> vals { get; set; }
        public double sum { get; set; }
    }

    public class Meta
    {
        public int time { get; set; }
        public double solarRadiation { get; set; }
        public int battery { get; set; }
        public double airTemp { get; set; }
        public double rh { get; set; }
        public Rain7D Rain7D { get; set; }
        public Rain48H rain48h { get; set; }
        public Rain24H rain24h { get; set; }
        public int? solarPanel { get; set; }
        public int? lw { get; set; }
    }

    public class Modem
    {
        public string brand { get; set; }
        public string type { get; set; }
        public string fwversion { get; set; }
    }

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

    public class SmsNumber
    {
        public string num { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    }

    public class Warnings
    {
        public List<string> sensors { get; set; }
        public List<SmsNumber> sms_numbers { get; set; }
    }

    public class Flags
    {
        public bool imeteopro { get; set; }
    }
    
    public class Licenses
    {
        public bool AnimalProduction { get; set; }
        public bool Forecast { get; set; }
        public List<object> models { get; set; }
    }

    public class Station
    {
        public Name name { get; set; }
        public string rights { get; set; }
        public Info info { get; set; }
        public Dates dates { get; set; }
        public Position position { get; set; }
        public Config config { get; set; }
        public Metadata metadata { get; set; }
        public Meta meta { get; set; }
        public string metaUnits { get; set; }
        public Networking networking { get; set; }
        public Warnings warnings { get; set; }
        public Flags flags { get; set; }
        public bool licenses { get; set; }
    }
    
    public class StationDetail
    {
        public Name name { get; set; }
        public string rights { get; set; }
        public Info info { get; set; }
        public string note { get; set; }
        public Dates dates { get; set; }
        public Position position { get; set; }
        public Config config { get; set; }
        public Metadata metadata { get; set; }
        public Meta meta { get; set; }
        public Networking networking { get; set; }
        public Warnings warnings { get; set; }
        public Flags flags { get; set; }
        public Licenses licenses { get; set; }
    }
}