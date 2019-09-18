using System.IO;
using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;
using NSW.EliteDangerous.Exceptions;

namespace NSW.EliteDangerous.Events
{
    public class MarketEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Items")]
        public MarketItem[] Items { get; set; }

        internal static MarketEvent Execute(string json, EliteDangerousAPI api)
        {
            var jsonEvent = api.FromJson<MarketEvent>(json);
            var fileEvent = api.FromJsonFile<MarketEvent>(Path.Combine(api.JournalDirectory.FullName, "Market.json"));
            if (jsonEvent != null & fileEvent != null && fileEvent.MarketId != jsonEvent.MarketId)
            {
                api.LogJournalWarning(new JournalEventConsistencyException<MarketEvent>(jsonEvent, fileEvent));
            }

            return api.Station.InvokeEvent(fileEvent ?? jsonEvent);
        }
            
    }
}