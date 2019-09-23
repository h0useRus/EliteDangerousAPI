using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class WingHandler
    {
        private readonly API.EliteDangerousAPI _api;

        internal WingHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// When another player has joined the wing
        /// </summary>
        public event EventHandler<WingAddEvent> WingAdd;
        internal WingAddEvent InvokeEvent(WingAddEvent arg) { WingAdd?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player is invited to a wing
        /// </summary>
        public event EventHandler<WingInviteEvent> WingInvite;
        internal WingInviteEvent InvokeEvent(WingInviteEvent arg) { WingInvite?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When this player has joined a wing
        /// </summary>
        public event EventHandler<WingJoinEvent> WingJoin;
        internal WingJoinEvent InvokeEvent(WingJoinEvent arg) { WingJoin?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When this player has left a wing
        /// </summary>
        public event EventHandler<WingLeaveEvent> WingLeave;
        internal WingLeaveEvent InvokeEvent(WingLeaveEvent arg) { WingLeave?.Invoke(_api, arg); return arg; }
    }
}