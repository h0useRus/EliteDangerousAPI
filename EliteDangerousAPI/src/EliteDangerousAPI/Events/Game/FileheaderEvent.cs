using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
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

        internal static FileHeaderEvent Execute(string json, API.EliteDangerousAPI api) => api.GameEvents.InvokeEvent(api.FromJson<FileHeaderEvent>(json));
    }
}