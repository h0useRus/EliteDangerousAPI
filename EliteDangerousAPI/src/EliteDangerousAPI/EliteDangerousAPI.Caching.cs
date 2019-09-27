using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NSW.EliteDangerous.API.Events;
using NSW.EliteDangerous.API.Exceptions;

[assembly: InternalsVisibleTo("EliteDangerousAPI.UnitTests")]

namespace NSW.EliteDangerous.API
{
    partial class EliteDangerousAPI
    {
        private static readonly Lazy<Dictionary<string, EventCacheItem>> _cache = new Lazy<Dictionary<string, EventCacheItem>>(BuildCache);

        private class EventCacheItem
        {
            public string Name => Type.Name.Replace("Event", string.Empty).ToLower();
            public Type Type { get; set; }
            public MethodInfo Execute { get; set; }
        }

        private static Dictionary<string, EventCacheItem> BuildCache()
        {
            var cache = new Dictionary<string, EventCacheItem>(StringComparer.OrdinalIgnoreCase);
            var events = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(JournalEvent)) && x.Name.EndsWith("Event"));
            foreach (var eventClass in events)
            {
                var executeMethod = eventClass.GetMethod("Execute",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                if (executeMethod != null)
                {
                    var item = new EventCacheItem
                    {
                        Type = eventClass,
                        Execute = executeMethod
                    };
                    cache.Add(item.Name, item);
                }
            }

            return cache;
        }

        internal bool HasEvent(string eventName) => _cache.Value.TryGetValue(eventName, out _);

        internal JournalEvent ExecuteEvent(string eventName, string json)
        {
            var rawEvent = new OriginalEvent {EventName = eventName, Source = json};
            BeforeEvent?.Invoke(this, rawEvent);
            if (rawEvent.Ignore) return null;

            if (_cache.Value.TryGetValue(eventName, out var eventCacheItem))
            {
                JournalEvent @event = null;
                try
                {
                    @event = (JournalEvent)eventCacheItem.Execute.Invoke(null, new object[] {json, this});
                }
                catch (Exception exception)
                {
                    LogJournalException(new JournalRecordException(json, exception));
                }

                if(@event!=null)
                    AllEvents?.Invoke(this, new ProcessedEvent
                    {
                        EventName = eventCacheItem.Name,
                        EventType = eventCacheItem.Type,
                        Event = @event
                    });
                return @event;
            }
            LogJournalWarning(new JournalEventNotFoundException(eventName, json));

            return null;
        }

        public event EventHandler<ProcessedEvent> AllEvents;
        public event EventHandler<OriginalEvent> BeforeEvent;
    }
}