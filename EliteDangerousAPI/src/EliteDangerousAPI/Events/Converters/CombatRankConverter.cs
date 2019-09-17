using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Utilities;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events.Converters
{
    public class CombatRankConverter : StringEnumConverter
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