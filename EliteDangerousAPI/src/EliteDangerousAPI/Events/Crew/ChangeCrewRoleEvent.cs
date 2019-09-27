using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ChangeCrewRoleEvent : JournalEvent
    {
        [JsonProperty("Role")]
        public CrewRole Role { get; internal set; }

        internal static ChangeCrewRoleEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<ChangeCrewRoleEvent>(json));
    }
}