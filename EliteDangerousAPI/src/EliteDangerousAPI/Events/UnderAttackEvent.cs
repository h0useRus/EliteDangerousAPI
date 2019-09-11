using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class UnderAttackEvent : JournalEvent
    {
        [JsonProperty("Target")]
        public string Target { get; internal set; }

        internal static UnderAttackEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<UnderAttackEvent>(json));
    }
}