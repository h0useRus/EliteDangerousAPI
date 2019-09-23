using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SellDronesEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }

        [JsonProperty("TotalSale")]
        public long TotalSale { get; internal set; }

        internal static SellDronesEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<SellDronesEvent>(json));
    }
}