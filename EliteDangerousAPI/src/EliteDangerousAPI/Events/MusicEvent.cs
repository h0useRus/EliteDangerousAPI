using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MusicEvent : JournalEvent
    {
        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }
    }
}