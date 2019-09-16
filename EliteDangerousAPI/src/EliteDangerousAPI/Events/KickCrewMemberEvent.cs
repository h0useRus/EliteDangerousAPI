using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class KickCrewMemberEvent : CrewEvent
    {
        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        internal static KickCrewMemberEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<KickCrewMemberEvent>(json));
    }
}