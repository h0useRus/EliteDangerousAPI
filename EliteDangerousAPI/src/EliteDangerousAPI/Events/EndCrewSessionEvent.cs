using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class EndCrewSessionEvent : JournalEvent
    {
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        internal static EndCrewSessionEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<EndCrewSessionEvent>(json));
    }
}