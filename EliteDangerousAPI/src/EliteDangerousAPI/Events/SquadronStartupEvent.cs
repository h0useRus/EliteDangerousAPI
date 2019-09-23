using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SquadronStartupEvent : SquadronEvent
    {
        [JsonProperty("CurrentRank")]
        public int CurrentRank { get; internal set; }

        internal static SquadronStartupEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<SquadronStartupEvent>(json));
    }
}