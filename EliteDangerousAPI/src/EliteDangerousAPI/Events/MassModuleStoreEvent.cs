using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MassModuleStoreEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("Items")]
        public ItemDetails[] Items { get; internal set; }

        internal static MassModuleStoreEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<MassModuleStoreEvent>(json));
    }
}