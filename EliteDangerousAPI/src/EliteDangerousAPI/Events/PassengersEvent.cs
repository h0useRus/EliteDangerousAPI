using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PassengersEvent : JournalEvent
    {
        [JsonProperty("Manifest")]
        public PassengerManifest[] Manifest { get; internal set; }

        internal static PassengersEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<PassengersEvent>(json));
    }
}