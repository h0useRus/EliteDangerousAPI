using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CrewHireEvent : CrewBaseEvent
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("CombatRank")]
        public CombatRank CombatRank { get; internal set; }

        internal static CrewHireEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<CrewHireEvent>(json));
    }
}