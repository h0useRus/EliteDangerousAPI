using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class CrewHandler
    {
        private readonly API.EliteDangerousAPI _api;
        internal CrewHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// when changing the task assignment of a member of crew
        /// </summary>
        public event EventHandler<CrewAssignEvent> CrewAssign;
        internal CrewAssignEvent InvokeEvent(CrewAssignEvent arg) { if(_api.ValidateEvent(arg)) CrewAssign?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when dismissing a member of crew
        /// </summary>
        public event EventHandler<CrewFireEvent> CrewFire;
        internal CrewFireEvent InvokeEvent(CrewFireEvent arg) { if(_api.ValidateEvent(arg)) CrewFire?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when engaging a new member of crew 
        /// </summary>
        public event EventHandler<CrewHireEvent> CrewHire;
        internal CrewHireEvent InvokeEvent(CrewHireEvent arg) { if(_api.ValidateEvent(arg)) CrewHire?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when in a crew on someone else's ship, player switched crew role 
        /// </summary>
        public event EventHandler<ChangeCrewRoleEvent> ChangeCrewRole;
        internal ChangeCrewRoleEvent InvokeEvent(ChangeCrewRoleEvent arg) { if(_api.ValidateEvent(arg)) ChangeCrewRole?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when in multicrew, in Helm player's log, when a crew member launches a fighter
        /// </summary>
        public event EventHandler<CrewLaunchFighterEvent> CrewLaunchFighter;
        internal CrewLaunchFighterEvent InvokeEvent(CrewLaunchFighterEvent arg) { if(_api.ValidateEvent(arg)) CrewLaunchFighter?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When another player joins your ship's crew 
        /// </summary>
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoins;
        internal CrewMemberJoinsEvent InvokeEvent(CrewMemberJoinsEvent arg) { if(_api.ValidateEvent(arg)) CrewMemberJoins?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When another player leaves your ship's crew 
        /// </summary>
        public event EventHandler<CrewMemberQuitsEvent> CrewMemberQuits;
        internal CrewMemberQuitsEvent InvokeEvent(CrewMemberQuitsEvent arg) { if(_api.ValidateEvent(arg)) CrewMemberQuits?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  in Multicrew, Helm's log, when another crew player changes role 
        /// </summary>
        public event EventHandler<CrewMemberRoleChangeEvent> CrewMemberRoleChange;
        internal CrewMemberRoleChangeEvent InvokeEvent(CrewMemberRoleChangeEvent arg) { if(_api.ValidateEvent(arg)) CrewMemberRoleChange?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When you join another player ship's crew  
        /// </summary>
        public event EventHandler<JoinACrewEvent> JoinACrew;
        internal JoinACrewEvent InvokeEvent(JoinACrewEvent arg) { if(_api.ValidateEvent(arg)) JoinACrew?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  in Multicrew, Helm's log, when another crew player changes role 
        /// </summary>
        public event EventHandler<KickCrewMemberEvent> KickCrewMember;
        internal KickCrewMemberEvent InvokeEvent(KickCrewMemberEvent arg) { if(_api.ValidateEvent(arg)) KickCrewMember?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When you leave another player ship's crew  
        /// </summary>
        public event EventHandler<QuitACrewEvent> QuitACrew;
        internal QuitACrewEvent InvokeEvent(QuitACrewEvent arg) { if(_api.ValidateEvent(arg)) QuitACrew?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  in Multicrew, Helm's log, when another crew player changes role 
        /// </summary>
        public event EventHandler<EndCrewSessionEvent> EndCrewSession;
        internal EndCrewSessionEvent InvokeEvent(EndCrewSessionEvent arg) { if(_api.ValidateEvent(arg)) EndCrewSession?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// This is written when crew receive wages 
        /// </summary>
        public event EventHandler<NpcCrewPaidWageEvent> NpcCrewPaidWage;
        internal NpcCrewPaidWageEvent InvokeEvent(NpcCrewPaidWageEvent arg) { if(_api.ValidateEvent(arg)) NpcCrewPaidWage?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// This is written when a crew member's combat rank increases  
        /// </summary>
        public event EventHandler<NpcCrewRankEvent> NpcCrewRank;
        internal NpcCrewRankEvent InvokeEvent(NpcCrewRankEvent arg) { if(_api.ValidateEvent(arg)) NpcCrewRank?.Invoke(_api, arg); return arg; }
    }
}