using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PassengersEvent : JournalEvent
    {
        [JsonProperty("Manifest")]
        public PassengerManifest[] Manifest { get; internal set; }

        internal static PassengersEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<PassengersEvent>(json));
    }
}