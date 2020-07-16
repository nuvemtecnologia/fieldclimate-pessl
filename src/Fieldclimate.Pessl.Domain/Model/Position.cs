namespace Fieldclimate.Pessl.Domain.Model
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Position
    {
        public double altitude { get; set; }
        public Geo geo { get; set; }
        public string timezoneCode { get; set; }
    }
}