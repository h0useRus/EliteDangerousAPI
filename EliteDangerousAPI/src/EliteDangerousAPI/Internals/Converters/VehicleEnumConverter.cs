using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NSW.EliteDangerous.API.Internals.Converters
{
    public class VehicleEnumConverter  : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var val = reader.Value.ToString().ToLower();

                if (string.Equals(val, "Mothership"))
                    val = "Ship";

                if (Enum.TryParse(val, true, out VehicleType v))
                    return v;
                return null;
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}