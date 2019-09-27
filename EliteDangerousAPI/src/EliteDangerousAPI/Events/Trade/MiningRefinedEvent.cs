using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MiningRefinedEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        internal static MiningRefinedEvent Execute(string json, API.EliteDangerousAPI api) => api.TradeEvents.InvokeEvent(api.FromJson<MiningRefinedEvent>(json));
    }
}