using System;
using System.IO;
using NSW.EliteDangerous.Events;
using NSW.EliteDangerous.Exceptions;
using NSW.EliteDangerous.Handlers;

namespace NSW.EliteDangerous
{
    public interface IEliteDangerousAPI : IDisposable
    {
        DirectoryInfo JournalDirectory { get; }
        int DocumentationVersion { get ; }
        string Version { get; }
        ApiStatus Status { get; }
        bool GameRunning { get; }

        void Start();
        void Stop();

        GameHandler Game { get; }
        PlayerHandler Player { get; }
        ShipHandler Ship { get; }
        CombatHandler Combat { get; }
        ExplorationHandler Exploration { get; }
        StationHandler Station { get; }
        TradeHandler Trade { get; }
        TravelHandler Travel { get; }
        PowerplayHandler Powerplay { get; }
        WingHandler Wing { get; }
        SquadronHandler Squadron { get; }
        CrewHandler Crew { get; }

        event EventHandler<ApiStatus> StatusChanged;
        event EventHandler<GlobalEvent> AllEvents;
        event EventHandler<JournalException> Errors;
        event EventHandler<JournalException> Warnings;
    }
}