using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class GameHandler
    {
        private readonly API.EliteDangerousAPI _api;
        internal GameHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// When loading from main menu into game
        /// </summary>
        public event EventHandler<StatusEvent> Status;
        internal StatusEvent InvokeEvent(StatusEvent arg) { Status?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When loading from main menu into game
        /// </summary>
        public event EventHandler<LoadGameEvent> LoadGame;
        internal LoadGameEvent InvokeEvent(LoadGameEvent arg) { LoadGame?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When new log file started
        /// </summary>
        public event EventHandler<FileHeaderEvent> FileHeader;
        internal FileHeaderEvent InvokeEvent(FileHeaderEvent arg) { FileHeader?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// If the journal file grows to 500k lines, we write this event, close the file, and start a new one
        /// </summary>
        public event EventHandler<ContinuedEvent> Continued;
        internal ContinuedEvent InvokeEvent(ContinuedEvent arg) { Continued?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// If you should ever reset your game
        /// </summary>
        public event EventHandler<ClearSavedGameEvent> ClearSavedGame;
        internal ClearSavedGameEvent InvokeEvent(ClearSavedGameEvent arg) { ClearSavedGame?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When game music changed
        /// </summary>
        public event EventHandler<MusicEvent> Music;
        internal MusicEvent InvokeEvent(MusicEvent arg) { Music?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When game shutdown
        /// </summary>
        public event EventHandler<ShutdownEvent> Shutdown;
        internal ShutdownEvent InvokeEvent(ShutdownEvent arg) { Shutdown?.Invoke(_api, arg); return arg; }
    }
}