using System;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MissionAcceptedEvent : MissionBaseEvent
    {
        [JsonProperty("LocalisedName")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("TargetType")]
        public string TargetType { get; internal set; }

        [JsonProperty("TargetType_Localised")]
        public string TargetTypeLocalised { get; internal set; }

        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; internal set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; internal set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; internal set; }

        [JsonProperty("Target")]
        public string Target { get; internal set; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; internal set; }

        [JsonProperty("Wing")]
        public bool Wing { get; internal set; }

        [JsonProperty("Influence")]
        public string Influence { get; internal set; }

        [JsonProperty("Reputation")]
        public string Reputation { get; internal set; }

        [JsonProperty("Reward")]
        public long? Reward { get; internal set; }

        [JsonProperty("Donation")]
        public string Donation { get; internal set; }

        [JsonProperty("Commodity")]
        public string Commodity { get; internal set; }

        [JsonProperty("Commodity_Localised")]
        public string CommodityLocalised { get; internal set; }

        [JsonProperty("Count")]
        public int? Count { get; internal set; }

        [JsonProperty("KillCount")]
        public int? KillCount { get; internal set; }

        [JsonProperty("PassengerType")]
        public string PassengerType { get; internal set; }

        [JsonProperty("PassengerCount")]
        public long? PassengerCount { get; internal set; }

        [JsonProperty("PassengerWanted")]
        public bool? PassengerWanted { get; internal set; }

        [JsonProperty("PassengerVIPs")]
        public bool? PassengerVIPs { get; internal set; }

        internal static MissionAcceptedEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<MissionAcceptedEvent>(json));
    }
}