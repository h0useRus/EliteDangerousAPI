using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class LaunchSrvEvent : JournalEvent
    {
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("ID")]
        public int Id { get; internal set; }

        internal static LaunchSrvEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<LaunchSrvEvent>(json));
    }
}