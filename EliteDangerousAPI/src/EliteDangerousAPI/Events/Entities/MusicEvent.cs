using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class MusicEvent : JournalEvent
    {
        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }
    }
}