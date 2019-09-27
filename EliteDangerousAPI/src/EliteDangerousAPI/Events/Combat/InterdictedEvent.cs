using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class InterdictedEvent : JournalEvent
    {
        [JsonProperty("Submitted")]
        public bool Submitted { get; internal set; }

        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("CombatRank")]
        public CombatRank? CombatRank { get; internal set; }

        internal static InterdictedEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<InterdictedEvent>(json));
    }
}