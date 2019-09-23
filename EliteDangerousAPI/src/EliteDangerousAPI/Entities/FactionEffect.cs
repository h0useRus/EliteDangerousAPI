using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class FactionEffect
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Effects")]
        public FactionInfluenceEffect[] Effects { get; internal set; }

        [JsonProperty("Influence")]
        public Influence[] Influence { get; internal set; }

        [JsonProperty("Reputation")]
        public string Reputation { get; internal set; }

        [JsonProperty("ReputationTrend")]
        public string ReputationTrend { get; internal set; }
    }
}