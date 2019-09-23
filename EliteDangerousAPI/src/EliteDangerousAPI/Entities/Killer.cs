using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Killer
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("Rank")]
        public CombatRank Rank { get; internal set; }
    }
}