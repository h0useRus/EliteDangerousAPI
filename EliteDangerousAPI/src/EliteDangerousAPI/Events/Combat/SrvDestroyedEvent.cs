using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SrvDestroyedEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public string Id { get; internal set; }

        internal static SrvDestroyedEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<SrvDestroyedEvent>(json));
    }
}