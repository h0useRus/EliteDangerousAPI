using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class KickCrewMemberEvent : CrewEvent
    {
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        internal static KickCrewMemberEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<KickCrewMemberEvent>(json));
    }
}