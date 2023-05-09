using Newtonsoft.Json;

namespace GUSAPI.Model
{
    public class ObszarTematyczny
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }

        [JsonProperty("Id-Nadrzedny-Element")]
        public int? IdNadrzednyElement { get; set; }

        [JsonProperty("Id-Poziom")]
        public int? IdPoziom { get; set; }

        [JsonProperty("Nazwa-Poziom")]
        public string? NazwaPoziom { get; set; }
    }
}
