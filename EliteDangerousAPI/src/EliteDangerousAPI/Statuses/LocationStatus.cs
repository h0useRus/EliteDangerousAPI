using System;
using System.Linq;

namespace NSW.EliteDangerous.API.Statuses
{
    public class LocationStatus
    {
        private readonly object _lock = new object();

        public StarSystemInfo StarSystem { get; private set; }
        public SpaceBodyInfo Body { get; private set; }
        public StationInfo Station { get; private set; }
        public TravelInfo Route { get; private set; }

        internal LocationStatus(EliteDangerousAPI api)
        {
            api.TravelEvents.Location += (s, e) =>
            {
                lock (_lock)
                {
                    if (StarSystem == null ||
                        !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                        StarSystem = new StarSystemInfo(e.StarSystem);

                    StarSystem.Security = e.SystemSecurityLocalised ?? e.SystemSecurity ?? StarSystem.Security;
                    StarSystem.Government = e.SystemGovernmentType;
                    StarSystem.Economy = e.SystemEconomyType;
                    StarSystem.SecondEconomy = e.SystemSecondEconomyType;
                    StarSystem.Faction = e.SystemFaction ?? StarSystem.Faction;
                    StarSystem.Population = e.Population;

                    Body = new SpaceBodyInfo(e.BodyType ?? BodyType.Null, e.Body);

                    if (Body.Type == BodyType.Station)
                    {
                        if (Station == null || !string.Equals(Station?.Name, e.StationName,
                                StringComparison.OrdinalIgnoreCase))
                            Station = new StationInfo(e.StationName ?? e.Body, e.StationType);
                        Station.Faction = e.StationFaction ?? Station.Faction;
                        Station.Economy = e.StationEconomyType;
                        Station.Government = e.StationGovernmentType;
                        Station.MarketId = e.MarketId ?? Station.MarketId;
                    }
                    else
                    {
                        Station = null;
                    }

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.ApproachBody += (s, e) =>
            {
                lock (_lock)
                {
                    if (StarSystem == null ||
                        !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                    {
                        StarSystem = new StarSystemInfo(e.StarSystem);
                    }

                    Body = new SpaceBodyInfo(BodyType.Planet, e.Body ?? "Planet");
                    Station = null;

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.ApproachSettlement += (s, e) =>
            {
                lock (_lock)
                {
                    Body = new SpaceBodyInfo(BodyType.Planet, e.BodyName);
                    Station = new StationInfo(e.NameLocalised ?? e.Name, "Settlement") {MarketId = e.MarketId};

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.LeaveBody += (s, e) =>
            {
                lock (_lock)
                {
                    if (StarSystem == null ||
                        !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                    {
                        StarSystem = new StarSystemInfo(e.StarSystem);
                    }

                    Body = new SpaceBodyInfo(BodyType.Planet, e.Body ?? "Planet");
                    Station = null;

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.Docked += (s, e) =>
            {
                lock (_lock)
                {
                    if (StarSystem == null ||
                        !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                        StarSystem = new StarSystemInfo(e.StarSystem);

                    Body = new SpaceBodyInfo(BodyType.Station, e.StationName ?? "Station");

                    if (Station == null ||
                        !string.Equals(Station?.Name, e.StationName, StringComparison.OrdinalIgnoreCase))
                        Station = new StationInfo(e.StationName, e.StationType);

                    Station.Economy = e.StationEconomyType;
                    Station.Government = e.StationGovernmentType;
                    Station.Faction = e.StationFaction ?? Station.Faction;
                    Station.MarketId = e.MarketId;

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.DockingRequested += (s, e) =>
            {
                lock (_lock)
                {
                    if (Station == null ||
                        !string.Equals(Station?.Name, e.StationName, StringComparison.OrdinalIgnoreCase))
                        Station = new StationInfo(e.StationName, e.StationType);
                    Station.MarketId = e.MarketId;

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.FsdJump += (s, e) =>
            {
                lock (_lock)
                {
                    if (StarSystem == null || 
                        !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                        StarSystem = new StarSystemInfo(e.StarSystem);

                    if (Route != null && string.Equals(Route.DestinationSystem, StarSystem.Name))
                        Route = null;

                    StarSystem.Security = e.SystemSecurityLocalised ?? e.SystemSecurity ?? StarSystem.Security;
                    StarSystem.Government = e.SystemGovernmentType;
                    StarSystem.Economy = e.SystemEconomyType;
                    StarSystem.SecondEconomy = e.SystemSecondEconomyType;
                    StarSystem.Faction = e.SystemFaction ?? StarSystem.Faction;
                    StarSystem.Population = e.Population;

                    Body = new SpaceBodyInfo(e.BodyType, e.Body);

                    Station = null;

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.SupercruiseExit += (s, e) =>
            {
                lock (_lock)
                {
                    if (StarSystem == null ||
                        !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                        StarSystem = new StarSystemInfo(e.StarSystem);

                    Body = new SpaceBodyInfo(e.BodyType ?? BodyType.Null, e.Body);

                    api.InvokeLocationStatusChanged(this);
                }
            };

            api.TravelEvents.StartJump += (s, e) =>
            {
                lock (_lock)
                {
                    if (e.JumpType == JumpType.Hyperspace)
                    {
                        StarSystem = new StarSystemInfo(e.StarSystem) {StarClass = e.StarClass};
                        Body = null;
                        Station = null;

                        api.InvokeLocationStatusChanged(this);
                    }
                }
            };

            api.TravelEvents.FsdTarget += (s, e) =>
            {
                lock (_lock)
                {
                    Route = new TravelInfo(e.Name, e.RemainingJumpsInRoute);

                    api.InvokeLocationStatusChanged(this);
                }
            };
        }

        public class StarSystemInfo
        {
            public string Name { get; }
            public string Security { get; internal set; } = string.Empty;
            public EconomyType Economy { get; internal set; } = EconomyType.None;
            public EconomyType SecondEconomy { get; internal set; } = EconomyType.None;
            public GovernmentType Government { get; internal set; } = GovernmentType.None;
            public Faction Faction { get; internal set; }
            public long Population { get; internal set; }
            public string StarClass { get; internal set; }

            public bool PossibleFuelScoop
            {
                get
                {
                    if (!string.IsNullOrEmpty(StarClass))
                    {
                        return EliteDangerousData.FuelScoopableStars.Any(s =>
                            string.Equals(s, StarClass, StringComparison.OrdinalIgnoreCase));
                    }

                    return false;
                }
            }

            internal StarSystemInfo(string name)
            {
                Name = name ?? string.Empty;
            }

            public override string ToString() => Name;
        }

        public class SpaceBodyInfo
        {
            public BodyType Type { get; }
            public string Name { get; }

            internal SpaceBodyInfo(BodyType type, string name)
            {
                Type = type;
                Name = name ?? string.Empty;
            }

            public override string ToString() => Name;
        }

        public class StationInfo
        {
            public string Name { get; }
            public string Type { get; }
            public EconomyType Economy { get; internal set; } = EconomyType.None;
            public GovernmentType Government { get; internal set; } = GovernmentType.None;
            public Faction Faction { get; internal set; }
            public long MarketId { get; internal set; }

            internal StationInfo(string name, string type)
            {
                Name = name ?? string.Empty;
                Type = type ?? "Unknown";
            }

            public override string ToString() => Name;
        }

        public class TravelInfo
        {
            public string DestinationSystem { get; }
            public int RemainingJumps { get; }

            internal TravelInfo(string destinationSystem, int remainingJumps)
            {
                DestinationSystem = destinationSystem;
                RemainingJumps = remainingJumps;
            }
        }
    }
}