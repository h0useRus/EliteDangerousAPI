using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NSW.EliteDangerous.API.Exceptions;

namespace NSW.EliteDangerous.API
{
    partial class EliteDangerousAPI
    {
        internal static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
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

        internal T FromJson<T>(TextReader textReader, JsonSerializerSettings settings = null)
        {
                var serializer = settings == null ? _serializer.Value : JsonSerializer.Create(settings);
                using (var jsonTextReader = new JsonTextReader(textReader) { SupportMultipleContent = true, CloseInput = false })
                    return serializer.Deserialize<T>(jsonTextReader);
        }

        internal T FromJson<T>(Stream jsonStream, JsonSerializerSettings settings = null)
        {
            using (var streamReader = new StreamReader(jsonStream))
                return FromJson<T>(streamReader, settings);
        }

        internal T FromJson<T>(string jsonString, JsonSerializerSettings settings = null)
        {
            if (string.IsNullOrWhiteSpace(jsonString)) return default;

            try
            {
                _log.LogDebug($"Parsing: {jsonString}");
                using (var streamReader = new StringReader(jsonString))
                    return FromJson<T>(streamReader, settings);
            }
            catch (Exception exception)
            {
                LogJournalException(new JournalRecordException(jsonString, exception));
            }

            return default;
        }

        internal T FromJsonFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (var reader = File.OpenRead(filePath))
                    {
                        return FromJson<T>(reader);
                    }
                }
                catch(Exception exception)
                {
                    LogJournalException(new JournalFileException(filePath, exception));
                }
            }

            return default;
        }
    }
}