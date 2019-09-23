using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class SquadronHandler
    {
        private readonly API.EliteDangerousAPI _api;

        internal SquadronHandler(API.EliteDangerousAPI api) { _api = api; }

        /// <summary>
        /// The player applied to squadron
        /// </summary>
        public event EventHandler<AppliedToSquadronEvent> AppliedToSquadron;
        internal AppliedToSquadronEvent InvokeEvent(AppliedToSquadronEvent arg) { AppliedToSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when squadron disbanded
        /// </summary>
        public event EventHandler<DisbandedSquadronEvent> DisbandedSquadron;
        internal DisbandedSquadronEvent InvokeEvent(DisbandedSquadronEvent arg) { DisbandedSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player was invited to squadron
        /// </summary>
        public event EventHandler<InvitedToSquadronEvent> InvitedToSquadron;
        internal InvitedToSquadronEvent InvokeEvent(InvitedToSquadronEvent arg) { InvitedToSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player joined squadron
        /// </summary>
        public event EventHandler<JoinedSquadronEvent> JoinedSquadron;
        internal JoinedSquadronEvent InvokeEvent(JoinedSquadronEvent arg) { JoinedSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player kicked from squadron
        /// </summary>
        public event EventHandler<KickedFromSquadronEvent> KickedFromSquadron;
        internal KickedFromSquadronEvent InvokeEvent(KickedFromSquadronEvent arg) { KickedFromSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player kicked from squadron
        /// </summary>
        public event EventHandler<LeftSquadronEvent> LeftSquadron;
        internal LeftSquadronEvent InvokeEvent(LeftSquadronEvent arg) { LeftSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player shared bookmark with squadron members
        /// </summary>
        public event EventHandler<SharedBookmarkToSquadronEvent> SharedBookmarkToSquadron;
        internal SharedBookmarkToSquadronEvent InvokeEvent(SharedBookmarkToSquadronEvent arg) { SharedBookmarkToSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when squadron created
        /// </summary>
        public event EventHandler<SquadronCreatedEvent> SquadronCreated;
        internal SquadronCreatedEvent InvokeEvent(SquadronCreatedEvent arg) { SquadronCreated?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron demotion player rank
        /// </summary>
        public event EventHandler<SquadronDemotionEvent> SquadronDemotion;
        internal SquadronDemotionEvent InvokeEvent(SquadronDemotionEvent arg) { SquadronDemotion?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron promotion player rank
        /// </summary>
        public event EventHandler<SquadronPromotionEvent> SquadronPromotion;
        internal SquadronPromotionEvent InvokeEvent(SquadronPromotionEvent arg) { SquadronPromotion?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron startup
        /// </summary>
        public event EventHandler<SquadronStartupEvent> SquadronStartup;
        internal SquadronStartupEvent InvokeEvent(SquadronStartupEvent arg) { SquadronStartup?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron demotion
        /// </summary>
        public event EventHandler<WonATrophyForSquadronEvent> WonATrophyForSquadron;
        internal WonATrophyForSquadronEvent InvokeEvent(WonATrophyForSquadronEvent arg) { WonATrophyForSquadron?.Invoke(_api, arg); return arg; }
    }
}