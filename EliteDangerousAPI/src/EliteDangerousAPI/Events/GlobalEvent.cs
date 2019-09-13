using System;

namespace NSW.EliteDangerous.Events
{
    public class GlobalEvent
    {
        public string EventName { get; internal set; }
        public Type EventType { get; internal set; }
        public JournalEvent Event { get; internal set; }
    }
}