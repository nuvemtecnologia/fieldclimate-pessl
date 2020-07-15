namespace Fieldclimate.Pessl.Domain.Model
{
    public class Country
    {
        public CountryName name { get; set; }
        public string phoneCode { get; set; }
        public Iso iso { get; set; }
    }
}