using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class StoredModulesEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Items")]
        public StoredItem[] Items { get; set; }

        internal static StoredModulesEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<StoredModulesEvent>(json));
    }
}