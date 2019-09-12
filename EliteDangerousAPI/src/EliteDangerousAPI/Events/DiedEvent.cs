using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DiedEvent : JournalEvent
    {
        [JsonProperty("KillerName")]
        public string KillerName { get; internal set; }

        [JsonProperty("KillerName_Localised")]
        public string KillerNameLocalised { get; internal set; }

        [JsonProperty("KillerShip")]
        public string KillerShip { get; internal set; }

        [JsonProperty("KillerRank")]
        public CombatRank KillerRank { get; internal set; }

        [JsonProperty("Killers")]
        public Killer[] Killers { get; internal set; }

        internal static DiedEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<DiedEvent>(json));
    }
}