using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
{
    public class ModuleRetrieveEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("RetrievedItem")]
        public string RetrievedItem { get; internal set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; internal set; }

        [JsonProperty("Ship")]
        public string ShipType { get; internal set; }

        [JsonIgnore] public ShipModel ShipModel => EnumHelper.GetShipModel(ShipType);

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Quality")]
        public double Quality { get; internal set; }

        [JsonProperty("SwapOutItem")]
        public string SwapOutItem { get; internal set; }

        [JsonProperty("SwapOutItem_Localised")]
        public string SwapOutItemLocalised { get; internal set; }

        internal static ModuleRetrieveEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<ModuleRetrieveEvent>(json));
    }
}