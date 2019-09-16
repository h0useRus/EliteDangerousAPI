using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MaterialTradeEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("TraderType")]
        public string TraderType { get; set; }

        [JsonProperty("Paid")]
        public MaterialTransaction Paid { get; set; }

        [JsonProperty("Received")]
        public MaterialTransaction Received { get; set; }

        internal static MaterialTradeEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<MaterialTradeEvent>(json));
    }
}