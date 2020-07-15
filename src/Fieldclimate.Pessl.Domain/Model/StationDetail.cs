namespace Fieldclimate.Pessl.Domain.Model
{
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