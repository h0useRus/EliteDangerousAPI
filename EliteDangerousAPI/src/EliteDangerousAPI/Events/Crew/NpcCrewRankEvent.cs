using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class NpcCrewRankEvent : JournalEvent
    {
        [JsonProperty("NpcCrewName")]
        public string NpcCrewName { get; internal set; }

        [JsonProperty("NpcCrewId")]
        public long NpcCrewId { get; internal set; }

        [JsonProperty("RankCombat")]
        public CombatRank Rank { get; internal set; }

        internal static NpcCrewRankEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<NpcCrewRankEvent>(json));
    }
}