using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Composition
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Percent")]
        public double Percent { get; set; }
    }
}