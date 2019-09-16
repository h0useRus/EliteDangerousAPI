using Newtonsoft.Json;
using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class DockSrvEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public int Id { get; internal set; }

        internal static DockSrvEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<DockSrvEvent>(json));
    }
}