using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class TravelHandler
    {
        private readonly API.EliteDangerousAPI _api;
        internal TravelHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// when landing at landing pad in a space station, outpost, or surface settlement
        /// </summary>
        public event EventHandler<DockedEvent> Docked;
        internal DockedEvent InvokeEvent(DockedEvent arg) { Docked?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player cancels a docking request
        /// </summary>
        public event EventHandler<DockingCancelledEvent> DockingCancelled;
        internal DockingCancelledEvent InvokeEvent(DockingCancelledEvent arg) { DockingCancelled?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the station denies a docking request
        /// </summary>
        public event EventHandler<DockingDeniedEvent> DockingDenied;
        internal DockingDeniedEvent InvokeEvent(DockingDeniedEvent arg) { DockingDenied?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a docking request is granted
        /// </summary>
        public event EventHandler<DockingGrantedEvent> DockingGranted;
        internal DockingGrantedEvent InvokeEvent(DockingGrantedEvent arg) { DockingGranted?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player requests docking at a station
        /// </summary>
        public event EventHandler<DockingRequestedEvent> DockingRequested;
        internal DockingRequestedEvent InvokeEvent(DockingRequestedEvent arg) { DockingRequested?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a docking request has timed out
        /// </summary>
        public event EventHandler<DockingTimeoutEvent> DockingTimeout;
        internal DockingTimeoutEvent InvokeEvent(DockingTimeoutEvent arg) { DockingTimeout?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when jumping from one star system to another
        /// </summary>
        public event EventHandler<FsdJumpEvent> FsdJump;
        internal FsdJumpEvent InvokeEvent(FsdJumpEvent arg) { FsdJump?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selecting a star system to jump to
        /// </summary>
        public event EventHandler<FsdTargetEvent> FsdTarget;
        internal FsdTargetEvent InvokeEvent(FsdTargetEvent arg) { FsdTarget?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when jumping from one star system to another
        /// </summary>
        public event EventHandler<LeaveBodyEvent> LeaveBody;
        internal LeaveBodyEvent InvokeEvent(LeaveBodyEvent arg) { LeaveBody?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when taking off from planet surface
        /// </summary>
        public event EventHandler<LiftoffEvent> Liftoff;
        internal LiftoffEvent InvokeEvent(LiftoffEvent arg) { Liftoff?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// at startup, or when being resurrected at a station
        /// </summary>
        public event EventHandler<LocationEvent> Location;
        internal LocationEvent InvokeEvent(LocationEvent arg) { Location?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// at the start of a Hyperspace or Supercruise jump (start of countdown) 
        /// </summary>
        public event EventHandler<StartJumpEvent> StartJump;
        internal StartJumpEvent InvokeEvent(StartJumpEvent arg) { StartJump?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  entering supercruise from normal space
        /// </summary>
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntry;
        internal SupercruiseEntryEvent InvokeEvent(SupercruiseEntryEvent arg) { SupercruiseEntry?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// leaving supercruise for normal space
        /// </summary>
        public event EventHandler<SupercruiseExitEvent> SupercruiseExit;
        internal SupercruiseExitEvent InvokeEvent(SupercruiseExitEvent arg) { SupercruiseExit?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// landing on a planet surface
        /// </summary>
        public event EventHandler<TouchdownEvent> Touchdown;
        internal TouchdownEvent InvokeEvent(TouchdownEvent arg) { Touchdown?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// liftoff from a landing pad in a station, outpost or settlement
        /// </summary>
        public event EventHandler<UndockedEvent> Undocked;
        internal UndockedEvent InvokeEvent(UndockedEvent arg) { Undocked?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when approaching a planetary settlement
        /// </summary>
        public event EventHandler<ApproachSettlementEvent> ApproachSettlement;
        internal ApproachSettlementEvent InvokeEvent(ApproachSettlementEvent arg) { ApproachSettlement?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when in Supercruise, and distance from planet drops to within the 'Orbital Cruise' zone 
        /// </summary>
        public event EventHandler<ApproachBodyEvent> ApproachBody;
        internal ApproachBodyEvent InvokeEvent(ApproachBodyEvent arg) { ApproachBody?.Invoke(_api, arg); return arg; }
    }
}