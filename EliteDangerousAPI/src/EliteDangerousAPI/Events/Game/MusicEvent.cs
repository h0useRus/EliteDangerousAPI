using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MusicEvent : JournalEvent
    {
        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }

        internal static MusicEvent Execute(string json, API.EliteDangerousAPI api) => api.GameEvents.InvokeEvent(api.FromJson<MusicEvent>(json));
    }
}