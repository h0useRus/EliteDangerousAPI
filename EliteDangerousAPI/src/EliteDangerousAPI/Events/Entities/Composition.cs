using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Composition : Item
    {
        [JsonProperty("Percent")]
        public double Percent { get; set; }
    }
}