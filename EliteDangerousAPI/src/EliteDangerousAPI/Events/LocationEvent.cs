using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class LocationEvent : JournalEvent
    {
        [JsonProperty("Docked")]
        public bool Docked { get; internal set; }

        [JsonProperty("MarketID")]
        public long? MarketId { get; internal set; }

        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public ulong? SystemAddress { get; internal set; }

        [JsonProperty("StarPos")]
        public double[] StarPos { get; internal set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; internal set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; internal set; }

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; internal set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; internal set; }

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; internal set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; internal set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; internal set; }

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; internal set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; internal set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; internal set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; internal set; }

        [JsonProperty("Population")]
        public long Population { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public BodyType? BodyType { get; internal set; }

        [JsonProperty("Powers")]
        public string[] Powers { get; internal set; }

        [JsonProperty("PowerplayState")]
        public string PowerplayState { get; internal set; }

        [JsonProperty("Factions")]
        public Faction[] Factions { get; internal set; }

        [JsonProperty("Latitude")]
        public double? Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double? Longitude { get; internal set; }

        [JsonProperty("DistFromStarLS")]
        public double? DistFromStarLs { get; internal set; }

        [JsonProperty("SystemFaction")]
        public SystemFaction SystemFaction { get; internal set; }

        [JsonProperty("StationFaction")]
        public SystemFaction StationFaction { get; internal set; }

        [JsonProperty("Conflicts")]
        public Conflict[] Conflicts { get; internal set; }

        internal static LocationEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(JsonHelper.FromJson<LocationEvent>(json));
    }
}