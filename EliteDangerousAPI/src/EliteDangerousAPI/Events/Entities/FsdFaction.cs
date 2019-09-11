using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class FsdFaction
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
    }
}