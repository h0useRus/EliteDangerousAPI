using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ResurrectEvent : JournalEvent
    {
        [JsonProperty("Option")]
        public string Option { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; internal set; }

        internal static ResurrectEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<ResurrectEvent>(json));
    }
}