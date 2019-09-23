using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Faction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string State { get; internal set; }
    }
}