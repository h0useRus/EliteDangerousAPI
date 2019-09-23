using System;

namespace NSW.EliteDangerous.API.Exceptions
{
    public class JournalFileNotFoundException : JournalException
    {
        public string FileName { get; }

        public JournalFileNotFoundException(string fileName) : this(string.Empty, fileName, null) { }

        public JournalFileNotFoundException(string message, string fileName) : this(message, fileName, null) { }

        public JournalFileNotFoundException(string fileName, Exception innerException) : this(string.Empty, fileName, innerException) { }

        public JournalFileNotFoundException(string message, string fileName, Exception innerException) : base(JournalErrorType.JournalNotFound, message, innerException)
        {
            FileName = fileName;
        }
    }
}