using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
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

        internal static TechnologyBrokerEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<TechnologyBrokerEvent>(json));
    }
}