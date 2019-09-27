using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
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

        internal static ReceiveTextEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<ReceiveTextEvent>(json));
    }
}