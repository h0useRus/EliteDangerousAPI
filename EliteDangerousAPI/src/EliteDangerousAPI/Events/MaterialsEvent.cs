using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MaterialsEvent : JournalEvent
    {
        [JsonProperty("Raw")]
        public Material[] Raw { get; set; }

        [JsonProperty("Manufactured")]
        public Material[] Manufactured { get; set; }

        [JsonProperty("Encoded")]
        public Material[] Encoded { get; set; }

        internal static MaterialsEvent Execute(string json, EliteDangerousAPI api) => api.Trade.InvokeEvent(api.FromJson<MaterialsEvent>(json));
    }
}