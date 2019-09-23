using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class MultiCrewStatistics
    {
        [JsonProperty("Multicrew_Time_Total")]
        public long TimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Gunner_Time_Total")]
        public long GunnerTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Fighter_Time_Total")]
        public long FighterTimeTotal { get; internal set; }

        [JsonProperty("Multicrew_Credits_Total")]
        public long CreditsTotal { get; internal set; }

        [JsonProperty("Multicrew_Fines_Total")]
        public long FinesTotal { get; internal set; }
    }
}