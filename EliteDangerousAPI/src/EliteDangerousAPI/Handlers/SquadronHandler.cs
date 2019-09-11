using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Handlers
{
    public class SquadronHandler
    {
        internal SquadronHandler(){}

        /// <summary>
        /// The player applied to squadron
        /// </summary>
        public event EventHandler<AppliedToSquadronEvent> AppliedToSquadron;
        internal AppliedToSquadronEvent InvokeEvent(AppliedToSquadronEvent arg) { AppliedToSquadron?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when squadron disbanded
        /// </summary>
        public event EventHandler<DisbandedSquadronEvent> DisbandedSquadron;
        internal DisbandedSquadronEvent InvokeEvent(DisbandedSquadronEvent arg) { DisbandedSquadron?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when player was invited to squadron
        /// </summary>
        public event EventHandler<InvitedToSquadronEvent> InvitedToSquadron;
        internal InvitedToSquadronEvent InvokeEvent(InvitedToSquadronEvent arg) { InvitedToSquadron?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when player joined squadron
        /// </summary>
        public event EventHandler<JoinedSquadronEvent> JoinedSquadron;
        internal JoinedSquadronEvent InvokeEvent(JoinedSquadronEvent arg) { JoinedSquadron?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when player kicked from squadron
        /// </summary>
        public event EventHandler<KickedFromSquadronEvent> KickedFromSquadron;
        internal KickedFromSquadronEvent InvokeEvent(KickedFromSquadronEvent arg) { KickedFromSquadron?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when player kicked from squadron
        /// </summary>
        public event EventHandler<LeftSquadronEvent> LeftSquadron;
        internal LeftSquadronEvent InvokeEvent(LeftSquadronEvent arg) { LeftSquadron?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when player shared bookmark with squadron members
        /// </summary>
        public event EventHandler<SharedBookmarkToSquadronEvent> SharedBookmarkToSquadron;
        internal SharedBookmarkToSquadronEvent InvokeEvent(SharedBookmarkToSquadronEvent arg) { SharedBookmarkToSquadron?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when squadron created
        /// </summary>
        public event EventHandler<SquadronCreatedEvent> SquadronCreated;
        internal SquadronCreatedEvent InvokeEvent(SquadronCreatedEvent arg) { SquadronCreated?.Invoke(this, arg); return arg; }
        /// <summary>
        /// on squadron demotion player rank
        /// </summary>
        public event EventHandler<SquadronDemotionEvent> SquadronDemotion;
        internal SquadronDemotionEvent InvokeEvent(SquadronDemotionEvent arg) { SquadronDemotion?.Invoke(this, arg); return arg; }
        /// <summary>
        /// on squadron promotion player rank
        /// </summary>
        public event EventHandler<SquadronPromotionEvent> SquadronPromotion;
        internal SquadronPromotionEvent InvokeEvent(SquadronPromotionEvent arg) { SquadronPromotion?.Invoke(this, arg); return arg; }
        /// <summary>
        /// on squadron startup
        /// </summary>
        public event EventHandler<SquadronStartupEvent> SquadronStartup;
        internal SquadronStartupEvent InvokeEvent(SquadronStartupEvent arg) { SquadronStartup?.Invoke(this, arg); return arg; }
        /// <summary>
        /// on squadron demotion
        /// </summary>
        public event EventHandler<WonATrophyForSquadronEvent> WonATrophyForSquadron;
        internal WonATrophyForSquadronEvent InvokeEvent(WonATrophyForSquadronEvent arg) { WonATrophyForSquadron?.Invoke(this, arg); return arg; }
    }
}