using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class FactionDetails : Faction
    {
        [JsonProperty("Government")]
        public string Government { get; internal set; }

        [JsonProperty("Influence")]
        public double Influence { get; internal set; }

        [JsonProperty("Allegiance")]
        public string Allegiance { get; internal set; }

        [JsonProperty("ActiveStates")]
        public FactionStateTrend[] ActiveStates { get; internal set; }

        [JsonProperty("PendingStates")]
        public FactionStateTrend[] PendingStates { get; internal set; }

        [JsonProperty("RecoveringStates")]
        public FactionStateTrend[] RecoveringStates { get; internal set; }

        [JsonProperty("Happiness")]
        public string Happiness { get; internal set; }

        [JsonProperty("Happiness_Localised")]
        public string HappinessLocalised { get; internal set; }

        [JsonProperty("MyReputation")]
        public double MyReputation { get; internal set; }

        [JsonProperty("SquadronFaction")]
        public bool SquadronFaction { get; internal set; }

        [JsonProperty("HappiestSystem")]
        public bool HappiestSystem { get; internal set; }

        [JsonProperty("HomeSystem")]
        public bool HomeSystem { get; internal set; }
    }
}