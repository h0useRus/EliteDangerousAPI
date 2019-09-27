using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ProspectedAsteroidEvent : JournalEvent
    {
        [JsonProperty("Materials")]
        public ProspectedMaterial[] Materials { get; internal set; }

        [JsonProperty("MotherlodeMaterial")]
        public string MotherlodeMaterial { get; internal set; }

        [JsonProperty("MotherlodeMaterial_Localised")]
        public string MotherlodeMaterialLocalised { get; internal set; }

        [JsonProperty("Content")]
        public string Content { get; internal set; }

        [JsonProperty("Content_Localised")]
        public string ContentLocalised { get; internal set; }

        [JsonProperty("Remaining")]
        public long Remaining { get; internal set; }

        internal static ProspectedAsteroidEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<ProspectedAsteroidEvent>(json));
    }
}