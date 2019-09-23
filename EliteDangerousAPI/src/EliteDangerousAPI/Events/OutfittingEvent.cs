using System.IO;
using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;
using NSW.EliteDangerous.API.Exceptions;

namespace NSW.EliteDangerous.Events
{
    public class OutfittingEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Horizons")]
        public bool? Horizons { get; set; }

        [JsonProperty("Items")]
        public OutfittingItem[] Items { get; set; }

        internal static OutfittingEvent Execute(string json, API.EliteDangerousAPI api)
        {
            var jsonEvent = api.FromJson<OutfittingEvent>(json);
            var fileEvent = api.FromJsonFile<OutfittingEvent>(Path.Combine(api.JournalDirectory.FullName, "Outfitting.json"));

            if (jsonEvent != null && fileEvent != null && fileEvent.MarketId != jsonEvent.MarketId)
            {
                api.LogJournalWarning(new JournalEventConsistencyException<OutfittingEvent>(jsonEvent, fileEvent));
            }

            return api.Station.InvokeEvent(fileEvent ?? jsonEvent);
        }
            
    }
}