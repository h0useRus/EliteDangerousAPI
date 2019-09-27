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
        public GameStatusFlags Flags { get; private set; }
        public bool Running => API.EliteDangerousAPI.GameRunning;
        public string Version { get; private set; }
        public string Language { get; private set; }
        public string MusicTrack { get; private set; }
        public GameMode GameMode { get; private set; }
        public bool Horizons { get; private set; }
        public GuiFocus GuiFocus { get; private set; } = GuiFocus.NoFocus;


        internal GameStatus(API.EliteDangerousAPI api)
        {
            Flags = GameStatusFlags.None;

            api.GameEvents.Status += (s, e) =>
            {
                if (GuiFocus != e.GuiFocus)
                {
                    GuiFocus = e.GuiFocus;
                    api.InvokeGameStatusChanged(this);
                }
            };

            api.GameEvents.FileHeader += (s, e) =>
            {
                Version = $"{e.GameVersion} ({e.Build})";
                Language = e.Language;
                Flags |= GameStatusFlags.HeaderFound;
                api.InvokeGameStatusChanged(this);
            };

            api.GameEvents.Shutdown += (s, e) =>
            {
                Flags |= GameStatusFlags.Shutdown;
                api.InvokeGameStatusChanged(this);
            };

            api.GameEvents.Music += (s, e) =>
            {
                if (MusicTrack != e.MusicTrack)
                {
                    MusicTrack = e.MusicTrack;
                    api.InvokeGameStatusChanged(this);
                }
            };

            api.GameEvents.LoadGame += (s, e) =>
            {
                GameMode = e.GameMode;
                Horizons = e.Horizons ?? false;
                api.InvokeGameStatusChanged(this);
            };
        }
    }
}