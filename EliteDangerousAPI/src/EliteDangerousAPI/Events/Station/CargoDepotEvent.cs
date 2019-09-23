using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CargoDepotEvent : JournalEvent
    {
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("UpdateType")]
        public CargoUpdateType UpdateType { get; internal set; }

        [JsonProperty("CargoType")]
        public string CargoType { get; internal set; }

        [JsonProperty("CargoType_Localised")]
        public string CargoTypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("StartMarketID")]
        public long StartMarketId { get; internal set; }

        [JsonProperty("EndMarketID")]
        public long EndMarketId { get; internal set; }

        [JsonProperty("ItemsCollected")]
        public int ItemsCollected { get; internal set; }

        [JsonProperty("ItemsDelivered")]
        public int ItemsDelivered { get; internal set; }

        [JsonProperty("TotalItemsToDeliver")]
        public int TotalItemsToDeliver { get; internal set; }

        [JsonProperty("Progress")]
        public double Progress { get; internal set; }

        internal static CargoDepotEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<CargoDepotEvent>(json));
    }
}