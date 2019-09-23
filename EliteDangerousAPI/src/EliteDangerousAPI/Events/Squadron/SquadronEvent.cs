using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SquadronEvent : JournalEvent
    {
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
}