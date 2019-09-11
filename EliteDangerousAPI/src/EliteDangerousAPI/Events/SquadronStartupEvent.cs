using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SquadronStartupEvent : SquadronEvent
    {
        [JsonProperty("CurrentRank")]
        public int CurrentRank { get; internal set; }

        internal static SquadronStartupEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(JsonHelper.FromJson<SquadronStartupEvent>(json));
    }
}