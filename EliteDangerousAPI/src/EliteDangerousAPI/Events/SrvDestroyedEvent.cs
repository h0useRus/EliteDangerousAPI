using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SrvDestroyedEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public string Id { get; internal set; }

        internal static SrvDestroyedEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<SrvDestroyedEvent>(json));
    }
}