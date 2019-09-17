using System;

namespace NSW.EliteDangerous.Exceptions
{
    public class JournalRecordException : JournalException
    {
        public string JournalRecord { get; }

        public JournalRecordException(string journalRecord) : this(string.Empty, journalRecord, null) { }

        public JournalRecordException(string message, string journalRecord) : this(message, journalRecord, null) { }

        public JournalRecordException(string journalRecord, Exception innerException) : this(string.Empty, journalRecord, innerException) { }

        public JournalRecordException(string message, string journalRecord, Exception innerException) : base(JournalErrorType.OnReadingRecord, message, innerException)
        {
            JournalRecord = journalRecord;
        }
    }
}