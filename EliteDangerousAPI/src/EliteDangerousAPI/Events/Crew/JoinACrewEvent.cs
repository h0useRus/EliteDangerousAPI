using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class JoinACrewEvent : JournalEvent
    {
        [JsonProperty("Captain")]
        public string Captain { get; set; }

        internal static JoinACrewEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<JoinACrewEvent>(json));
    }
}