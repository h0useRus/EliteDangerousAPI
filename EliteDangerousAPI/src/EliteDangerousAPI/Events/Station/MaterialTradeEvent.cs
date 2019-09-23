using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
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

        internal static MaterialTradeEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<MaterialTradeEvent>(json));
    }
}