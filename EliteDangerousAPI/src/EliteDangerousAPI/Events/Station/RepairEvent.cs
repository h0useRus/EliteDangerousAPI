using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class RepairEvent : JournalEvent
    {
        [JsonProperty("Item")]
        public string Item { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static RepairEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<RepairEvent>(json));
    }
}