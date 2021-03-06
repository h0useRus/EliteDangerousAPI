using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CrewBaseEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("CrewID")]
        public long CrewId { get; internal set; }
    }
}