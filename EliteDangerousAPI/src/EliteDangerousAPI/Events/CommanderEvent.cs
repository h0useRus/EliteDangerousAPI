using Newtonsoft.Json;
using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class CommanderEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FID")]
        public string FrontierId { get; internal set; }

        internal static CommanderEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<CommanderEvent>(json));
    }
}