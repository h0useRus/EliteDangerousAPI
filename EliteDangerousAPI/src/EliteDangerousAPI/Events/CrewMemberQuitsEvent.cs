using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class CrewMemberQuitsEvent : CrewEvent
    {
        internal static CrewMemberQuitsEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<CrewMemberQuitsEvent>(json));
    }
}