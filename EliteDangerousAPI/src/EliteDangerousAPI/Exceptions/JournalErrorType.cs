namespace NSW.EliteDangerous.API.Exceptions
{
    public enum JournalErrorType
    {
        OnReadingFile,
        OnReadingRecord,
        JournalNotFound,
        EventNotFound,
        EventConsistency,
        NullEvent
    }
}