using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ModuleInfoEvent : JournalEvent
    {
        [JsonProperty("Modules")]
        public ModuleInfo[] Modules { get; internal set; }

        internal static ModuleInfoEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<ModuleInfoEvent>(json));
    }
}