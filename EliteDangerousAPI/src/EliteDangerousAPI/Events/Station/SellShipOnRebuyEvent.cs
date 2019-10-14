using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
{
    public class SellShipOnRebuyEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonIgnore] public ShipModel ShipModel => EnumHelper.GetShipModel(ShipType);

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("SellShipId")]
        public long SellShipId { get; internal set; }
        
        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; internal set; }

        internal static SellShipOnRebuyEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<SellShipOnRebuyEvent>(json));
    }
}