using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class RepairAllEvent : JournalEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static RepairAllEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<RepairAllEvent>(json));
    }
}