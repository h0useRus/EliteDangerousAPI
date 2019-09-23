using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class CrewMemberRoleChangeEvent : CrewEvent
    {
        [JsonProperty("Role")]
        public CrewRole Role { get; internal set; }

        internal static CrewMemberRoleChangeEvent Execute(string json, API.EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<CrewMemberRoleChangeEvent>(json));
    }
}