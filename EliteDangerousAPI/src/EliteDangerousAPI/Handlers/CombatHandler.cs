using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Handlers
{
    public class CombatHandler
    {
        internal CombatHandler() { }
        /// <summary>
        /// The player is awarded a bounty for a kill
        /// </summary>
        public event EventHandler<BountyEvent> Bounty;
        internal BountyEvent InvokeEvent(BountyEvent arg) { Bounty?.Invoke(this, arg); return arg; }
        /// <summary>
        /// The player has been rewarded for a capital ship combat
        /// </summary>
        public event EventHandler<CapShipBondEvent> CapShipBond;
        internal CapShipBondEvent InvokeEvent(CapShipBondEvent arg) { CapShipBond?.Invoke(this, arg); return arg; }
        /// <summary>
        /// The player was killed
        /// </summary>
        public event EventHandler<DiedEvent> Died;
        internal DiedEvent InvokeEvent(DiedEvent arg) { Died?.Invoke(this, arg); return arg; }
        /// <summary>
        /// The player has escaped interdiction
        /// </summary>
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdiction;
        internal EscapeInterdictionEvent InvokeEvent(EscapeInterdictionEvent arg) { EscapeInterdiction?.Invoke(this, arg); return arg; }
        /// <summary>
        /// The player rewarded for taking part in a combat zone
        /// </summary>
        public event EventHandler<FactionKillBondEvent> FactionKillBond;
        internal FactionKillBondEvent InvokeEvent(FactionKillBondEvent arg) { FactionKillBond?.Invoke(this, arg); return arg; }
        /// <summary>
        /// The player rewarded for taking part in a combat zone
        /// </summary>
        public event EventHandler<FighterDestroyedEvent> FighterDestroyed;
        internal FighterDestroyedEvent InvokeEvent(FighterDestroyedEvent arg) { FighterDestroyed?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when taking damage due to overheating
        /// </summary>
        public event EventHandler<HeatDamageEvent> HeatDamage;
        internal HeatDamageEvent InvokeEvent(HeatDamageEvent arg) { HeatDamage?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when heat exceeds 100%
        /// </summary>
        public event EventHandler<HeatWarningEvent> HeatWarning;
        internal HeatWarningEvent InvokeEvent(HeatWarningEvent arg) { HeatWarning?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when hull health drops below a threshold (20% steps)
        /// </summary>
        public event EventHandler<HullDamageEvent> HullDamage;
        internal HullDamageEvent InvokeEvent(HullDamageEvent arg) { HullDamage?.Invoke(this, arg); return arg; }
        /// <summary>
        /// The player was interdicted by player or npc
        /// </summary>
        public event EventHandler<InterdictedEvent> Interdicted;
        internal InterdictedEvent InvokeEvent(InterdictedEvent arg) { Interdicted?.Invoke(this, arg); return arg; }
        /// <summary>
        /// The player has (attempted to) interdict another player or npc
        /// </summary>
        public event EventHandler<InterdictionEvent> Interdiction;
        internal InterdictionEvent InvokeEvent(InterdictionEvent arg) { Interdiction?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when this player has killed another player
        /// </summary>
        public event EventHandler<PvpKillEvent> PvpKill;
        internal PvpKillEvent InvokeEvent(PvpKillEvent arg) { PvpKill?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when shields are disabled in combat, or recharged
        /// </summary>
        public event EventHandler<ShieldStateEvent> ShieldState;
        internal ShieldStateEvent InvokeEvent(ShieldStateEvent arg) { ShieldState?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when cockpit canopy is breached
        /// </summary>
        public event EventHandler<CockpitBreachedEvent> CockpitBreached;
        internal CockpitBreachedEvent InvokeEvent(CockpitBreachedEvent arg) { CockpitBreached?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when the current player selects a new target 
        /// </summary>
        public event EventHandler<ShipTargetedEvent> ShipTargeted;
        internal ShipTargetedEvent InvokeEvent(ShipTargetedEvent arg) { ShipTargeted?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when the player's SRV is destroyed 
        /// </summary>
        public event EventHandler<SrvDestroyedEvent> SrvDestroyed;
        internal SrvDestroyedEvent InvokeEvent(SrvDestroyedEvent arg) { SrvDestroyed?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when player targeting another ship
        /// </summary>
        public event EventHandler<UnderAttackEvent> UnderAttack;
        internal UnderAttackEvent InvokeEvent(UnderAttackEvent arg) { UnderAttack?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when a crime is recorded against the player
        /// </summary>
        public event EventHandler<CommitCrimeEvent> CommitCrime;
        internal CommitCrimeEvent InvokeEvent(CommitCrimeEvent arg) { CommitCrime?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when a crime is recorded against the player
        /// </summary>
        public event EventHandler<CrimeVictimEvent> CrimeVictim;
        internal CrimeVictimEvent InvokeEvent(CrimeVictimEvent arg) { CrimeVictim?.Invoke(this, arg); return arg; }
    }
}