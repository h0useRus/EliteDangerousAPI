using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CrimeVictimEvent : JournalEvent
    {
        [JsonProperty("Offender")]
        public string Offender { get; internal set; }

        [JsonProperty("Offender_Localised")]
        public string OffenderLocalised { get; internal set; }

        [JsonProperty("CrimeType")]
        public CrimeType CrimeType { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        internal static CrimeVictimEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<CrimeVictimEvent>(json));
    }
}