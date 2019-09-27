using System;
using System.Collections.Generic;
using System.IO;
using NSW.EliteDangerous.API.Events;
using NSW.EliteDangerous.API.Exceptions;
using NSW.EliteDangerous.API.Handlers;
using NSW.EliteDangerous.API.Statuses;

namespace NSW.EliteDangerous.API
{
    public interface IEliteDangerousAPI : IDisposable
    {
        /// <summary>
        /// Current listening Journal directory
        /// </summary>
        DirectoryInfo JournalDirectory { get; }
        /// <summary>
        /// Frontier documentation version
        /// </summary>
        int DocumentationVersion { get ; }
        /// <summary>
        /// API version
        /// </summary>
        string Version { get; }
        /// <summary>
        /// API status
        /// </summary>
        ApiStatus Status { get; }
        /// <summary>
        /// Plugins list
        /// </summary>
        IReadOnlyDictionary<Guid, IEliteDangerousPlugin> Plugins { get; }
        /// <summary>
        /// Start journal processing
        /// </summary>
        void Start();
        /// <summary>
        /// Stop journal processing
        /// </summary>
        void Stop();
        /// <summary>
        /// Global game events
        /// </summary>
        GameHandler GameEvents { get; }
        /// <summary>
        /// Player/Commander events
        /// </summary>
        PlayerHandler PlayerEvents { get; }
        /// <summary>
        /// Current ship/fighter/SRV events
        /// </summary>
        ShipHandler ShipEvents { get; }
        /// <summary>
        /// Combat events
        /// </summary>
        CombatHandler CombatEvents { get; }
        /// <summary>
        /// Exploration events
        /// </summary>
        ExplorationHandler ExplorationEvents { get; }
        /// <summary>
        /// Station services events
        /// </summary>
        StationHandler StationEvents { get; }
        /// <summary>
        /// Trade events
        /// </summary>
        TradeHandler TradeEvents { get; }
        /// <summary>
        /// Travel events
        /// </summary>
        TravelHandler TravelEvents { get; }
        /// <summary>
        /// Power play events
        /// </summary>
        PowerplayHandler PowerplayEvents { get; }
        /// <summary>
        /// Wing events
        /// </summary>
        WingHandler WingEvents { get; }
        /// <summary>
        /// Squadron events
        /// </summary>
        SquadronHandler SquadronEvents { get; }
        /// <summary>
        /// Multi-crew events
        /// </summary>
        CrewHandler CrewEvents { get; }
        /// <summary>
        /// Current game status
        /// </summary>
        GameStatus Game { get; }
        /// <summary>
        /// Current location status
        /// </summary>
        LocationStatus Location { get; }
        /// <summary>
        /// Current player status
        /// </summary>
        PlayerStatus Player { get; }
        /// <summary>
        /// Current ship status
        /// </summary>
        ShipStatus Ship { get; }
        /// <summary>
        /// API status event
        /// </summary>
        event EventHandler<ApiStatus> StatusChanged;
        /// <summary>
        /// New journal event
        /// </summary>
        event EventHandler<string> JournalFound;
        /// <summary>
        /// Original journal json before processing
        /// </summary>
        event EventHandler<OriginalEvent> BeforeEvent;
        /// <summary>
        /// All processed events, raise after original event trowed.
        /// </summary>
        event EventHandler<ProcessedEvent> AllEvents;
        /// <summary>
        /// All API errors
        /// </summary>
        event EventHandler<JournalException> Errors;
        /// <summary>
        /// All API warnings
        /// </summary>
        event EventHandler<JournalException> Warnings;
        /// <summary>
        /// When game status changed
        /// </summary>
        event EventHandler<GameStatus> GameChanged;
        /// <summary>
        /// When player/commander status changed
        /// </summary>
        event EventHandler<PlayerStatus> PlayerChanged;
        /// <summary>
        /// When location changed
        /// </summary>
        event EventHandler<LocationStatus> LocationChanged;
        /// <summary>
        /// When ship status changed
        /// </summary>
        event EventHandler<ShipStatus> ShipChanged;
    }
}