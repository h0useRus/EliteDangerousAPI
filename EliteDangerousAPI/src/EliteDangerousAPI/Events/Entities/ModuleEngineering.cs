using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class ModuleEngineering
    {
        [JsonProperty("Engineer")]
        public string Engineer { get; set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; set; }

        [JsonProperty("BlueprintID")]
        public long BlueprintId { get; set; }

        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; set; }

        [JsonProperty("Level")]
        public short Level { get; set; }

        [JsonProperty("Quality")]
        public double Quality { get; set; }

        [JsonProperty("ExperimentalEffect")]
        public string ExperimentalEffect { get; set; }

        [JsonProperty("ExperimentalEffect_Localised")]
        public string ExperimentalEffectLocalised { get; set; }

        [JsonProperty("Modifications")]
        public Modifier[] Modifications { get; set; }
    }
}