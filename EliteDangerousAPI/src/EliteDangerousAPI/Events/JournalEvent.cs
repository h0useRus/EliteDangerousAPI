using System;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class JournalEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        public override string ToString() => Event;
    }
}