using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CrewEvent : JournalEvent
    {
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }
}