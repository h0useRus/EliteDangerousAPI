using System;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Statuses
{
    public class LocationStatus
    {
        public StarSystem StarSystem { get; private set; }
        public SpaceBody Body { get; private set; }
        public Station Station { get; private set; }


        internal LocationStatus(EliteDangerousAPI api)
        {
            api.Travel.Location += (s, e) =>
            {
                if (StarSystem == null || !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                    StarSystem = new StarSystem(e.StarSystem);

                StarSystem.Security = e.SystemSecurityLocalised ?? e.SystemSecurity ?? StarSystem.Security;
                StarSystem.Government = e.SystemGovernmentLocalised ?? e.SystemGovernment ?? StarSystem.Government;
                StarSystem.Economy = e.SystemEconomyLocalised ?? e.SystemEconomy ?? StarSystem.Economy;
                StarSystem.SecondEconomy = e.SystemSecondEconomyLocalised ?? e.SystemSecondEconomy ?? StarSystem.SecondEconomy;
                StarSystem.Faction = e.SystemFaction ?? StarSystem.Faction;
                StarSystem.Population = e.Population;

                Body = new SpaceBody(e.BodyType ?? BodyType.Null, e.Body);

                if (Body.Type == BodyType.Station)
                {
                    if (Station == null || !string.Equals(Station?.Name, e.StationName, StringComparison.OrdinalIgnoreCase))
                        Station = new Station(e.StationName ?? e.Body, e.StationType);
                    Station.Faction = e.StationFaction ?? Station.Faction;
                    Station.Economy = e.StationEconomyLocalised ?? e.StationEconomy ?? Station.Economy;
                    Station.Government = e.StationGovernmentLocalised ?? e.StationGovernment ?? Station.Government;
                    Station.MarketId = e.MarketId ?? Station.MarketId;
                }
                else
                {
                    Station = null;
                }

                api.InvokeLocationStatusChanged(this);
            };

            api.Travel.ApproachBody += (s, e) =>
            {
                if (StarSystem == null || !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                {
                    StarSystem = new StarSystem(e.StarSystem);
                }
                Body = new SpaceBody(BodyType.Planet, e.Body ?? string.Empty);
                Station = null;

                api.InvokeLocationStatusChanged(this);
            };

            api.Travel.ApproachSettlement += (s, e) =>
            {
                Body = new SpaceBody(BodyType.Planet, e.BodyName);
                Station = new Station(e.NameLocalised ?? e.Name, "Settlement") { MarketId = e.MarketId };
                                     
                api.InvokeLocationStatusChanged(this);
            };

            api.Travel.LeaveBody += (s, e) =>
            {
                if (StarSystem == null || !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                {
                    StarSystem = new StarSystem(e.StarSystem);
                }
                Body = new SpaceBody(BodyType.Planet, e.Body ?? string.Empty);
                Station = null;
                                                      
                api.InvokeLocationStatusChanged(this);
            };

            api.Travel.Docked += (s, e) =>
            {
                if (StarSystem == null || !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                    StarSystem = new StarSystem(e.StarSystem);

                Body = new SpaceBody(BodyType.Station, e.StationName ?? string.Empty);

                if (Station == null || !string.Equals(Station?.Name, e.StationName, StringComparison.OrdinalIgnoreCase))
                    Station = new Station(e.StationName, e.StationType);

                Station.Economy = e.StationEconomyLocalised ?? e.StationEconomy ?? Station.Economy;
                Station.Government = e.StationGovernmentLocalised ?? e.StationGovernment ?? Station.Government;
                Station.Faction = e.StationFaction ?? Station.Faction;
                Station.MarketId = e.MarketId;

                api.InvokeLocationStatusChanged(this);
            };

            api.Travel.DockingRequested += (s, e) =>
            {
                if (Station == null || !string.Equals(Station?.Name, e.StationName, StringComparison.OrdinalIgnoreCase))
                    Station = new Station(e.StationName, e.StationType);
                Station.MarketId = e.MarketId;

                api.InvokeLocationStatusChanged(this);
            };

            api.Travel.FsdJump += (s, e) =>
            {
                if (StarSystem == null || !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                    StarSystem = new StarSystem(e.StarSystem);

                StarSystem.Security = e.SystemSecurityLocalised ?? e.SystemSecurity ?? StarSystem.Security;
                StarSystem.Government = e.SystemGovernmentLocalised ?? e.SystemGovernment ?? StarSystem.Government;
                StarSystem.Economy = e.SystemEconomyLocalised ?? e.SystemEconomy ?? StarSystem.Economy;
                StarSystem.SecondEconomy = e.SystemSecondEconomyLocalised ?? e.SystemSecondEconomy ?? StarSystem.SecondEconomy;
                StarSystem.Faction = e.SystemFaction ?? StarSystem.Faction;
                StarSystem.Population = e.Population;

                Body = new SpaceBody(e.BodyType, e.Body);

                Station = null;

                api.InvokeLocationStatusChanged(this);
            };

            api.Travel.SupercruiseExit += (s, e) =>
            {
                if (StarSystem == null || !string.Equals(StarSystem?.Name, e.StarSystem, StringComparison.OrdinalIgnoreCase))
                    StarSystem = new StarSystem(e.StarSystem);

                Body = new SpaceBody(e.BodyType ?? BodyType.Null, e.Body);

                api.InvokeLocationStatusChanged(this);
            };
        }
    }

    public class StarSystem
    {
        public string Name { get; }
        public string Security { get; internal set; } = string.Empty;
        public string Economy { get; internal set; } = string.Empty;
        public string SecondEconomy { get; internal set; } = string.Empty;
        public string Government { get; internal set; } = string.Empty;
        public Faction Faction { get; internal set; }
        public long Population { get; internal set; }

        internal StarSystem(string name)
        {
            Name = name ?? string.Empty;
        }
    }

    public class SpaceBody
    {
        public BodyType Type { get; }
        public string Name { get; }

        internal SpaceBody(BodyType type, string name)
        {
            Type = type;
            Name = name ?? string.Empty;
        }
    }

    public class Station
    {
        public string Name { get; }
        public string Type { get; }
        public string Economy { get; internal set; } = string.Empty;
        public string Government { get; internal set; } = string.Empty;
        public Faction Faction { get; internal set; }
        public long MarketId { get; internal set; }

        internal Station(string name, string type)
        {
            Name = name ?? string.Empty;
            Type = type ?? "Unknown";
        }
    }
}