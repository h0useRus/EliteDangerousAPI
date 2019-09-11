using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SellShipOnRebuyEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("SellShipId")]
        public long SellShipId { get; internal set; }
        
        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; internal set; }

        internal static SellShipOnRebuyEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<SellShipOnRebuyEvent>(json));
    }
}