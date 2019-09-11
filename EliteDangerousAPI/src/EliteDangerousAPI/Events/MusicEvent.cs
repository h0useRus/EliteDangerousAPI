using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MusicEvent : JournalEvent
    {
        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }

        internal static MusicEvent Execute(string json, EliteDangerousAPI api) => api.Game.InvokeEvent(JsonHelper.FromJson<MusicEvent>(json));
    }
}