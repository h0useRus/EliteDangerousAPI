using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

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
        public string Channel { get; internal set; }

        internal static ReceiveTextEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<ReceiveTextEvent>(json));
    }
}