using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class BuyTradeDataEvent : JournalEvent
    {
        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyTradeDataEvent Execute(string json, API.EliteDangerousAPI api) => api.TradeEvents.InvokeEvent(api.FromJson<BuyTradeDataEvent>(json));
    }
}