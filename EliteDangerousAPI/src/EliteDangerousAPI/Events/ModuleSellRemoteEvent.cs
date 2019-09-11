using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ModuleSellRemoteEvent : ModuleSellEvent
    {
        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; internal set; }

        internal new static ModuleSellRemoteEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<ModuleSellRemoteEvent>(json));
    }
}