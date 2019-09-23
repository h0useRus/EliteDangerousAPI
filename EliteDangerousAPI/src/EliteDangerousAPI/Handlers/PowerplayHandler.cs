using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class PowerplayHandler
    {
        private readonly API.EliteDangerousAPI _api;
        internal PowerplayHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        ///  if player has pledged to a power
        /// </summary>
        public event EventHandler<PowerplayEvent> Powerplay;
        internal PowerplayEvent InvokeEvent(PowerplayEvent arg) { Powerplay?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when collecting powerplay commodities for delivery
        /// </summary>
        public event EventHandler<PowerplayCollectEvent> PowerplayCollect;
        internal PowerplayCollectEvent InvokeEvent(PowerplayCollectEvent arg) { PowerplayCollect?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a player defects from one power to another
        /// </summary>
        public event EventHandler<PowerplayDefectEvent> PowerplayDefect;
        internal PowerplayDefectEvent InvokeEvent(PowerplayDefectEvent arg) { PowerplayDefect?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when delivering powerplay commodities
        /// </summary>
        public event EventHandler<PowerplayDeliverEvent> PowerplayDeliver;
        internal PowerplayDeliverEvent InvokeEvent(PowerplayDeliverEvent arg) { PowerplayDeliver?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when paying to fast-track allocation of commodities
        /// </summary>
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrack;
        internal PowerplayFastTrackEvent InvokeEvent(PowerplayFastTrackEvent arg) { PowerplayFastTrack?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when joining up with a power
        /// </summary>
        public event EventHandler<PowerplayJoinEvent> PowerplayJoin;
        internal PowerplayJoinEvent InvokeEvent(PowerplayJoinEvent arg) { PowerplayJoin?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when leaving a power
        /// </summary>
        public event EventHandler<PowerplayLeaveEvent> PowerplayLeave;
        internal PowerplayLeaveEvent InvokeEvent(PowerplayLeaveEvent arg) { PowerplayLeave?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when receiving salary payment from a power
        /// </summary>
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalary;
        internal PowerplaySalaryEvent InvokeEvent(PowerplaySalaryEvent arg) { PowerplaySalary?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when voting for a system expansion
        /// </summary>
        public event EventHandler<PowerplayVoteEvent> PowerplayVote;
        internal PowerplayVoteEvent InvokeEvent(PowerplayVoteEvent arg) { PowerplayVote?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when receiving payment for powerplay combat
        /// </summary>
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucher;
        internal PowerplayVoucherEvent InvokeEvent(PowerplayVoucherEvent arg) { PowerplayVoucher?.Invoke(_api, arg); return arg; }
    }
}