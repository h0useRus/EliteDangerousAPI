using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ContinuedEvent : JournalEvent
    {
        [JsonProperty("Part")]
        public string Part { get; internal set; }

        internal static ContinuedEvent Execute(string json, API.EliteDangerousAPI api) => api.GameEvents.InvokeEvent(api.FromJson<ContinuedEvent>(json));
    }
}