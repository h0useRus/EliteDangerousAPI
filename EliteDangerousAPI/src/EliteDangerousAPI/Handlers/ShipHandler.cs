using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class ShipHandler
    {
        private readonly API.EliteDangerousAPI _api;

        internal ShipHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// at startup, when loading from main menu, or when switching ships, or after changing the ship in Outfitting, or when docking SRV back in mothership 
        /// </summary>
        public event EventHandler<LoadoutEvent> Loadout;
        internal LoadoutEvent InvokeEvent(LoadoutEvent arg) { if(_api.ValidateEvent(arg)) Loadout?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when docking a fighter back with the mothership
        /// </summary>
        public event EventHandler<DockFighterEvent> DockFighter;
        internal DockFighterEvent InvokeEvent(DockFighterEvent arg) { if(_api.ValidateEvent(arg)) DockFighter?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when docking an SRV with the ship
        /// </summary>
        public event EventHandler<DockSrvEvent> DockSrv;
        internal DockSrvEvent InvokeEvent(DockSrvEvent arg) { if(_api.ValidateEvent(arg)) DockSrv?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when scooping fuel from a star
        /// </summary>
        public event EventHandler<FuelScoopEvent> FuelScoop;
        internal FuelScoopEvent InvokeEvent(FuelScoopEvent arg) { if(_api.ValidateEvent(arg)) FuelScoop?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when enough material has been collected from a solar jet code (at a white dwarf or neutron star) for a jump boost
        /// </summary>
        public event EventHandler<JetConeBoostEvent> JetConeBoost;
        internal JetConeBoostEvent InvokeEvent(JetConeBoostEvent arg) { if(_api.ValidateEvent(arg)) JetConeBoost?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when passing through the jet code from a white dwarf or neutron star has caused damage to a ship module
        /// </summary>
        public event EventHandler<JetConeDamageEvent> JetConeDamage;
        internal JetConeDamageEvent InvokeEvent(JetConeDamageEvent arg) { if(_api.ValidateEvent(arg)) JetConeDamage?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when launching a fighter
        /// </summary>
        public event EventHandler<LaunchFighterEvent> LaunchFighter;
        internal LaunchFighterEvent InvokeEvent(LaunchFighterEvent arg) { if(_api.ValidateEvent(arg)) LaunchFighter?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a ship's fighter is rebuilt in the hangar 
        /// </summary>
        public event EventHandler<FighterRebuiltEvent> FighterRebuilt;
        internal FighterRebuiltEvent InvokeEvent(FighterRebuiltEvent arg) { if(_api.ValidateEvent(arg)) FighterRebuilt?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when deploying the SRV from a ship onto planet surface
        /// </summary>
        public event EventHandler<LaunchSrvEvent> LaunchSrv;
        internal LaunchSrvEvent InvokeEvent(LaunchSrvEvent arg) { if(_api.ValidateEvent(arg)) LaunchSrv?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when using any type of drone/limpet 
        /// </summary>
        public event EventHandler<LaunchDroneEvent> LaunchDrone;
        internal LaunchDroneEvent InvokeEvent(LaunchDroneEvent arg) { if(_api.ValidateEvent(arg)) LaunchDrone?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the 'reboot repair' function is used
        /// </summary>
        public event EventHandler<RebootRepairEvent> RebootRepair;
        internal RebootRepairEvent InvokeEvent(RebootRepairEvent arg) { if(_api.ValidateEvent(arg)) RebootRepair?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the 'self destruct' function is used
        /// </summary>
        public event EventHandler<SelfDestructEvent> SelfDestruct;
        internal SelfDestructEvent InvokeEvent(SelfDestructEvent arg) { if(_api.ValidateEvent(arg)) SelfDestruct?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when synthesis is used to repair or rearm
        /// </summary>
        public event EventHandler<SynthesisEvent> Synthesis;
        internal SynthesisEvent InvokeEvent(SynthesisEvent arg) { if(_api.ValidateEvent(arg)) Synthesis?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when switching control between the main ship and a fighter
        /// </summary>
        public event EventHandler<VehicleSwitchEvent> VehicleSwitch;
        internal VehicleSwitchEvent InvokeEvent(VehicleSwitchEvent arg) { if(_api.ValidateEvent(arg)) VehicleSwitch?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when Auto Field-Maintenance Unit repair finished
        /// </summary>
        public event EventHandler<AfmuRepairsEvent> AfmuRepairs;
        internal AfmuRepairsEvent InvokeEvent(AfmuRepairsEvent arg) { if(_api.ValidateEvent(arg)) AfmuRepairs?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when cargo updated
        /// </summary>
        public event EventHandler<CargoEvent> Cargo;
        internal CargoEvent InvokeEvent(CargoEvent arg) { if(_api.ValidateEvent(arg)) Cargo?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when passenger list avail
        /// </summary>
        public event EventHandler<PassengersEvent> Passengers;
        internal PassengersEvent InvokeEvent(PassengersEvent arg) { if(_api.ValidateEvent(arg)) Passengers?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when passenger list avail
        /// </summary>
        public event EventHandler<ModuleInfoEvent> ModuleInfo;
        internal ModuleInfoEvent InvokeEvent(ModuleInfoEvent arg) { if(_api.ValidateEvent(arg)) ModuleInfo?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player's ship has been repaired by a repair drone 
        /// </summary>
        public event EventHandler<RepairDroneEvent> RepairDrone;
        internal RepairDroneEvent InvokeEvent(RepairDroneEvent arg) { if(_api.ValidateEvent(arg)) RepairDrone?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When fuel is moved from one fuel tank to another  
        /// </summary>
        public event EventHandler<ReservoirReplenishedEvent> ReservoirReplenished;
        internal ReservoirReplenishedEvent InvokeEvent(ReservoirReplenishedEvent arg) { if(_api.ValidateEvent(arg)) ReservoirReplenished?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When fuel is moved from one fuel tank to another  
        /// </summary>
        public event EventHandler<ScannedEvent> Scanned;
        internal ScannedEvent InvokeEvent(ScannedEvent arg) { if(_api.ValidateEvent(arg)) Scanned?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When fuel is moved from one fuel tank to another  
        /// </summary>
        public event EventHandler<SystemsShutdownEvent> SystemsShutdown;
        internal SystemsShutdownEvent InvokeEvent(SystemsShutdownEvent arg) { if(_api.ValidateEvent(arg)) SystemsShutdown?.Invoke(_api, arg); return arg; }
    }
}