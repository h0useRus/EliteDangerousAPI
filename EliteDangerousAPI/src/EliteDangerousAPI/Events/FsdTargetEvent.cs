using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FsdTargetEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        internal static FsdTargetEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<FsdTargetEvent>(json));
    }
}