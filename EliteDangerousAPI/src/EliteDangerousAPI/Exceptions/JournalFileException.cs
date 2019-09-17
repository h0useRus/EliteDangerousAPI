using System;

namespace NSW.EliteDangerous.Exceptions
{
    public class JournalFileException : JournalException
    {
        public string FileName { get; }

        public JournalFileException(string fileName) : this(string.Empty, fileName, null) { }

        public JournalFileException(string message, string fileName) : this(message, fileName, null) { }

        public JournalFileException(string fileName, Exception innerException) : this(string.Empty, fileName, innerException) { }

        public JournalFileException(string message, string fileName, Exception innerException) : base(JournalErrorType.OnReadingFile, message, innerException)
        {
            FileName = fileName;
        }
    }
}