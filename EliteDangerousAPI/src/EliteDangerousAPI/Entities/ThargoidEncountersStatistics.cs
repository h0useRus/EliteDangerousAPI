using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class ThargoidEncountersStatistics
    {
        [JsonProperty("TG_ENCOUNTER_IMPRINT")]
        public long? TgEncounterImprint { get; internal set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL")]
        public long TgEncounterTotal { get; internal set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SYSTEM")]
        public string TgEncounterTotalLastSystem { get; internal set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP")]
        public string TgEncounterTotalLastTimestamp { get; internal set; }

        [JsonProperty("TG_ENCOUNTER_TOTAL_LAST_SHIP")]
        public string TgEncounterTotalLastShip { get; internal set; }

        [JsonProperty("TG_SCOUT_COUNT")]
        public long TgScoutCount { get; internal set; }
    }
}