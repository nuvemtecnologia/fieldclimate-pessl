namespace Fieldclimate.Pessl.Domain.Model
{
    public class Meta
    {
        public int time { get; set; }
        public double solarRadiation { get; set; }
        public int battery { get; set; }
        public double airTemp { get; set; }
        public double rh { get; set; }
        public Rain rain7d { get; set; }
        public Rain rain48h { get; set; }
        public Rain rain24h { get; set; }
        public int? solarPanel { get; set; }
        public int? lw { get; set; }
    }
}