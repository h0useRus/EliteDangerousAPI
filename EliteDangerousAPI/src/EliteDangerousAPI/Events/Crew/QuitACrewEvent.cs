using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class QuitACrewEvent : JournalEvent
    {
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        internal static QuitACrewEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<QuitACrewEvent>(json));
    }
}