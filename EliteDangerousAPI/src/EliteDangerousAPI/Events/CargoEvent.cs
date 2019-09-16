using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CargoEvent : JournalEvent
    {
        [JsonProperty("Vessel")]
        public string Vessel { get; internal set; }

        [JsonProperty("Count")]
        public long? Count { get; internal set; }

        [JsonProperty("Inventory")]
        public Inventory[] Inventory { get; internal set; }

        internal static CargoEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<CargoEvent>(json));
    }
}