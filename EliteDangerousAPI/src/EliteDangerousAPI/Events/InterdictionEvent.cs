using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class InterdictionEvent : JournalEvent
    {
        [JsonProperty("Success")]
        public bool Success { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("Interdicted")]
        public string Interdicted { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("CombatRank")]
        public CombatRank? CombatRank { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        private static InterdictionEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<InterdictionEvent>(json));
    }
}