using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class WingAddEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static WingAddEvent Execute(string json, EliteDangerousAPI api) => api.Wing.InvokeEvent(api.FromJson<WingAddEvent>(json));
    }
}