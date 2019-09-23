using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ModuleSwapEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("FromSlot")]
        public string FromSlot { get; internal set; }

        [JsonProperty("ToSlot")]
        public string ToSlot { get; internal set; }

        [JsonProperty("FromItem")]
        public string FromItem { get; internal set; }

        [JsonProperty("FromItem_Localised")]
        public string FromItemLocalised { get; internal set; }

        [JsonProperty("ToItem")]
        public string ToItem { get; internal set; }

        [JsonProperty("ToItem_Localised")]
        public string ToItemLocalised { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        internal static ModuleSwapEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<ModuleSwapEvent>(json));
    }
}