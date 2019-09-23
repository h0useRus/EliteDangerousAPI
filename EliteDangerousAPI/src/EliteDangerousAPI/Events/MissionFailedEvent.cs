using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MissionFailedEvent : MissionBaseEvent
    {
        [JsonProperty("Fine")]
        public int Fine { get; internal set; }

        internal static MissionFailedEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<MissionFailedEvent>(json));
    }
}