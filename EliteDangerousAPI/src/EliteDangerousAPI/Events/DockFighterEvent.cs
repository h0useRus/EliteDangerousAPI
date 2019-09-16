using Newtonsoft.Json;
using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class DockFighterEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public int Id { get; internal set; }

        internal static DockFighterEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<DockFighterEvent>(json));
    }
}