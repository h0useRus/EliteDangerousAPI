using System;

namespace NSW.EliteDangerous.Exceptions
{
    public class JournalEventNotFoundException : JournalException
    {
        public string EventName { get; }

        public string JournalRecord { get; }

        public JournalEventNotFoundException(string eventName, string journalRecord) : this(string.Empty, eventName, journalRecord, null) { }

        public JournalEventNotFoundException(string message, string eventName, string journalRecord) : this(message, eventName, journalRecord, null) { }

        public JournalEventNotFoundException(string eventName, string journalRecord, Exception innerException) : this(string.Empty, eventName, journalRecord, innerException) { }

        public JournalEventNotFoundException(string message, string eventName, string journalRecord, Exception innerException) : base(JournalErrorType.EventNotFound, message, innerException)
        {
            EventName = eventName;
            JournalRecord = journalRecord;
        }
    }
}