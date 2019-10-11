using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NSW.EliteDangerous.API.Internals.Converters
{
    internal class HappinessConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var val = reader.Value.ToString().Trim().ToLower().Replace(" ", string.Empty).Replace(";",string.Empty).Replace("$faction_", string.Empty);
                return val switch
                {
                    "happinessband1" => Happiness.Elated,
                    "happinessband2" => Happiness.Happy,
                    "happinessband3" => Happiness.Discontented,
                    "happinessband4" => Happiness.Unhappy,
                    "happinessband5" => Happiness.Despondent,
                    _ => Happiness.None
                };
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}