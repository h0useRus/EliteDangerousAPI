using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class NpcCrewPaidWageEvent : JournalEvent
    {
        [JsonProperty("NpcCrewName")]
        public string NpcCrewName { get; internal set; }

        [JsonProperty("NpcCrewId")]
        public long NpcCrewId { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        internal static NpcCrewPaidWageEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<NpcCrewPaidWageEvent>(json));
    }
}