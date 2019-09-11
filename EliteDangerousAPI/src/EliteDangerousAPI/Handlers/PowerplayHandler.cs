using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Handlers
{
    public class PowerplayHandler
    {
        internal PowerplayHandler() { }
        /// <summary>
        ///  if player has pledged to a power
        /// </summary>
        public event EventHandler<PowerplayEvent> Powerplay;
        internal PowerplayEvent InvokeEvent(PowerplayEvent arg) { Powerplay?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when collecting powerplay commodities for delivery
        /// </summary>
        public event EventHandler<PowerplayCollectEvent> PowerplayCollect;
        internal PowerplayCollectEvent InvokeEvent(PowerplayCollectEvent arg) { PowerplayCollect?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when a player defects from one power to another
        /// </summary>
        public event EventHandler<PowerplayDefectEvent> PowerplayDefect;
        internal PowerplayDefectEvent InvokeEvent(PowerplayDefectEvent arg) { PowerplayDefect?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when delivering powerplay commodities
        /// </summary>
        public event EventHandler<PowerplayDeliverEvent> PowerplayDeliver;
        internal PowerplayDeliverEvent InvokeEvent(PowerplayDeliverEvent arg) { PowerplayDeliver?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when paying to fast-track allocation of commodities
        /// </summary>
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrack;
        internal PowerplayFastTrackEvent InvokeEvent(PowerplayFastTrackEvent arg) { PowerplayFastTrack?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when joining up with a power
        /// </summary>
        public event EventHandler<PowerplayJoinEvent> PowerplayJoin;
        internal PowerplayJoinEvent InvokeEvent(PowerplayJoinEvent arg) { PowerplayJoin?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when leaving a power
        /// </summary>
        public event EventHandler<PowerplayLeaveEvent> PowerplayLeave;
        internal PowerplayLeaveEvent InvokeEvent(PowerplayLeaveEvent arg) { PowerplayLeave?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when receiving salary payment from a power
        /// </summary>
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalary;
        internal PowerplaySalaryEvent InvokeEvent(PowerplaySalaryEvent arg) { PowerplaySalary?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when voting for a system expansion
        /// </summary>
        public event EventHandler<PowerplayVoteEvent> PowerplayVote;
        internal PowerplayVoteEvent InvokeEvent(PowerplayVoteEvent arg) { PowerplayVote?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when receiving payment for powerplay combat
        /// </summary>
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucher;
        internal PowerplayVoucherEvent InvokeEvent(PowerplayVoucherEvent arg) { PowerplayVoucher?.Invoke(this, arg); return arg; }
    }
}