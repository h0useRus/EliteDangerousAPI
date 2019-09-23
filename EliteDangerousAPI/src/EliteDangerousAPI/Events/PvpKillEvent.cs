using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class PvpKillEvent : JournalEvent
    {
        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("CombatRank")]
        public CombatRank CombatRank { get; internal set; }

        internal static PvpKillEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<PvpKillEvent>(json));
    }
}