using Newtonsoft.Json;

namespace FieldClimate.Pessl.Domain.Model.HighChart
{
    public class HighChartTitle2
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("align")] public string Align { get; set; }
    }
}