using System;
using NSW.EliteDangerous.API.Events;

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
        internal AppliedToSquadronEvent InvokeEvent(AppliedToSquadronEvent arg) { if(_api.ValidateEvent(arg)) AppliedToSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when squadron disbanded
        /// </summary>
        public event EventHandler<DisbandedSquadronEvent> DisbandedSquadron;
        internal DisbandedSquadronEvent InvokeEvent(DisbandedSquadronEvent arg) { if(_api.ValidateEvent(arg)) DisbandedSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player was invited to squadron
        /// </summary>
        public event EventHandler<InvitedToSquadronEvent> InvitedToSquadron;
        internal InvitedToSquadronEvent InvokeEvent(InvitedToSquadronEvent arg) { if(_api.ValidateEvent(arg)) InvitedToSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player joined squadron
        /// </summary>
        public event EventHandler<JoinedSquadronEvent> JoinedSquadron;
        internal JoinedSquadronEvent InvokeEvent(JoinedSquadronEvent arg) { if(_api.ValidateEvent(arg)) JoinedSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player kicked from squadron
        /// </summary>
        public event EventHandler<KickedFromSquadronEvent> KickedFromSquadron;
        internal KickedFromSquadronEvent InvokeEvent(KickedFromSquadronEvent arg) { if(_api.ValidateEvent(arg)) KickedFromSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player kicked from squadron
        /// </summary>
        public event EventHandler<LeftSquadronEvent> LeftSquadron;
        internal LeftSquadronEvent InvokeEvent(LeftSquadronEvent arg) { if(_api.ValidateEvent(arg)) LeftSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when player shared bookmark with squadron members
        /// </summary>
        public event EventHandler<SharedBookmarkToSquadronEvent> SharedBookmarkToSquadron;
        internal SharedBookmarkToSquadronEvent InvokeEvent(SharedBookmarkToSquadronEvent arg) { if(_api.ValidateEvent(arg)) SharedBookmarkToSquadron?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when squadron created
        /// </summary>
        public event EventHandler<SquadronCreatedEvent> SquadronCreated;
        internal SquadronCreatedEvent InvokeEvent(SquadronCreatedEvent arg) { if(_api.ValidateEvent(arg)) SquadronCreated?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron demotion player rank
        /// </summary>
        public event EventHandler<SquadronDemotionEvent> SquadronDemotion;
        internal SquadronDemotionEvent InvokeEvent(SquadronDemotionEvent arg) { if(_api.ValidateEvent(arg)) SquadronDemotion?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron promotion player rank
        /// </summary>
        public event EventHandler<SquadronPromotionEvent> SquadronPromotion;
        internal SquadronPromotionEvent InvokeEvent(SquadronPromotionEvent arg) { if(_api.ValidateEvent(arg)) SquadronPromotion?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron startup
        /// </summary>
        public event EventHandler<SquadronStartupEvent> SquadronStartup;
        internal SquadronStartupEvent InvokeEvent(SquadronStartupEvent arg) { if(_api.ValidateEvent(arg)) SquadronStartup?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// on squadron demotion
        /// </summary>
        public event EventHandler<WonATrophyForSquadronEvent> WonATrophyForSquadron;
        internal WonATrophyForSquadronEvent InvokeEvent(WonATrophyForSquadronEvent arg) { if(_api.ValidateEvent(arg)) WonATrophyForSquadron?.Invoke(_api, arg); return arg; }
    }
}