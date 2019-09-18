using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Exceptions
{
    public class JournalEventConsistencyException<T> : JournalException where T: JournalEvent
    {
        public T FromJournal { get; }
        public T FromFile { get; }

        public JournalEventConsistencyException(T fromJournal, T fromFile) : this(string.Empty, fromJournal, fromFile, null) { }

        public JournalEventConsistencyException(string message, T fromJournal, T fromFile) : this(message, fromJournal, fromFile, null) { }

        public JournalEventConsistencyException(T fromJournal, T fromFile, Exception innerException) : this(string.Empty, fromJournal, fromFile, innerException) { }

        public JournalEventConsistencyException(string message, T fromJournal, T fromFile, Exception innerException) : base(JournalErrorType.EventConsistency, message, innerException)
        {
            FromJournal = fromJournal;
            FromFile = fromFile;
        }
    }
}