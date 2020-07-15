using System.Collections.Generic;

namespace Fieldclimate.Pessl.Domain.Model
{
    public class SystemDisease
    {
        public string group { get; set; }
        public List<SystemModelDisease> models { get; set; }
        public string title { get; set; }
        public bool active { get; set; }
    }
}