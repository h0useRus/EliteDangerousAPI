using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Handlers
{
    public class CrewHandler
    {
        private readonly EliteDangerousAPI _api;
        internal CrewHandler(EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// when changing the task assignment of a member of crew
        /// </summary>
        public event EventHandler<CrewAssignEvent> CrewAssign;
        internal CrewAssignEvent InvokeEvent(CrewAssignEvent arg) { CrewAssign?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when dismissing a member of crew
        /// </summary>
        public event EventHandler<CrewFireEvent> CrewFire;
        internal CrewFireEvent InvokeEvent(CrewFireEvent arg) { CrewFire?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when engaging a new member of crew 
        /// </summary>
        public event EventHandler<CrewHireEvent> CrewHire;
        internal CrewHireEvent InvokeEvent(CrewHireEvent arg) { CrewHire?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when in a crew on someone else's ship, player switched crew role 
        /// </summary>
        public event EventHandler<ChangeCrewRoleEvent> ChangeCrewRole;
        internal ChangeCrewRoleEvent InvokeEvent(ChangeCrewRoleEvent arg) { ChangeCrewRole?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when in multicrew, in Helm player's log, when a crew member launches a fighter
        /// </summary>
        public event EventHandler<CrewLaunchFighterEvent> CrewLaunchFighter;
        internal CrewLaunchFighterEvent InvokeEvent(CrewLaunchFighterEvent arg) { CrewLaunchFighter?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When another player joins your ship's crew 
        /// </summary>
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoins;
        internal CrewMemberJoinsEvent InvokeEvent(CrewMemberJoinsEvent arg) { CrewMemberJoins?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When another player leaves your ship's crew 
        /// </summary>
        public event EventHandler<CrewMemberQuitsEvent> CrewMemberQuits;
        internal CrewMemberQuitsEvent InvokeEvent(CrewMemberQuitsEvent arg) { CrewMemberQuits?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  in Multicrew, Helm's log, when another crew player changes role 
        /// </summary>
        public event EventHandler<CrewMemberRoleChangeEvent> CrewMemberRoleChange;
        internal CrewMemberRoleChangeEvent InvokeEvent(CrewMemberRoleChangeEvent arg) { CrewMemberRoleChange?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When you join another player ship's crew  
        /// </summary>
        public event EventHandler<JoinACrewEvent> JoinACrew;
        internal JoinACrewEvent InvokeEvent(JoinACrewEvent arg) { JoinACrew?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  in Multicrew, Helm's log, when another crew player changes role 
        /// </summary>
        public event EventHandler<KickCrewMemberEvent> KickCrewMember;
        internal KickCrewMemberEvent InvokeEvent(KickCrewMemberEvent arg) { KickCrewMember?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  When you leave another player ship's crew  
        /// </summary>
        public event EventHandler<QuitACrewEvent> QuitACrew;
        internal QuitACrewEvent InvokeEvent(QuitACrewEvent arg) { QuitACrew?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  in Multicrew, Helm's log, when another crew player changes role 
        /// </summary>
        public event EventHandler<EndCrewSessionEvent> EndCrewSession;
        internal EndCrewSessionEvent InvokeEvent(EndCrewSessionEvent arg) { EndCrewSession?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// This is written when crew receive wages 
        /// </summary>
        public event EventHandler<NpcCrewPaidWageEvent> NpcCrewPaidWage;
        internal NpcCrewPaidWageEvent InvokeEvent(NpcCrewPaidWageEvent arg) { NpcCrewPaidWage?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// This is written when a crew member's combat rank increases  
        /// </summary>
        public event EventHandler<NpcCrewRankEvent> NpcCrewRank;
        internal NpcCrewRankEvent InvokeEvent(NpcCrewRankEvent arg) { NpcCrewRank?.Invoke(_api, arg); return arg; }
    }
}