using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
{
    public class ShipyardNewEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonIgnore] public ShipModel ShipModel => EnumHelper.GetShipModel(ShipType);

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }

        internal static ShipyardNewEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<ShipyardNewEvent>(json));
    }
}