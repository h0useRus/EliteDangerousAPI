using System;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Statuses
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

            api.Game.Status += (s, e) =>
            {
                if (e == null) return;

                if (GuiFocus != e.GuiFocus)
                {
                    GuiFocus = e.GuiFocus;
                    api.InvokeGameStatusChanged(this);
                }
            };

            api.Game.FileHeader += (s, e) =>
            {
                if (e == null) return;

                Version = $"{e.GameVersion} ({e.Build})";
                Language = e.Language;
                Flags |= GameStatusFlags.HeaderFound;
                api.InvokeGameStatusChanged(this);
            };

            api.Game.Shutdown += (s, e) =>
            {
                if (e == null) return;

                Flags |= GameStatusFlags.Shutdown;
                api.InvokeGameStatusChanged(this);
            };

            api.Game.Music += (s, e) =>
            {
                if (e == null) return;

                if (MusicTrack != e.MusicTrack)
                {
                    MusicTrack = e.MusicTrack;
                    api.InvokeGameStatusChanged(this);
                }
            };

            api.Game.LoadGame += (s, e) =>
            {
                if (e == null) return;

                GameMode = e.GameMode;
                Horizons = e.Horizons ?? false;
                api.InvokeGameStatusChanged(this);
            };
        }
    }
}