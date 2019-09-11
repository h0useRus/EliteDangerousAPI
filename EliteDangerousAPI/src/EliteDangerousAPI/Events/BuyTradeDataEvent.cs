using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class BuyTradeDataEvent : JournalEvent
    {
        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyTradeDataEvent Execute(string json, EliteDangerousAPI api) => api.Trade.InvokeEvent(JsonHelper.FromJson<BuyTradeDataEvent>(json));
    }
}