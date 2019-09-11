using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Modifier
    {
        [JsonProperty("Label")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModuleAttribute Label { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("OriginalValue")]
        public double OriginalValue { get; set; }

        [JsonProperty("LessIsGood")]
        public bool LessIsGood { get; set; }
    }
}