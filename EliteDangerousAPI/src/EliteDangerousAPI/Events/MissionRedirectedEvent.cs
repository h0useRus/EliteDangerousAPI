using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MissionRedirectedEvent : MissionBaseEvent
    {
        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }

        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; internal set; }

        [JsonProperty("OldDestinationSystem")]
        public string OldDestinationSystem { get; internal set; }

        internal static MissionRedirectedEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<MissionRedirectedEvent>(json));
    }
}