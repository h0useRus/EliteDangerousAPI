using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class TopTier
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Bonus")]
        public string Bonus { get; set; }
    }
}