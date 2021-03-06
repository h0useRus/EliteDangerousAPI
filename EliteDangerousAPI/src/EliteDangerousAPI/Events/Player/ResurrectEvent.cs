using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ResurrectEvent : JournalEvent
    {
        [JsonProperty("Option")]
        public string Option { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; internal set; }

        internal static ResurrectEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<ResurrectEvent>(json));
    }
}