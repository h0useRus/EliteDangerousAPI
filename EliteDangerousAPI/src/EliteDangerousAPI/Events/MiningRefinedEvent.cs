using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MiningRefinedEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        internal static MiningRefinedEvent Execute(string json, EliteDangerousAPI api) => api.Trade.InvokeEvent(JsonHelper.FromJson<MiningRefinedEvent>(json));
    }
}