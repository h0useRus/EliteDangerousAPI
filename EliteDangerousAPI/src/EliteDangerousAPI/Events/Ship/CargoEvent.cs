using System.IO;
using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals.Converters;

namespace NSW.EliteDangerous.API.Events
{
    public class CargoEvent : JournalEvent
    {
        [JsonProperty("Vessel")]
        [JsonConverter(typeof(VehicleEnumConverter))]
        public VehicleType Vessel { get; internal set; }

        [JsonProperty("Count")]
        public long? Count { get; internal set; }

        [JsonProperty("Inventory")]
        public Inventory[] Inventory { get; internal set; }

        internal static CargoEvent Execute(string json, API.EliteDangerousAPI api)
        {
            var jsonEvent = api.FromJson<CargoEvent>(json);
            var fileEvent = api.FromJsonFile<CargoEvent>(Path.Combine(api.JournalDirectory.FullName, "Cargo.json"));
            
            return api.ShipEvents.InvokeEvent(fileEvent ?? jsonEvent);
        }
    }
}