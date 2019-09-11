using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Reward
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Reward")]
        public long Amount { get; internal set; }
    }
}