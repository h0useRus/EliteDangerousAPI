using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
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