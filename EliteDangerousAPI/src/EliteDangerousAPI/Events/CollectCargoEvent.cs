using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CollectCargoEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Stolen")]
        public bool Stolen { get; internal set; }

        internal static CollectCargoEvent Execute(string json, EliteDangerousAPI api) => api.Trade.InvokeEvent(api.FromJson<CollectCargoEvent>(json));
    }
}