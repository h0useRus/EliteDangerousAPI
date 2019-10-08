using System;

namespace NSW.EliteDangerous.API.Statuses
{
    [Flags]
    public enum GameStatusFlags
    {
        None = 0,
        HeaderFound = 1,
        Shutdown = 1 << 1,
    }

    public class GameStatus
    {
        private readonly object _lock = new object();

        public GameStatusFlags Flags { get; private set; }
        public bool Running => EliteDangerousAPI.GameRunning;
        public string Version { get; private set; }
        public string Language { get; private set; }
        public string MusicTrack { get; private set; }
        public GameMode GameMode { get; private set; }
        public bool Horizons { get; private set; }
        public GuiFocus GuiFocus { get; private set; } = GuiFocus.NoFocus;


        internal GameStatus(EliteDangerousAPI api)
        {
            Flags = GameStatusFlags.None;

            api.GameEvents.Status += (s, e) =>
            {
                lock (_lock)
                {
                    if (GuiFocus != e.GuiFocus)
                    {
                        GuiFocus = e.GuiFocus;
                        api.InvokeGameStatusChanged(this);
                    }
                }
            };

            api.GameEvents.FileHeader += (s, e) =>
            {
                lock (_lock)
                {
                    Version = $"{e.GameVersion} ({e.Build})";
                    Language = e.Language;
                    Flags |= GameStatusFlags.HeaderFound;
                    Flags &= ~GameStatusFlags.Shutdown;
                    api.InvokeGameStatusChanged(this);
                }
            };

            api.GameEvents.Shutdown += (s, e) =>
            {
                lock (_lock)
                {
                    Flags |= GameStatusFlags.Shutdown;
                    api.InvokeGameStatusChanged(this);
                }
            };

            api.GameEvents.Music += (s, e) =>
            {
                lock (_lock)
                {
                    if (MusicTrack != e.MusicTrack)
                    {
                        MusicTrack = e.MusicTrack;
                        Flags &= ~GameStatusFlags.Shutdown;
                        api.InvokeGameStatusChanged(this);
                    }
                }
            };

            api.GameEvents.LoadGame += (s, e) =>
            {
                lock (_lock)
                {
                    GameMode = e.GameMode;
                    Horizons = e.Horizons ?? false;

                    Flags &= ~GameStatusFlags.Shutdown;
                    api.InvokeGameStatusChanged(this);
                }
            };
        }
    }
}