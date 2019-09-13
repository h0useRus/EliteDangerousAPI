using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class FactionInfluenceEffect
    {
        [JsonProperty("Effect")]
        public string Effect { get; internal set; }

        [JsonProperty("Effect_Localised")]
        public string EffectLocalised { get; internal set; }

        [JsonProperty("Trend")]
        public string Trend { get; internal set; }
    }
}