using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RebootRepairEvent : JournalEvent
    {
        [JsonProperty("Modules")]
        public string[] Modules { get; internal set; }

        internal static RebootRepairEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<RebootRepairEvent>(json));
    }
}