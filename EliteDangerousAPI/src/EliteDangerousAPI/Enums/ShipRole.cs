using System;

namespace NSW.EliteDangerous.API
{
    [Flags]
    public enum ShipRole
    {
        Combat    = 0,
        Explorer  = 1,
        Freighter = 1 << 1,
        Passenger = 1 << 2,
        Multipurpose = Combat | Explorer | Freighter | Passenger
    }
}