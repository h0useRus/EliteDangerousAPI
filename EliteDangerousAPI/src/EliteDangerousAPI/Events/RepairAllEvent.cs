using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RepairAllEvent : JournalEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static RepairAllEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<RepairAllEvent>(json));
    }
}