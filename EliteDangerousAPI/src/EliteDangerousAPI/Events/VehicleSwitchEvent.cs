using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class VehicleSwitchEvent : JournalEvent
    {
        [JsonProperty("To")]
        public VehicleType To { get; internal set; }

        internal static VehicleSwitchEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<VehicleSwitchEvent>(json));
    }
}