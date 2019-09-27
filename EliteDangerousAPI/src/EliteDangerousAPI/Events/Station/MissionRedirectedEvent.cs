using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
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

        internal static MissionRedirectedEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<MissionRedirectedEvent>(json));
    }
}