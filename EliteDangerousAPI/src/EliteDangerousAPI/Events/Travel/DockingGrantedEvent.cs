using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class DockingGrantedEvent : DockEvent
    {
        [JsonProperty("LandingPad")]
        public int LandingPad { get; internal set; }

        internal static DockingGrantedEvent Execute(string json, API.EliteDangerousAPI api) => api.TravelEvents.InvokeEvent(api.FromJson<DockingGrantedEvent>(json));
    }
}