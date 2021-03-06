using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class AsteroidCrackedEvent : JournalEvent
    {
        [JsonProperty("Body")]
        public string Body { get; internal set; }

        internal static AsteroidCrackedEvent Execute(string json, API.EliteDangerousAPI api) => api.TradeEvents.InvokeEvent(api.FromJson<AsteroidCrackedEvent>(json));
    }
}