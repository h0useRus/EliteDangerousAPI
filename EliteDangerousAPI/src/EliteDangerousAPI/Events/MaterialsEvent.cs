using Newtonsoft.Json;
using NSW.EliteDangerous.API;

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

        internal static MaterialsEvent Execute(string json, API.EliteDangerousAPI api) => api.Trade.InvokeEvent(api.FromJson<MaterialsEvent>(json));
    }
}