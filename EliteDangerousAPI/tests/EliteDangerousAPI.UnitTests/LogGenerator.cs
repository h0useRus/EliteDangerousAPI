using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous
{
    public class LogGenerator : IDisposable
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        private readonly StreamWriter _writer;
        public LogGenerator(string rootFolder)
        {
            _writer = File.CreateText(Path.Combine(rootFolder, $"Journal.{DateTime.UtcNow.Ticks}.01.log"));
            _writer.AutoFlush = true;
            WriteHeader();
        }

        public FileHeaderEvent WriteHeader() =>
            WriteEvent(new FileHeaderEvent
            {
                Timestamp = DateTime.UtcNow,
                Event = "Fileheader",
                Part = 1,
                Language = "Russian\\RU",
                GameVersion = "April Update Patch 2 EDH",
                Build = "r200296/r0 "
            });

        public TEvent WriteEvent<TEvent>(TEvent @event) where TEvent : JournalEvent
        {
            @event.Timestamp = DateTime.UtcNow;

            _writer.WriteLine(JsonConvert.SerializeObject(@event, _settings));
            _writer.Flush();
            return @event;
        }

        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            WriteEvent(new ShutdownEvent {Event = "Shutdown"});
            _writer.Close();
            _writer?.Dispose();
        }

        #endregion
    }
}