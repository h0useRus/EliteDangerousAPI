using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Item
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
    }
}