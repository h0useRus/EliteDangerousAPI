using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Modifier
    {
        [JsonProperty("Label")]
        public ModuleAttribute Label { get; internal set; }

        [JsonProperty("Value")]
        public double Value { get; internal set; }

        [JsonProperty("OriginalValue")]
        public double OriginalValue { get; internal set; }

        [JsonProperty("LessIsGood")]
        public bool LessIsGood { get; internal set; }
    }
}