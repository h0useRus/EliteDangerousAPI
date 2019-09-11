using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class FactionInfluenceEffect
    {
        [JsonProperty("Effect")]
        public string EffectEffect { get; set; }

        [JsonProperty("Effect_Localised")]
        public string EffectLocalised { get; set; }

        [JsonProperty("Trend")]
        public string Trend { get; set; }
    }
}