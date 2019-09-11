using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class LaunchDroneEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }
    }
}