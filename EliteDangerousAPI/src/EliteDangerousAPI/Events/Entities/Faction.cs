using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Faction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string FactionState { get; internal set; }
    }
}