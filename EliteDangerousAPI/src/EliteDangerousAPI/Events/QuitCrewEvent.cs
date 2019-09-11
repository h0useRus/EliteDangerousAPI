using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class QuitCrewEvent : JournalEvent
    {
        [JsonProperty("Captain")]
        public string Captain { get; set; }
    }
}