using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Reward
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Reward")]
        public long Amount { get; internal set; }
    }
}