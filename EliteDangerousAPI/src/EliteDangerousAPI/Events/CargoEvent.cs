using System.IO;
using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CargoEvent : JournalEvent
    {
        [JsonProperty("Vessel")]
        public VehicleType Vessel { get; internal set; }

        [JsonProperty("Count")]
        public long? Count { get; internal set; }

        [JsonProperty("Inventory")]
        public Inventory[] Inventory { get; internal set; }

        internal static CargoEvent Execute(string json, API.EliteDangerousAPI api)
        {
            var jsonEvent = api.FromJson<CargoEvent>(json);
            var fileEvent = api.FromJsonFile<CargoEvent>(Path.Combine(api.JournalDirectory.FullName, "Cargo.json"));
            
            return api.Ship.InvokeEvent(fileEvent ?? jsonEvent);
        }
    }
}