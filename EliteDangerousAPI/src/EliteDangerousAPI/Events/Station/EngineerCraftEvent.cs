using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class EngineerCraftEvent : JournalEvent
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("ApplyExperimentalEffect")]
        public string ApplyExperimentalEffect { get; internal set; }

        [JsonProperty("Ingredients")]
        public Ingredient[] Ingredients { get; internal set; }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("EngineerID")]
        public int EngineerId { get; internal set; }

        [JsonProperty("BlueprintID")]
        public long BlueprintId { get; internal set; }

        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Quality")]
        public double Quality { get; internal set; }

        [JsonProperty("ExperimentalEffect")]
        public string ExperimentalEffect { get; internal set; }

        [JsonProperty("ExperimentalEffect_Localised")]
        public string ExperimentalEffectLocalised { get; internal set; }

        [JsonProperty("Modifiers")]
        public Modifier[] Modifiers { get; internal set; }

        internal static EngineerCraftEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<EngineerCraftEvent>(json));
    }
}