using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class EngineerContributionEvent : JournalEvent
    {
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; internal set; }

        [JsonProperty("Type")]
        public ContributionType Type { get; internal set; }

        [JsonProperty("Commodity")]
        public string Commodity { get; internal set; }

        [JsonProperty("Commodity_Localised")]
        public string CommodityLocalised { get; internal set; }

        [JsonProperty("Material")]
        public string Material { get; internal set; }

        [JsonProperty("Material_Localised")]
        public string MaterialLocalised { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; internal set; }

        [JsonProperty("TotalQuantity")]
        public long TotalQuantity { get; internal set; }

        internal static EngineerContributionEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<EngineerContributionEvent>(json));
    }
}