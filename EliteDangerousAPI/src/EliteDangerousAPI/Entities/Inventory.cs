using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Inventory : Material
    {   
        [JsonProperty("MissionID")]
        public int? MissionId { get; internal set; }

        [JsonProperty("Stolen")]
        public int Stolen { get; internal set; }
    }
}