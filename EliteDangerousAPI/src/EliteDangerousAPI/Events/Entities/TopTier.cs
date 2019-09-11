using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class TopTier
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Bonus")]
        public string Bonus { get; set; }
    }
}