using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NSW.EliteDangerous.Internals
{
    internal static class JsonHelper
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        private static readonly Lazy<JsonSerializer> _serializer = new Lazy<JsonSerializer>(()=> JsonSerializer.Create(Settings));

        public static T FromJson<T>(TextReader textReader, JsonSerializerSettings settings = null)
        {
            var serializer = settings == null ? _serializer.Value : JsonSerializer.Create(settings);
            using (var jsonTextReader = new JsonTextReader(textReader))
                return serializer.Deserialize<T>(jsonTextReader);
        }

        public static T FromJson<T>(Stream jsonStream, JsonSerializerSettings settings = null)
        {
            using (var streamReader = new StreamReader(jsonStream))
                return FromJson<T>(streamReader, settings);
        }

        public static T FromJson<T>(string jsonString, JsonSerializerSettings settings = null)
        {
            if (string.IsNullOrWhiteSpace(jsonString)) return default(T);
            using (var streamReader = new StringReader(jsonString))
                return FromJson<T>(streamReader, settings);
        }
    }
}