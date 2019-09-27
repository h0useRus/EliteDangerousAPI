using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class DockSrvEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public int Id { get; internal set; }

        internal static DockSrvEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<DockSrvEvent>(json));
    }
}