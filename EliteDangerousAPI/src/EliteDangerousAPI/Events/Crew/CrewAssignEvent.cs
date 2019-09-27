using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CrewAssignEvent : CrewBaseEvent
    {
       
        [JsonProperty("Role")]
        public string Role { get; internal set; }

        internal static CrewAssignEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<CrewAssignEvent>(json));
    }
}