using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CrewMemberRoleChangeEvent : CrewEvent
    {
        [JsonProperty("Role")]
        public string Role { get; internal set; }

        internal static CrewMemberRoleChangeEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<CrewMemberRoleChangeEvent>(json));
    }
}