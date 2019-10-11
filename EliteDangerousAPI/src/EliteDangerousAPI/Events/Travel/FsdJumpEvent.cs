using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
{
    public class FsdJumpEvent : JournalEvent
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarPos")]
        public double[] StarPos { get; internal set; }

        [JsonProperty("SystemAllegiance")]
        public Allegiance? SystemAllegiance { get; internal set; }

        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; internal set; }

        [JsonIgnore]public EconomyType SystemEconomyType => EnumHelper.GetEconomyType(SystemEconomy);

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

        [JsonProperty("Population")]
        public long Population { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public BodyType BodyType { get; internal set; }
       
        [JsonProperty("SystemFaction")]
        public Faction SystemFaction { get; internal set; }

        [JsonProperty("Powers")]
        public string[] Powers { get; internal set; }

        [JsonProperty("PowerplayState")]
        public string PowerplayState { get; internal set; }

        [JsonProperty("JumpDist")]
        public double JumpDist { get; internal set; }

        [JsonProperty("FuelUsed")]
        public double FuelUsed { get; internal set; }

        [JsonProperty("BoostUsed")]
        public bool BoostUsed { get; internal set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("Factions")]
        public FactionDetails[] Factions { get; internal set; }

        [JsonProperty("Conflicts")]
        public Conflict[] Conflicts { get; internal set; }

        internal static FsdJumpEvent Execute(string json, API.EliteDangerousAPI api) => api.TravelEvents.InvokeEvent(api.FromJson<FsdJumpEvent>(json));
    }
}