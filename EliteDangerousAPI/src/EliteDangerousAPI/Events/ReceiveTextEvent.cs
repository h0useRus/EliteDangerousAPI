using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class ReceiveTextEvent : JournalEvent
    {
        [JsonProperty("From")]
        public string From { get; internal set; }

        [JsonProperty("From_Localised")]
        public string FromLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        [JsonProperty("Channel")]
        public MessageChannel Channel { get; internal set; }

        internal static ReceiveTextEvent Execute(string json, API.EliteDangerousAPI api) => api.Player.InvokeEvent(api.FromJson<ReceiveTextEvent>(json));
    }
}