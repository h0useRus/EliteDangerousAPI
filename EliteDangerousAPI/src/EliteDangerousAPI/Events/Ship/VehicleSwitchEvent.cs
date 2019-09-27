using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals.Converters;

namespace NSW.EliteDangerous.API.Events
{
    public class VehicleSwitchEvent : JournalEvent
    {
        [JsonProperty("To")]
        [JsonConverter(typeof(VehicleEnumConverter))]
        public VehicleType To { get; internal set; }

        internal static VehicleSwitchEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<VehicleSwitchEvent>(json));
    }
}