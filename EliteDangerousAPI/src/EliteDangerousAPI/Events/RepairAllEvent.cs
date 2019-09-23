using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RepairAllEvent : JournalEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static RepairAllEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<RepairAllEvent>(json));
    }
}