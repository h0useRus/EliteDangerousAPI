using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Conflict
    {
        [JsonProperty("WarType")]
        public string WarType { get; internal set; }

        [JsonProperty("Status")]
        public string Status { get; internal set; }

        [JsonProperty("Faction1")]
        public ConflictFaction Faction1 { get; internal set; }

        [JsonProperty("Faction2")]
        public ConflictFaction Faction2 { get; internal set; }
    }
}