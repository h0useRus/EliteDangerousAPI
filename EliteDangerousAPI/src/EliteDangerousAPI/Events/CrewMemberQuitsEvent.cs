using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CrewMemberQuitsEvent : CrewEvent
    {
        internal static CrewMemberQuitsEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<CrewMemberQuitsEvent>(json));
    }
}