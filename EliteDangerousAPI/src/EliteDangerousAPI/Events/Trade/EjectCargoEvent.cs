using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class EjectCargoEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Abandoned")]
        public bool Abandoned { get; internal set; }

        internal static EjectCargoEvent Execute(string json, API.EliteDangerousAPI api) => api.Trade.InvokeEvent(api.FromJson<EjectCargoEvent>(json));
    }
}