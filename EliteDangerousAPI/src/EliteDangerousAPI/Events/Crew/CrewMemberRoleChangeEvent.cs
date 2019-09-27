using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CrewMemberRoleChangeEvent : CrewEvent
    {
        [JsonProperty("Role")]
        public CrewRole Role { get; internal set; }

        internal static CrewMemberRoleChangeEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<CrewMemberRoleChangeEvent>(json));
    }
}