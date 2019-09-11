using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MissionCompletedEvent : JournalEvent
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("Commodity")]
        public string Commodity { get; internal set; }

        [JsonProperty("Commodity_Localised")]
        public string CommodityLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long? Count { get; internal set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; internal set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; internal set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }

        [JsonProperty("Reward")]
        public long? Reward { get; internal set; }

        [JsonProperty("Donation")]
        public string Donation { get; internal set; }

        [JsonProperty("Donated")]
        public long? Donated { get; internal set; }

        [JsonProperty("CommodityReward")]
        public CommodityReward[] CommodityReward { get; internal set; }

        [JsonProperty("MaterialsReward")]
        public MaterialsReward[] MaterialsReward { get; internal set; }

        [JsonProperty("FactionEffects")]
        public FactionEffect[] FactionEffects { get; internal set; }

        [JsonProperty("TargetType")]
        public string TargetType { get; internal set; }

        [JsonProperty("TargetType_Localised")]
        public string TargetTypeLocalised { get; internal set; }

        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; internal set; }

        [JsonProperty("Target")]
        public string Target { get; internal set; }

        internal static MissionCompletedEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<MissionCompletedEvent>(json));
    }
}