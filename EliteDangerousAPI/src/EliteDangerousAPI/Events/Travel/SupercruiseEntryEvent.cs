using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SupercruiseEntryEvent : JournalEvent
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long? SystemAddress { get; internal set; }

        internal static SupercruiseEntryEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<SupercruiseEntryEvent>(json));
    }
}