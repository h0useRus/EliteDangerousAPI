using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class ModuleInfo
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Priority")]
        public int Priority { get; internal set; }

        [JsonProperty("Power")]
        public double Power { get; internal set; }
    }
}