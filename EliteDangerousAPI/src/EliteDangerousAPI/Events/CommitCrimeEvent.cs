using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class CommitCrimeEvent : JournalEvent
    {
        [JsonProperty("CrimeType")]
        public CrimeType CrimeType { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("Victim_Localised")]
        public string VictimLocalised { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        internal static CommitCrimeEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<CommitCrimeEvent>(json));
    }
}