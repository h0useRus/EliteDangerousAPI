using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CrewHireEvent : CrewBaseEvent
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("CombatRank")]
        public CombatRank CombatRank { get; internal set; }

        internal static CrewHireEvent Execute(string json, API.EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<CrewHireEvent>(json));
    }
}