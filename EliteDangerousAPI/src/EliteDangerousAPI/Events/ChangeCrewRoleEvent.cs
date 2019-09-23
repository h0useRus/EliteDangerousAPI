using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class ChangeCrewRoleEvent : JournalEvent
    {
        [JsonProperty("Role")]
        public CrewRole Role { get; internal set; }

        internal static ChangeCrewRoleEvent Execute(string json, API.EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<ChangeCrewRoleEvent>(json));
    }
}