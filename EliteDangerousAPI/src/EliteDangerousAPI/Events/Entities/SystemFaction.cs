using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class SystemFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FactionState")]
        public string State { get; internal set; }
    }
}