using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class ExplorationData
    {
        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }
    }
}