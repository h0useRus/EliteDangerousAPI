using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DockedEvent : DockEvent
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StationGovernment")]
        public string StationGovernment { get; internal set; }

        [JsonProperty("StationGovernment_Localised")]
        public string StationGovernmentLocalised { get; internal set; }

        [JsonProperty("StationAllegiance")]
        public string StationAllegiance { get; internal set; }

        [JsonProperty("StationServices")]
        public string[] StationServices { get; internal set; }

        [JsonProperty("StationEconomy")]
        public string StationEconomy { get; internal set; }

        [JsonProperty("StationEconomy_Localised")]
        public string StationEconomyLocalised { get; internal set; }

        [JsonProperty("StationEconomies")]
        public StationEconomy[] StationEconomies { get; internal set; }

        [JsonProperty("DistFromStarLS")]
        public double DistFromStarLs { get; internal set; }

        [JsonProperty("StationFaction")]
        public Faction StationFaction { get; internal set; }

        [JsonProperty("CockpitBreach")]
        public bool CockpitBreach { get; internal set; }

        [JsonProperty("Wanted")]
        public bool Wanted { get; internal set; }

        [JsonProperty("ActiveFine")]
        public bool ActiveFine { get; internal set; }

        internal static DockedEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockedEvent>(json));
    }
}