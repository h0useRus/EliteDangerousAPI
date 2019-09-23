using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class ProspectedMaterial : Item
    {
        [JsonProperty("Proportion")]
        public double Proportion { get; set; }
    }
}