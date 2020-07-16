using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Sensor
    {
        public string name { get; set; }
        public string name_custom { get; set; }
        public string color { get; set; }
        public int decimals { get; set; }
        public int divider { get; set; }
        public int multiplier { get; set; }
        public string size { get; set; }
        public string unit { get; set; }
        public string unit_default { get; set; }
        public string calibration_id { get; set; }
        public IsUserSet is_user_set { get; set; }
        public List<string> units { get; set; }
        public int ch { get; set; }
        public int code { get; set; }
        public int group { get; set; }
        public string mac { get; set; }
        public string serial { get; set; }
        public Vals vals { get; set; }
        public List<string> aggr { get; set; }
        public string registered { get; set; }
        public bool isActive { get; set; }
        public string desc { get; set; }
    }
}