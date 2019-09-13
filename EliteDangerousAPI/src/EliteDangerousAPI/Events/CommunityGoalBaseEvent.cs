using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalBaseEvent : JournalEvent
    {
        [JsonProperty("CGID")]
        public long GoalId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }
    }
}