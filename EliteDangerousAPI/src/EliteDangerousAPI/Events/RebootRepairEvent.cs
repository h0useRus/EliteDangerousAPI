using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RebootRepairEvent : JournalEvent
    {
        [JsonProperty("Modules")]
        public string[] Modules { get; internal set; }

        internal static RebootRepairEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<RebootRepairEvent>(json));
    }
}