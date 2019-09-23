using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DockFighterEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public int Id { get; internal set; }

        internal static DockFighterEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<DockFighterEvent>(json));
    }
}