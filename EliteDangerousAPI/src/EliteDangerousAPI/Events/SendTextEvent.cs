using System;
using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class SendTextEvent : JournalEvent
    {
        [JsonProperty("To")]
        public string To { get; internal set; }

        [JsonProperty("To_Localised")]
        public string ToLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonIgnore]
        public MessageChannel Channel => Enum.TryParse(To, true, out MessageChannel channel) ? channel : MessageChannel.Player;

        internal static SendTextEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(api.FromJson<SendTextEvent>(json));
    }
}