using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MissionBaseEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }
    }
}