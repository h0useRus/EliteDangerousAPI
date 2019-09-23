using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class LaunchDroneEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public DroneMission Type { get; internal set; }
        internal static LaunchDroneEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<LaunchDroneEvent>(json));
    }
}