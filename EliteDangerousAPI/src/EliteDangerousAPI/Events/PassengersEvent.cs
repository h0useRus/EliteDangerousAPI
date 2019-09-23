using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class PassengersEvent : JournalEvent
    {
        [JsonProperty("Manifest")]
        public PassengerManifest[] Manifest { get; internal set; }

        internal static PassengersEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<PassengersEvent>(json));
    }
}