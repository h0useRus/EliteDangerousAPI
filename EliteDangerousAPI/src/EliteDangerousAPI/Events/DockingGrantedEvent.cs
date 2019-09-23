using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DockingGrantedEvent : DockEvent
    {
        [JsonProperty("LandingPad")]
        public int LandingPad { get; internal set; }

        internal static DockingGrantedEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockingGrantedEvent>(json));
    }
}