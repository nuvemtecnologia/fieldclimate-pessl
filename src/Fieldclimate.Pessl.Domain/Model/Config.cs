using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Config
    {
        [JsonProperty("timezone_offset")] public int TimezoneOffset { get; set; }

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
}