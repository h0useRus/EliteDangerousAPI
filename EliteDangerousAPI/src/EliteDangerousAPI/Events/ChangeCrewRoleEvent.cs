using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ChangeCrewRoleEvent : JournalEvent
    {
        [JsonProperty("Role")]
        public string Role { get; internal set; }

        internal static ChangeCrewRoleEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<ChangeCrewRoleEvent>(json));
    }
}