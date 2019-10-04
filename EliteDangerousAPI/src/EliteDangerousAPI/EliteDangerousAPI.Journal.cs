using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Logging;
using NSW.EliteDangerous.API.Events;
using NSW.EliteDangerous.API.Exceptions;

namespace NSW.EliteDangerous.API
{
    partial class EliteDangerousAPI
    {
        private readonly object @lock = new object();

        private long _filePosition;
        private FileInfo _currentJournalFile;
        private FileSystemWatcher _journalDirectoryWatcher;
        private Timer _journalFileMonitor;
        private StatusEvent _currentGameStatus;
        
        private void StartJournalProcessing()
        {
            JournalDirectory.Create();
            _journalDirectoryWatcher = new FileSystemWatcher(JournalDirectory.FullName);
            _journalDirectoryWatcher.Created += ProcessJournal;
            _journalDirectoryWatcher.Changed += ProcessJournal;
            _journalDirectoryWatcher.NotifyFilter = NotifyFilters.CreationTime |
                                                    NotifyFilters.FileName |
                                                    NotifyFilters.LastWrite |
                                                    NotifyFilters.Size;

            _journalFileMonitor = new Timer
            {
                AutoReset = true,
                Interval = _settings.CheckInterval.TotalMilliseconds
            };

            _journalFileMonitor.Elapsed += MonitorJournal;
            _journalFileMonitor.Enabled = true;

            _currentJournalFile = GetLatestJournalFile();
            _filePosition = _currentJournalFile?.Length ?? 0;
            SendEventsFromJournal(false);
            SendEventFromStatus(Path.Combine(JournalDirectory.FullName, "Status.json"));

            _journalDirectoryWatcher.EnableRaisingEvents = true;
            _log.LogInformation($"Listening {JournalDirectory.FullName}");
        }

        private void StopJournalProcessing()
        {
            _currentGameStatus = null;
            _journalDirectoryWatcher.EnableRaisingEvents = false;
            _journalDirectoryWatcher.Created -= ProcessJournal;
            _journalDirectoryWatcher.Changed -= ProcessJournal;
            _journalDirectoryWatcher.Dispose();

            _journalFileMonitor.Dispose();
        }

        private void SendEventsFromJournal(bool checkForNew)
        {
            lock (@lock)
                try
                {

                    if (_currentJournalFile != null)
                    {
                        _filePosition = ReadJournalFromPosition(_currentJournalFile, _filePosition);
                        Status = ApiStatus.Running;
                    }

                    if (checkForNew || _currentJournalFile == null)
                    {
                        var latestFile = GetLatestJournalFile();
                        if (latestFile?.FullName == _currentJournalFile?.FullName || latestFile == null)
                        {
                            Status = Status == ApiStatus.Running ? ApiStatus.Running : ApiStatus.Pending;
                            return;
                        }

                        Status = ApiStatus.Running;
                        _currentJournalFile = latestFile;
                        JournalFound?.Invoke(this, _currentJournalFile.Name);
                        _log.LogInformation($"New Journal file {_currentJournalFile.FullName}");
                        _filePosition = ReadJournalFromPosition(_currentJournalFile, 0);
                    }
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    LogJournalException(new JournalFileNotFoundException(_currentJournalFile?.FullName, fileNotFoundException));
                }
                catch (Exception exception)
                {
                    LogJournalException(new JournalFileException(_currentJournalFile?.FullName, exception));
                }
        }

        private long ReadJournalFromPosition(FileInfo journalFile, long position)
        {
            using var stream = OpenReadFileStream(journalFile.FullName);
            using var reader = new StreamReader(stream);
            try
            {
                _log.LogInformation($"Reading from {journalFile.FullName}");

                stream.Position = position;

                while (reader.Peek() >= 0)
                {
                    var json = reader.ReadLine();
                    var journalEvent = FromJson<JournalEvent>(json);
                    if (journalEvent != null)
                        ExecuteEvent(journalEvent.Event, json);
                }
            }
            catch (Exception exception)
            {
                LogJournalException(new JournalFileException(journalFile.FullName, exception));
            }
            return stream.Position;
        }

        private void MonitorJournal(object sender, ElapsedEventArgs e)
        {
            Task.Run(() => SendEventsFromJournal(false));
            if (GameRunning)
                _journalFileMonitor.Interval = _settings.CheckInterval.TotalMilliseconds;
            else
                _journalFileMonitor.Interval = _settings.CheckInterval.TotalMilliseconds * 6;
        }

        private void ProcessJournal(object sender, FileSystemEventArgs e)
        {
            if (Path.GetExtension(e.FullPath) == ".log")
                SendEventsFromJournal(new FileInfo(e.FullPath) != _currentJournalFile);

            if(string.Equals(Path.GetFileName(e.FullPath), "Status.json"))
                SendEventFromStatus(e.FullPath);
        }

        private void SendEventFromStatus(string statusFilePath)
        {
            lock (@lock)
            {
                var @event = FromJsonFile<StatusEvent>(statusFilePath);
                if (@event != null)
                {
                    if (!@event.Equals(_currentGameStatus))
                    {
                        _currentGameStatus = @event;
                        GameEvents.InvokeEvent(@event);
                        AllEvents?.Invoke(this, new ProcessedEvent
                        {
                            EventName = @event.Event.ToLower(),
                            EventType = typeof(StatusEvent),
                            Event = @event
                        });
                    }
                }
            }
        }

        private FileInfo GetLatestJournalFile() => JournalDirectory.GetFiles("Journal.*.log", SearchOption.TopDirectoryOnly)
                                                                   .OrderByDescending(f => f.Name)
                                                                   .FirstOrDefault();

        internal bool ValidateEvent<TEvent>(TEvent @event) where TEvent : JournalEvent
        {
            if (@event != null)
                return true;

            LogJournalException(new JournalException(JournalErrorType.NullEvent, nameof(TEvent)));
            return false;
        }

        internal void LogJournalException(JournalException exception)
        {
            _log.LogError(exception, exception.Type.ToString());
            Errors?.Invoke(this, exception);
        }

        internal void LogJournalWarning(JournalException exception)
        {
            _log.LogWarning(exception, exception.Type.ToString());
            Warnings?.Invoke(this, exception);
        }

        public event EventHandler<string> JournalFound;
        public event EventHandler<JournalException> Errors;
        public event EventHandler<JournalException> Warnings;
    }
}