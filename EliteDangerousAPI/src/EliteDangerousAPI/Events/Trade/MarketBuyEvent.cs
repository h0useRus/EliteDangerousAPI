using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MarketBuyEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; internal set; }

        internal static MarketBuyEvent Execute(string json, API.EliteDangerousAPI api) => api.TradeEvents.InvokeEvent(api.FromJson<MarketBuyEvent>(json));
    }
}