using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class NpcCrewStatistics
    {
        [JsonProperty("NpcCrew_TotalWages")]
        public long TotalWages { get; set; }

        [JsonProperty("NpcCrew_Hired")]
        public long Hired { get; set; }

        [JsonProperty("NpcCrew_Fired")]
        public long Fired { get; set; }

        [JsonProperty("NpcCrew_Died")]
        public long Died { get; set; }
    }
}