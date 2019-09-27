using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CommanderEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FID")]
        public string FrontierId { get; internal set; }

        internal static CommanderEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<CommanderEvent>(json));
    }
}