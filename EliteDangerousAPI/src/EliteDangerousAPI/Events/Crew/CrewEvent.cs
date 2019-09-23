using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CrewEvent : JournalEvent
    {
        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }
}