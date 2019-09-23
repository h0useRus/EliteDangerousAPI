using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class BuyDronesEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; internal set; }

        internal static BuyDronesEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<BuyDronesEvent>(json));
    }
}