namespace NSW.EliteDangerous.API.Events
{
    public class CapShipBondEvent : FactionKillBondEvent
    {
        internal new static CapShipBondEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<CapShipBondEvent>(json));
    }
}