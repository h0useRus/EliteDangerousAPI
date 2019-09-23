using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ApproachSettlementEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        internal static ApproachSettlementEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<ApproachSettlementEvent>(json));
    }
}