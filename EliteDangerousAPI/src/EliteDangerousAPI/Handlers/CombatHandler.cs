using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class CombatHandler
    {
        private readonly API.EliteDangerousAPI _api;

        internal CombatHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// The player is awarded a bounty for a kill
        /// </summary>
        public event EventHandler<BountyEvent> Bounty;
        internal BountyEvent InvokeEvent(BountyEvent arg) { if(_api.ValidateEvent(arg)) Bounty?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The player has been rewarded for a capital ship combat
        /// </summary>
        public event EventHandler<CapShipBondEvent> CapShipBond;
        internal CapShipBondEvent InvokeEvent(CapShipBondEvent arg) { if(_api.ValidateEvent(arg)) CapShipBond?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The player was killed
        /// </summary>
        public event EventHandler<DiedEvent> Died;
        internal DiedEvent InvokeEvent(DiedEvent arg) { if(_api.ValidateEvent(arg)) Died?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The player has escaped interdiction
        /// </summary>
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdiction;
        internal EscapeInterdictionEvent InvokeEvent(EscapeInterdictionEvent arg) { if(_api.ValidateEvent(arg)) EscapeInterdiction?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The player rewarded for taking part in a combat zone
        /// </summary>
        public event EventHandler<FactionKillBondEvent> FactionKillBond;
        internal FactionKillBondEvent InvokeEvent(FactionKillBondEvent arg) { if(_api.ValidateEvent(arg)) FactionKillBond?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The player rewarded for taking part in a combat zone
        /// </summary>
        public event EventHandler<FighterDestroyedEvent> FighterDestroyed;
        internal FighterDestroyedEvent InvokeEvent(FighterDestroyedEvent arg) { if(_api.ValidateEvent(arg)) FighterDestroyed?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when taking damage due to overheating
        /// </summary>
        public event EventHandler<HeatDamageEvent> HeatDamage;
        internal HeatDamageEvent InvokeEvent(HeatDamageEvent arg) { if(_api.ValidateEvent(arg)) HeatDamage?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when heat exceeds 100%
        /// </summary>
        public event EventHandler<HeatWarningEvent> HeatWarning;
        internal HeatWarningEvent InvokeEvent(HeatWarningEvent arg) { if(_api.ValidateEvent(arg)) HeatWarning?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when hull health drops below a threshold (20% steps)
        /// </summary>
        public event EventHandler<HullDamageEvent> HullDamage;
        internal HullDamageEvent InvokeEvent(HullDamageEvent arg) { if(_api.ValidateEvent(arg)) HullDamage?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The player was interdicted by player or npc
        /// </summary>
        public event EventHandler<InterdictedEvent> Interdicted;
        internal InterdictedEvent InvokeEvent(InterdictedEvent arg) { if(_api.ValidateEvent(arg)) Interdicted?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The player has (attempted to) interdict another player or npc
        /// </summary>
        public event EventHandler<InterdictionEvent> Interdiction;
        internal InterdictionEvent InvokeEvent(InterdictionEvent arg) { if(_api.ValidateEvent(arg)) Interdiction?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when this player has killed another player
        /// </summary>
        public event EventHandler<PvpKillEvent> PvpKill;
        internal PvpKillEvent InvokeEvent(PvpKillEvent arg) { if(_api.ValidateEvent(arg)) PvpKill?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when shields are disabled in combat, or recharged
        /// </summary>
        public event EventHandler<ShieldStateEvent> ShieldState;
        internal ShieldStateEvent InvokeEvent(ShieldStateEvent arg) { if(_api.ValidateEvent(arg)) ShieldState?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when cockpit canopy is breached
        /// </summary>
        public event EventHandler<CockpitBreachedEvent> CockpitBreached;
        internal CockpitBreachedEvent InvokeEvent(CockpitBreachedEvent arg) { if(_api.ValidateEvent(arg)) CockpitBreached?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the current player selects a new target 
        /// </summary>
        public event EventHandler<ShipTargetedEvent> ShipTargeted;
        internal ShipTargetedEvent InvokeEvent(ShipTargetedEvent arg) { if(_api.ValidateEvent(arg)) ShipTargeted?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player's SRV is destroyed 
        /// </summary>
        public event EventHandler<SrvDestroyedEvent> SrvDestroyed;
        internal SrvDestroyedEvent InvokeEvent(SrvDestroyedEvent arg) { if(_api.ValidateEvent(arg)) SrvDestroyed?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player targeting another ship
        /// </summary>
        public event EventHandler<UnderAttackEvent> UnderAttack;
        internal UnderAttackEvent InvokeEvent(UnderAttackEvent arg) { if(_api.ValidateEvent(arg)) UnderAttack?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a crime is recorded against the player
        /// </summary>
        public event EventHandler<CommitCrimeEvent> CommitCrime;
        internal CommitCrimeEvent InvokeEvent(CommitCrimeEvent arg) { if(_api.ValidateEvent(arg)) CommitCrime?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a crime is recorded against the player
        /// </summary>
        public event EventHandler<CrimeVictimEvent> CrimeVictim;
        internal CrimeVictimEvent InvokeEvent(CrimeVictimEvent arg) { if(_api.ValidateEvent(arg)) CrimeVictim?.Invoke(_api, arg); return arg; }
    }
}