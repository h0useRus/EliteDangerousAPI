using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RepairEvent : JournalEvent
    {
        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static RepairEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<RepairEvent>(json));
    }
}