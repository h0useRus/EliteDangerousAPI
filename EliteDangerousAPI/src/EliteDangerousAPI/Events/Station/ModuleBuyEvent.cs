using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ModuleBuyEvent : JournalEvent
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; internal set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; internal set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }

        [JsonProperty("BuyItem")]
        public string BuyItem { get; internal set; }

        [JsonProperty("BuyItem_Localised")]
        public string BuyItemLocalised { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        internal static ModuleBuyEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<ModuleBuyEvent>(json));
    }
}