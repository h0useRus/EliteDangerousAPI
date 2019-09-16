using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SupercruiseEntryEvent : JournalEvent
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long? SystemAddress { get; internal set; }

        internal static SupercruiseEntryEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<SupercruiseEntryEvent>(json));
    }
}