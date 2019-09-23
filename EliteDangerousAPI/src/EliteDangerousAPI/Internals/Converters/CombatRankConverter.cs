using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NSW.EliteDangerous.API.Internals.Converters
{
    internal class CombatRankConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var val = reader.Value.ToString().Replace(" ", string.Empty);
                if (Enum.TryParse(val, true, out CombatRank rank))
                    return rank;
                return null;
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}