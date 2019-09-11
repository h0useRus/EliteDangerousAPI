using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ModuleInfoEvent : JournalEvent
    {
        [JsonProperty("Modules")]
        public ModuleInfo[] Modules { get; internal set; }

        internal static ModuleInfoEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<ModuleInfoEvent>(json));
    }
}