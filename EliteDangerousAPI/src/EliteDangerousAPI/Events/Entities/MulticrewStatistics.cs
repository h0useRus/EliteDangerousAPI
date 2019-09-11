using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class MultiCrewStatistics
    {
        [JsonProperty("Multicrew_Time_Total")]
        public long TimeTotal { get; set; }

        [JsonProperty("Multicrew_Gunner_Time_Total")]
        public long GunnerTimeTotal { get; set; }

        [JsonProperty("Multicrew_Fighter_Time_Total")]
        public long FighterTimeTotal { get; set; }

        [JsonProperty("Multicrew_Credits_Total")]
        public long CreditsTotal { get; set; }

        [JsonProperty("Multicrew_Fines_Total")]
        public long FinesTotal { get; set; }
    }
}