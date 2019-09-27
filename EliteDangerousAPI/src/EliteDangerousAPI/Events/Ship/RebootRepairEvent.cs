using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class RebootRepairEvent : JournalEvent
    {
        [JsonProperty("Modules")]
        public string[] Modules { get; internal set; }

        internal static RebootRepairEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<RebootRepairEvent>(json));
    }
}