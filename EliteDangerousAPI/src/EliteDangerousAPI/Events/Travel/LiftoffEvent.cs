using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class LiftoffEvent : JournalEvent
    {
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        [JsonProperty("NearestDestination")]
        public string NearestDestination { get; internal set; }

        internal static LiftoffEvent Execute(string json, API.EliteDangerousAPI api) => api.TravelEvents.InvokeEvent(api.FromJson<LiftoffEvent>(json));
    }
}