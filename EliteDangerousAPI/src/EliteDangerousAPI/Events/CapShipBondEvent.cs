namespace NSW.EliteDangerous.Events
{
    public class CapShipBondEvent : FactionKillBondEvent
    {
        internal new static CapShipBondEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<CapShipBondEvent>(json));
    }
}