using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PowerplayEventBaseEvent : JournalEvent
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }
    }
}