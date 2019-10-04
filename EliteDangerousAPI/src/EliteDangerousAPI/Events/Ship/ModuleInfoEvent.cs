using System.IO;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ModuleInfoEvent : JournalEvent
    {
        [JsonProperty("Modules")]
        public ModuleInfo[] Modules { get; internal set; }

        internal static ModuleInfoEvent Execute(string json, EliteDangerousAPI api)
        {
            var jsonEvent = api.FromJson<ModuleInfoEvent>(json);
            var fileEvent = api.FromJsonFile<ModuleInfoEvent>(Path.Combine(api.JournalDirectory.FullName, "ModulesInfo.json"));
            
            return api.ShipEvents.InvokeEvent(fileEvent ?? jsonEvent);
        }
            
    }
}