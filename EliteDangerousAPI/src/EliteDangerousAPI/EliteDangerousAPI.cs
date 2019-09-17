using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;


namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI : IDisposable
    {
        #region DefaultJournalDirectory

        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        private static string DefaultJournalDirectory
        {
            get
            {
                if (SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0, new IntPtr(0), out var path) >= 0)
                {
                    try { return Path.Combine(Marshal.PtrToStringUni(path), @"Frontier Developments\Elite Dangerous"); }
                    catch { }
                }

                return Environment.CurrentDirectory;
            }
        }
        #endregion
        
        private readonly ILogger _log;
        private ApiStatus _status;
        public ApiStatus Status
        {
            get => _status;
            private set
            {
                if(_status != value)
                {
                    _status = value;
                    StatusChanged?.Invoke(this, _status);
                }
            }
        }

        public bool GameRunning => Process.GetProcessesByName("EliteDangerous64").Length > 0;

        public DirectoryInfo JournalDirectory { get; }

        public int DocumentationVersion { get ;} = 25;

        public string Version => Assembly.GetAssembly(typeof(EliteDangerousAPI)).GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

        public EliteDangerousAPI() : this(DefaultJournalDirectory) { }

        public EliteDangerousAPI(ILoggerFactory loggerFactory) : this(DefaultJournalDirectory, loggerFactory) { }

        public EliteDangerousAPI(string journalDirectory) : this(journalDirectory, new NullLoggerFactory()) { }

        public EliteDangerousAPI(string journalDirectory, ILoggerFactory loggerFactory)
        {
            _log = loggerFactory.CreateLogger<EliteDangerousAPI>();
            JournalDirectory = new DirectoryInfo(journalDirectory);
            InitHandlers();
        }
        public void Start()
        {
            if (Status != ApiStatus.Stopped)
                return;

            StartJournalProcessing();

            _log.LogInformation($"Elite Dangerous API v. {Version} {Status}");
        }

        public void Stop()
        {
            if (Status == ApiStatus.Stopped)
                return;

            StopJournalProcessing();

            Status = ApiStatus.Stopped;

            _log.LogInformation($"API {Status}");
        }

        public event EventHandler<ApiStatus> StatusChanged;

        #region IDisposable

        private bool _disposed;
        /// <inheritdoc />
        public void Dispose()
        {
            if (!_disposed)
            {
                Stop();
            }

            _disposed = true;
        }

        #endregion
    }
}