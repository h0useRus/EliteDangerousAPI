using System.IO;
using Newtonsoft.Json;
using NSW.EliteDangerous.API.Exceptions;

namespace NSW.EliteDangerous.API.Events
{
    public class ShipyardEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Horizons")]
        public bool? Horizons { get; set; }

        [JsonProperty("AllowCobraMkIV")]
        public bool? AllowCobraMkIV { get; set; }

        [JsonProperty("PriceList")]
        public ShipyardPrice[] Prices { get; set; }

        internal static ShipyardEvent Execute(string json, API.EliteDangerousAPI api)
        {
            var jsonEvent = api.FromJson<ShipyardEvent>(json);
            var fileEvent = api.FromJsonFile<ShipyardEvent>(Path.Combine(api.JournalDirectory.FullName, "Shipyard.json"));

            if (jsonEvent != null && fileEvent != null && fileEvent.MarketId != jsonEvent.MarketId)
            {
                api.LogJournalWarning(new JournalEventConsistencyException<ShipyardEvent>(jsonEvent, fileEvent));
            }

            return api.Station.InvokeEvent(fileEvent ?? jsonEvent);
        }
    }
}