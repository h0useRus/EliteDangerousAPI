using System;

namespace NSW.EliteDangerous.API.Events
{
    public class ProcessedEvent
    {
        public string EventName { get; internal set; }
        public Type EventType { get; internal set; }
        public JournalEvent Event { get; internal set; }
    }
}