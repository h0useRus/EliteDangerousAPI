using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class TechnologyBrokerEvent : JournalEvent
    {
        [JsonProperty("BrokerType")]
        public string BrokerType { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("ItemsUnlocked")]
        public Item[] ItemsUnlocked { get; internal set; }

        [JsonProperty("Commodities")]
        public Commodity[] Commodities { get; internal set; }

        [JsonProperty("Materials")]
        public Commodity[] Materials { get; internal set; }

        internal static TechnologyBrokerEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<TechnologyBrokerEvent>(json));
    }
}