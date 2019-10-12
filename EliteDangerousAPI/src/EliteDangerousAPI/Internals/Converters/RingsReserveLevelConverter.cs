using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NSW.EliteDangerous.API.Internals.Converters
{
    internal class RingsReserveLevelConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => reader.TokenType == JsonToken.String
                ? EnumHelper.GetRingsReserveLevel(reader.Value.ToString())
                : base.ReadJson(reader, objectType, existingValue, serializer);
    }
}