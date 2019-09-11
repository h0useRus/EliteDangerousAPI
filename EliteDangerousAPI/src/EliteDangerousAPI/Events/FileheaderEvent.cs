using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FileHeaderEvent : JournalEvent
    {
        [JsonProperty("part")]
        public long Part { get; internal set; }

        [JsonProperty("language")]
        public string Language { get; internal set; }

        [JsonProperty("gameversion")]
        public string GameVersion { get; internal set; }

        [JsonProperty("build")]
        public string Build { get; internal set; }

        internal static FileHeaderEvent Execute(string json, EliteDangerousAPI api) => api.Game.InvokeEvent(JsonHelper.FromJson<FileHeaderEvent>(json));
    }
}