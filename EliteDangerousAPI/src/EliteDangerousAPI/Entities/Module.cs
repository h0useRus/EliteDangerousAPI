using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Module : ModuleInfo
    {
        [JsonProperty("On")]
        public bool On { get; internal set; }

        [JsonProperty("Health")]
        public double Health { get; internal set; }

        [JsonProperty("Value")]
        public long? Value { get; internal set; }

        [JsonProperty("Engineering")]
        public ModuleEngineering Engineering { get; internal set; }

        [JsonProperty("AmmoInClip")]
        public long? AmmoInClip { get; internal set; }

        [JsonProperty("AmmoInHopper")]
        public long? AmmoInHopper { get; internal set; }
    }
}