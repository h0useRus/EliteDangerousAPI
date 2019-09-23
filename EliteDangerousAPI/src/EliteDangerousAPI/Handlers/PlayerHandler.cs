using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class PlayerHandler
    {
        private readonly API.EliteDangerousAPI _api;

        internal PlayerHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// Get missions on startup
        /// </summary>
        public event EventHandler<MissionsEvent> Missions;
        internal MissionsEvent InvokeEvent(MissionsEvent arg) { Missions?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// Creating a new commander
        /// </summary>
        public event EventHandler<CommanderEvent> Commander;
        internal CommanderEvent InvokeEvent(CommanderEvent arg) { Commander?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// Creating a new commander
        /// </summary>
        public event EventHandler<NewCommanderEvent> NewCommander;
        internal NewCommanderEvent InvokeEvent(NewCommanderEvent arg) { NewCommander?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// Load player progress at startup
        /// </summary>
        public event EventHandler<ProgressEvent> Progress;
        internal ProgressEvent InvokeEvent(ProgressEvent arg) { Progress?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// Load player ranks at startup
        /// </summary>
        public event EventHandler<RankEvent> Rank;
        internal RankEvent InvokeEvent(RankEvent arg) { Rank?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player's rank increases
        /// </summary>
        public event EventHandler<PromotionEvent> Promotion;
        internal PromotionEvent InvokeEvent(PromotionEvent arg) { Promotion?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a text message is received from another player or npc
        /// </summary>
        public event EventHandler<ReceiveTextEvent> ReceiveText;
        internal ReceiveTextEvent InvokeEvent(ReceiveTextEvent arg) { ReceiveText?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a text message is sent to another player
        /// </summary>
        public event EventHandler<SendTextEvent> SendText;
        internal SendTextEvent InvokeEvent(SendTextEvent arg) { SendText?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when the player restarts after death
        /// </summary>
        public event EventHandler<ResurrectEvent> Resurrect;
        internal ResurrectEvent InvokeEvent(ResurrectEvent arg) { Resurrect?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// This gives the player's reputation (on a scale of -100..+100) with the superpowers 
        /// </summary>
        public event EventHandler<ReputationEvent> Reputation;
        internal ReputationEvent InvokeEvent(ReputationEvent arg) { Reputation?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// The information displayed in the statistics panel on the right side of the cockpit
        /// </summary>
        public event EventHandler<StatisticsEvent> Statistics;
        internal StatisticsEvent InvokeEvent(StatisticsEvent arg) { Statistics?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when receiving information about a change in a friend's status
        /// </summary>
        public event EventHandler<FriendsEvent> Friends;
        internal FriendsEvent InvokeEvent(FriendsEvent arg) { Friends?.Invoke(_api, arg); return arg; }
    }
}