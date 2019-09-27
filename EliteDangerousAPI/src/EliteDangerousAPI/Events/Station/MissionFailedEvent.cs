using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MissionFailedEvent : MissionBaseEvent
    {
        [JsonProperty("Fine")]
        public int Fine { get; internal set; }

        internal static MissionFailedEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<MissionFailedEvent>(json));
    }
}