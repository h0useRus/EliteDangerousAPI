using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

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

        internal static SendTextEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<SendTextEvent>(json));
    }
}