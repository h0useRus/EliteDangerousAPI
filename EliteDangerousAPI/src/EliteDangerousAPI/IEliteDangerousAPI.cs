using System;
using System.Collections.Generic;
using System.IO;
using NSW.EliteDangerous.API.Exceptions;
using NSW.EliteDangerous.API.Handlers;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.API
{
    public interface IEliteDangerousAPI : IDisposable
    {
        DirectoryInfo JournalDirectory { get; }
        int DocumentationVersion { get ; }
        string Version { get; }
        ApiStatus Status { get; }
        IReadOnlyDictionary<Guid, IEliteDangerousPlugin> Plugins { get; }

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
        event EventHandler<string> JournalFound;
        event EventHandler<GlobalEvent> AllEvents;
        event EventHandler<JournalException> Errors;
        event EventHandler<JournalException> Warnings;
    }
}