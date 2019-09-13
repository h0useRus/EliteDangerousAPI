using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MissionAbandonedEvent : MissionBaseEvent
    {
        [JsonProperty("Fine")]
        public int Fine { get; internal set; }

        internal static MissionAbandonedEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<MissionAbandonedEvent>(json));
    }
}