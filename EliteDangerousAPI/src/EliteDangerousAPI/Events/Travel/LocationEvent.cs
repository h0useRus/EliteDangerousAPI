using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
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
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarPos")]
        public double[] StarPos { get; internal set; }

        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; internal set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; internal set; }

        [JsonIgnore] public EconomyType SystemEconomyType => EnumHelper.GetEconomyType(SystemEconomy);

        [JsonProperty("SystemEconomy_Localised")]
        public string SystemEconomyLocalised { get; internal set; }

        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; internal set; }

        [JsonIgnore] public EconomyType SystemSecondEconomyType => EnumHelper.GetEconomyType(SystemSecondEconomy);

        [JsonProperty("SystemSecondEconomy_Localised")]
        public string SystemSecondEconomyLocalised { get; internal set; }

        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; internal set; }

        [JsonProperty("SystemGovernment_Localised")]
        public string SystemGovernmentLocalised { get; internal set; }

        [JsonIgnore]public GovernmentType SystemGovernmentType => EnumHelper.GetGovernmentType(SystemGovernment);

        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; internal set; }

        [JsonProperty("SystemSecurity_Localised")]
        public string SystemSecurityLocalised { get; internal set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; internal set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; internal set; }

        [JsonIgnore]public GovernmentType StationGovernmentType => EnumHelper.GetGovernmentType(StationGovernment);

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; internal set; }

        [JsonProperty("StationServices")]
        public string[] StationServices { get; internal set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; internal set; }

        [JsonIgnore] public EconomyType StationEconomyType => EnumHelper.GetEconomyType(StationEconomy);

        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomyLocalised { get; internal set; }

        [JsonProperty("StationEconomies")]
        public StationEconomy[] StationEconomies { get; internal set; }

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
        public FactionDetails[] Factions { get; internal set; }

        [JsonProperty("Latitude")]
        public double? Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double? Longitude { get; internal set; }

        [JsonProperty("DistFromStarLS")]
        public double DistFromStarLs { get; internal set; }

        [JsonProperty("SystemFaction")]
        public Faction SystemFaction { get; internal set; }

        [JsonProperty("StationFaction")]
        public Faction StationFaction { get; internal set; }

        [JsonProperty("Conflicts")]
        public Conflict[] Conflicts { get; internal set; }

        internal static LocationEvent Execute(string json, API.EliteDangerousAPI api) => api.TravelEvents.InvokeEvent(api.FromJson<LocationEvent>(json));
    }
}