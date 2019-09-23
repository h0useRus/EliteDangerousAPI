using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals.Converters;

namespace NSW.EliteDangerous.API.Events
{
    public class ShipTargetedEvent : JournalEvent
    {
        [JsonProperty("TargetLocked")]
        public bool TargetLocked { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; internal set; }

        [JsonProperty("ScanStage")]
        public long ScanStage { get; internal set; }

        [JsonProperty("PilotName")]
        public string PilotName { get; internal set; }

        [JsonProperty("PilotName_Localised")]
        public string PilotNameLocalised { get; internal set; }

        [JsonProperty("PilotRank")]
        [JsonConverter(typeof(CombatRankConverter))]
        public CombatRank? PilotRank { get; internal set; }

        [JsonProperty("ShieldHealth")]
        public double ShieldHealth { get; internal set; }

        [JsonProperty("HullHealth")]
        public double HullHealth { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("LegalStatus")]
        public string LegalStatus { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        [JsonProperty("Subsystem")]
        public string Subsystem { get; internal set; }

        [JsonProperty("Subsystem_Localised")]
        public string SubsystemLocalised { get; internal set; }

        [JsonProperty("SubsystemHealth")]
        public double SubsystemHealth { get; internal set; }

        internal static ShipTargetedEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<ShipTargetedEvent>(json));
    }
}