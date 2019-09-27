using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class BountyEvent : JournalEvent
    {
        [JsonProperty("Rewards")]
        public Reward[] Rewards { get; internal set; }

        [JsonProperty("Target")]
        public string Target { get; internal set; }

        [JsonProperty("TotalReward")]
        public long TotalReward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("SharedWithOthers")]
        public long SharedWithOthers { get; internal set; }

        internal static BountyEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<BountyEvent>(json));
    }
}