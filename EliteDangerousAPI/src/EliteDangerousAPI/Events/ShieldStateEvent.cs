using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ShieldStateEvent : JournalEvent
    {
        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }

        internal static ShieldStateEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<ShieldStateEvent>(json));
    }
}