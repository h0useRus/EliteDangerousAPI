using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SrvDestroyedEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public string Id { get; internal set; }

        internal static SrvDestroyedEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<SrvDestroyedEvent>(json));
    }
}