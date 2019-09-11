using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Inventory : Material
    {   
        [JsonProperty("MissionID")]
        public int? MissionId { get; internal set; }

        [JsonProperty("Stolen")]
        public int Stolen { get; internal set; }
    }
}