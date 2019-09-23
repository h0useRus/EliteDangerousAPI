using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MissionAbandonedEvent : MissionBaseEvent
    {
        [JsonProperty("Fine")]
        public int Fine { get; internal set; }

        internal static MissionAbandonedEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<MissionAbandonedEvent>(json));
    }
}