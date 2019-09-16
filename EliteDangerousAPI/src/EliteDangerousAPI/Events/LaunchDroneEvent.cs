using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class LaunchDroneEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public DroneMission Type { get; internal set; }
        internal static LaunchDroneEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<LaunchDroneEvent>(json));
    }
}