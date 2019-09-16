using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class CrewMemberRoleChangeEvent : CrewEvent
    {
        [JsonProperty("Role")]
        public CrewRole Role { get; internal set; }

        internal static CrewMemberRoleChangeEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<CrewMemberRoleChangeEvent>(json));
    }
}