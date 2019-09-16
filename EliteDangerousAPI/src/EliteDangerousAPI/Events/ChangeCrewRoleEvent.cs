using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class ChangeCrewRoleEvent : JournalEvent
    {
        [JsonProperty("Role")]
        public CrewRole Role { get; internal set; }

        internal static ChangeCrewRoleEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<ChangeCrewRoleEvent>(json));
    }
}