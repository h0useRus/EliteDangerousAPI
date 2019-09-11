using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PassengersEvent : JournalEvent
    {
        [JsonProperty("Manifest")]
        public PassengerManifest[] Manifest { get; internal set; }

        internal static PassengersEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<PassengersEvent>(json));
    }
}