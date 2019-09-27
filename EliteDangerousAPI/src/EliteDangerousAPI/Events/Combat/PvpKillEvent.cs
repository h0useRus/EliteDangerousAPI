using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PvpKillEvent : JournalEvent
    {
        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("CombatRank")]
        public CombatRank CombatRank { get; internal set; }

        internal static PvpKillEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<PvpKillEvent>(json));
    }
}