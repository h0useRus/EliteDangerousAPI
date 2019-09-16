using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class LaunchSrvEvent : JournalEvent
    {
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("ID")]
        public int Id { get; internal set; }

        internal static LaunchSrvEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<LaunchSrvEvent>(json));
    }
}