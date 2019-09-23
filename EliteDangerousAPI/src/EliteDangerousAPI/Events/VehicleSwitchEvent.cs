using Newtonsoft.Json;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Internals.Converters;

namespace NSW.EliteDangerous.Events
{
    public class VehicleSwitchEvent : JournalEvent
    {
        [JsonProperty("To")]
        [JsonConverter(typeof(VehicleEnumConverter))]
        public VehicleType To { get; internal set; }

        internal static VehicleSwitchEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<VehicleSwitchEvent>(json));
    }
}