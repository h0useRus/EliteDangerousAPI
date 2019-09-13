using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CrewAssignEvent : CrewBaseEvent
    {
       
        [JsonProperty("Role")]
        public string Role { get; internal set; }

        internal static CrewAssignEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<CrewAssignEvent>(json));
    }
}