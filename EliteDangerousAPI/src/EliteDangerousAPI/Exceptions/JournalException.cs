using System;

namespace NSW.EliteDangerous.Exceptions
{
    public class JournalException : Exception
    {
        public JournalErrorType Type { get; }

        public JournalException(JournalErrorType type, string message) : this(type, message, null) { }

        public JournalException(JournalErrorType type, string message,  Exception innerException) : base(message, innerException)
        {
            Type = type;
        }
    }
}