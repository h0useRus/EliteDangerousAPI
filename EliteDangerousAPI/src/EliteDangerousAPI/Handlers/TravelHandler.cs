using System;
using NSW.EliteDangerous.API.Events;

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
        internal DockedEvent InvokeEvent(DockedEvent arg) { if(_api.ValidateEvent(arg)) Docked?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player cancels a docking request
        /// </summary>
        public event EventHandler<DockingCancelledEvent> DockingCancelled;
        internal DockingCancelledEvent InvokeEvent(DockingCancelledEvent arg) { if(_api.ValidateEvent(arg)) DockingCancelled?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the station denies a docking request
        /// </summary>
        public event EventHandler<DockingDeniedEvent> DockingDenied;
        internal DockingDeniedEvent InvokeEvent(DockingDeniedEvent arg) { if(_api.ValidateEvent(arg)) DockingDenied?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a docking request is granted
        /// </summary>
        public event EventHandler<DockingGrantedEvent> DockingGranted;
        internal DockingGrantedEvent InvokeEvent(DockingGrantedEvent arg) { if(_api.ValidateEvent(arg)) DockingGranted?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player requests docking at a station
        /// </summary>
        public event EventHandler<DockingRequestedEvent> DockingRequested;
        internal DockingRequestedEvent InvokeEvent(DockingRequestedEvent arg) { if(_api.ValidateEvent(arg)) DockingRequested?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a docking request has timed out
        /// </summary>
        public event EventHandler<DockingTimeoutEvent> DockingTimeout;
        internal DockingTimeoutEvent InvokeEvent(DockingTimeoutEvent arg) { if(_api.ValidateEvent(arg)) DockingTimeout?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when jumping from one star system to another
        /// </summary>
        public event EventHandler<FsdJumpEvent> FsdJump;
        internal FsdJumpEvent InvokeEvent(FsdJumpEvent arg) { if(_api.ValidateEvent(arg)) FsdJump?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selecting a star system to jump to
        /// </summary>
        public event EventHandler<FsdTargetEvent> FsdTarget;
        internal FsdTargetEvent InvokeEvent(FsdTargetEvent arg) { if(_api.ValidateEvent(arg)) FsdTarget?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when jumping from one star system to another
        /// </summary>
        public event EventHandler<LeaveBodyEvent> LeaveBody;
        internal LeaveBodyEvent InvokeEvent(LeaveBodyEvent arg) { if(_api.ValidateEvent(arg)) LeaveBody?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when taking off from planet surface
        /// </summary>
        public event EventHandler<LiftoffEvent> Liftoff;
        internal LiftoffEvent InvokeEvent(LiftoffEvent arg) { if(_api.ValidateEvent(arg)) Liftoff?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// at startup, or when being resurrected at a station
        /// </summary>
        public event EventHandler<LocationEvent> Location;
        internal LocationEvent InvokeEvent(LocationEvent arg) { if(_api.ValidateEvent(arg)) Location?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// at the start of a Hyperspace or Supercruise jump (start of countdown) 
        /// </summary>
        public event EventHandler<StartJumpEvent> StartJump;
        internal StartJumpEvent InvokeEvent(StartJumpEvent arg) { if(_api.ValidateEvent(arg)) StartJump?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  entering supercruise from normal space
        /// </summary>
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntry;
        internal SupercruiseEntryEvent InvokeEvent(SupercruiseEntryEvent arg) { if(_api.ValidateEvent(arg)) SupercruiseEntry?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// leaving supercruise for normal space
        /// </summary>
        public event EventHandler<SupercruiseExitEvent> SupercruiseExit;
        internal SupercruiseExitEvent InvokeEvent(SupercruiseExitEvent arg) { if(_api.ValidateEvent(arg)) SupercruiseExit?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// landing on a planet surface
        /// </summary>
        public event EventHandler<TouchdownEvent> Touchdown;
        internal TouchdownEvent InvokeEvent(TouchdownEvent arg) { if(_api.ValidateEvent(arg)) Touchdown?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// liftoff from a landing pad in a station, outpost or settlement
        /// </summary>
        public event EventHandler<UndockedEvent> Undocked;
        internal UndockedEvent InvokeEvent(UndockedEvent arg) { if(_api.ValidateEvent(arg)) Undocked?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when approaching a planetary settlement
        /// </summary>
        public event EventHandler<ApproachSettlementEvent> ApproachSettlement;
        internal ApproachSettlementEvent InvokeEvent(ApproachSettlementEvent arg) { if(_api.ValidateEvent(arg)) ApproachSettlement?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when in Supercruise, and distance from planet drops to within the 'Orbital Cruise' zone 
        /// </summary>
        public event EventHandler<ApproachBodyEvent> ApproachBody;
        internal ApproachBodyEvent InvokeEvent(ApproachBodyEvent arg) { if(_api.ValidateEvent(arg)) ApproachBody?.Invoke(_api, arg); return arg; }
    }
}