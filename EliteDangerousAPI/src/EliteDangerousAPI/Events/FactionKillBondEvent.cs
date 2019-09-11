using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FactionKillBondEvent : JournalEvent
    {
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("AwardingFaction")]
        public string AwardingFaction { get; internal set; }

        [JsonProperty("AwardingFaction_Localised")]
        public string AwardingFactionLocalised { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("VictimFaction_Localised")]
        public string VictimFactionLocalised { get; internal set; }

        internal static FactionKillBondEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<FactionKillBondEvent>(json));
    }
}