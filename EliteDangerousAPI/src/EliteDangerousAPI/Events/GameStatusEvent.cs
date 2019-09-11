using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NSW.EliteDangerous.Events
{
    public class GameStatusEvent : JournalEvent
    {
        [JsonProperty("Flags")]
        public ShipStatusFlags Flags { get; internal set; }

        [JsonProperty("Pips")]
        public long[] Pips { get; internal set; }

        [JsonProperty("FireGroup")]
        public long FireGroup { get; internal set; }

        [JsonProperty("GuiFocus")]
        public GuiFocus GuiFocus { get; internal set; }

        [JsonProperty("Fuel")]
        public Fuel Fuel { get; internal set; }

        [JsonProperty("LegalState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LegalState LegalState { get; internal set; }

        [JsonProperty("Cargo")]
        public int Cargo { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Altitude")]
        public double Altitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        [JsonProperty("Heading")]
        public double Heading { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("PlanetRadius")]
        public double PlanetRadius { get; internal set; }
    }
}