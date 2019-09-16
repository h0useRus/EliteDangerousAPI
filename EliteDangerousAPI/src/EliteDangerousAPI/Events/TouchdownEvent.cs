using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class TouchdownEvent : JournalEvent
    {
        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        internal static TouchdownEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<TouchdownEvent>(json));
    }
}