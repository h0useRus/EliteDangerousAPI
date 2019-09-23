using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ScreenshotEvent : JournalEvent
    {
        [JsonProperty("Filename")]
        public string Filename { get; internal set; }

        [JsonProperty("Width")]
        public long Width { get; internal set; }

        [JsonProperty("Height")]
        public long Height { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        [JsonProperty("Heading")]
        public long Heading { get; internal set; }

        [JsonProperty("Altitude")]
        public double Altitude { get; internal set; }

        internal static ScreenshotEvent Execute(string json, API.EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<ScreenshotEvent>(json));
    }
}