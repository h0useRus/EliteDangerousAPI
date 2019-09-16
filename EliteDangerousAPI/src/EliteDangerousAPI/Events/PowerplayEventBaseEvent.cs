using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayEventBaseEvent : JournalEvent
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}