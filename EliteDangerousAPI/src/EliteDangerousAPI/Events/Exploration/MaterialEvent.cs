using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MaterialEvent : JournalEvent
    {
        [JsonProperty("Category")]
        public MaterialCategory Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
    }
}