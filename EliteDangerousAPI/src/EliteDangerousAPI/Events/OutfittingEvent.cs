using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class OutfittingEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Horizons")]
        public bool? Horizons { get; set; }

        [JsonProperty("Items")]
        public OutfittingItem[] Items { get; set; }

        internal static OutfittingEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<OutfittingEvent>(json));
    }
}