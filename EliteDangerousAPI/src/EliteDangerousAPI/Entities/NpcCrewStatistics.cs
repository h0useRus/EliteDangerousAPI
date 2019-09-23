using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class NpcCrewStatistics
    {
        [JsonProperty("NpcCrew_TotalWages")]
        public long TotalWages { get; internal set; }

        [JsonProperty("NpcCrew_Hired")]
        public long Hired { get; internal set; }

        [JsonProperty("NpcCrew_Fired")]
        public long Fired { get; internal set; }

        [JsonProperty("NpcCrew_Died")]
        public long Died { get; internal set; }
    }
}