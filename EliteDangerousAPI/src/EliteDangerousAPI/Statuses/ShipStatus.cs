using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace NSW.EliteDangerous.API.Statuses
{
    public class ShipStatus
    {
        private readonly object _lock = new object();

        internal ShipStatusFlags Flags { get; private set; }

        public long ShipId { get; private set; }
        public string ShipType { get; private set; }
        public string Name { get; private set; }
        public string Identifier { get; private set; }
        public Fuel Fuel { get; private set; } = new Fuel();
        public CargoInfo Cargo { get; private set; } = new CargoInfo();
        public EnergyManagement EnergyManagement { get; private set; } = new EnergyManagement(new byte[]{4,4,4});
        public VehicleType CurrentVehicle { get; private set; } = VehicleType.Ship;
        public byte FireGroup { get; private set; }
        public ShipSystems Systems => new ShipSystems(Flags);
        public HullInfo Hull { get; private set; } = new HullInfo();
        public FsdStatus FSD => new FsdStatus(Flags);
        public SrvStatus SRV => new SrvStatus(Flags);
        public double MaxJumpRange { get; private set; }


        public bool Docked => GetFlag(Flags,0);
        public bool Landed => GetFlag(Flags,1);
        public bool InWing => GetFlag(Flags,7);
        public bool LowFuel => GetFlag(Flags,19);
        public bool Overheating => GetFlag(Flags,20);
        public bool HasLatLong => GetFlag(Flags,21);
        public bool InDanger => GetFlag(Flags,22);
        public bool Interdicted => GetFlag(Flags,23);
        public bool HighAltitudeMode => GetFlag(Flags,29);
        public bool IsHot { get; private set; }
        public long? Rebuy { get; private set; }

        internal ShipStatus(EliteDangerousAPI api)
        {
            api.GameEvents.LoadGame += (s, e) =>
            {
                lock (_lock)
                {
                    ShipId = e.ShipId;
                    ShipType = e.ShipLocalised ?? e.Ship;
                    Name = e.ShipName;
                    Identifier = e.ShipIdent;
                    Fuel.Main = e.FuelLevel;
                    Fuel.Max = e.FuelCapacity;

                    api.InvokeShipStatusChanged(this);
                }
            };

            api.GameEvents.Status += (s, e) =>
            {
                lock (_lock)
                {
                    Flags = e.Flags;
                    Fuel = e.Fuel ?? Fuel;
                    EnergyManagement = new EnergyManagement(e.Pips);
                    FireGroup = e.FireGroup;
                    Cargo.Current = e.Cargo;

                    if (GetFlag(Flags, 25)) CurrentVehicle = VehicleType.Fighter;
                    else if (GetFlag(Flags, 26)) CurrentVehicle = VehicleType.SRV;
                    else CurrentVehicle = VehicleType.Ship;

                    api.InvokeShipStatusChanged(this);
                }
            };

            api.ShipEvents.VehicleSwitch += (s, e) =>
            {
                lock (_lock)
                {
                    if (CurrentVehicle != e.To)
                    {
                        CurrentVehicle = e.To;
                        api.InvokeShipStatusChanged(this);
                    }
                }
            };

            api.StationEvents.SetUserShipName += (s, e) =>
            {
                lock (_lock)
                {
                    Name = e.UserShipName;
                    Identifier = e.UserShipId;

                    api.InvokeShipStatusChanged(this);
                }
            };

            api.StationEvents.ShipyardNew += (s, e) =>
            {
                lock (_lock)
                {
                    ShipId = e.NewShipId;
                    ShipType = e.ShipTypeLocalised ?? e.ShipType;
                    Name = ShipType;
                    Identifier = string.Empty;

                    api.InvokeShipStatusChanged(this);
                }
            };

            api.StationEvents.ShipyardSwap += (s, e) =>
            {
                lock (_lock)
                {
                    ShipId = e.ShipId;
                    ShipType = e.ShipTypeLocalised ?? e.ShipType;
                    Name = ShipType;
                    Identifier = string.Empty;

                    api.InvokeShipStatusChanged(this);
                }
            };

            api.StationEvents.ShipyardBuy += (s, e) =>
            {
                lock (_lock)
                {
                    ShipId = 0;
                    ShipType = e.ShipTypeLocalised ?? e.ShipType;
                    Name = ShipType;
                    Identifier = string.Empty;

                    api.InvokeShipStatusChanged(this);
                }
            };

            api.ShipEvents.Loadout += (s, e) =>
            {
                lock (_lock)
                {
                    ShipId = e.ShipId;
                    ShipType = e.Ship;
                    Name = e.ShipName;
                    Identifier = e.ShipIdent;
                    if (e.FuelCapacity != null)
                    {
                        Fuel.Main = e.FuelCapacity.Main;
                        Fuel.Reservoir = e.FuelCapacity.Reserve;
                    }

                    Cargo.Max = e.CargoCapacity;
                    IsHot = e.Hot ?? false;

                    Hull.Value = e.HullValue;
                    Hull.Health = (byte)Math.Round(e.HullHealth * 100);
                    Hull.UnladenMass = e.UnladenMass;
                    Hull.ModulesValue = e.ModulesValue;
                    Hull.Modules = e.Modules;
                    MaxJumpRange = e.MaxJumpRange;
                    Rebuy = e.Rebuy;

                    api.InvokeShipStatusChanged(this);
                }
            };
        }

        public struct ShipSystems
        {
            private readonly ShipStatusFlags _flags;

            public bool GearDown => GetFlag(_flags, 2);
            public bool ShieldsUp => GetFlag(_flags,3);
            public bool FlightAssistOn => GetFlag(_flags,5);
            public bool HardpointsDeployed => GetFlag(_flags,6);
            public bool LightsOn => GetFlag(_flags,8);
            public bool CargoScoopDeployed => GetFlag(_flags,9);
            public bool NightVisionOn => GetFlag(_flags,28);
            public bool SilentMode => GetFlag(_flags,10);
            public bool ScoopingFuel => GetFlag(_flags,11);
            public bool AnalysisMode => GetFlag(_flags,27);

            internal ShipSystems(ShipStatusFlags flags)
            {
                _flags = flags;
            }
        }

        public struct FsdStatus
        {
            private readonly ShipStatusFlags _flags;

            public bool MassLocked => GetFlag(_flags,16);
            public bool Charging => GetFlag(_flags,17);
            public bool Cooldown => GetFlag(_flags,18);
            public bool InHyperJump => GetFlag(_flags,30);
            public bool InSupercruise => GetFlag(_flags,4);

            internal FsdStatus(ShipStatusFlags flags)
            {
                _flags = flags;
            }
        }

        public struct SrvStatus
        {
            private readonly ShipStatusFlags _flags;

            public bool HandbreakOn => GetFlag(_flags,12);
            public bool TurrentInUse => GetFlag(_flags,13);
            public bool TurrentRetracted => GetFlag(_flags,14);
            public bool DriveAssistOn => GetFlag(_flags,15);
            public bool HighBeam => GetFlag(_flags,31);

            internal SrvStatus(ShipStatusFlags flags)
            {
                _flags = flags;
            }
        }

        public class CargoInfo
        {
            public long Max { get; internal set; }
            public double Current { get; internal set; }

            internal CargoInfo(){}
        }

        public class HullInfo
        {
            public byte Health { get; internal set; }
            public long Value { get; internal set; }
            public long ModulesValue { get; internal set; }
            public double UnladenMass { get; internal set; }
            public IEnumerable<Module> Modules { get; internal set; }

            internal HullInfo() { }
        }

        public static bool GetFlag(ShipStatusFlags flags, int bit) => flags.HasFlag((ShipStatusFlags)(1 << bit));
    }

    public class EnergyManagement
    {
        public byte Systems { get; }
        public byte Engines { get; }
        public byte Weapons { get; }

        internal EnergyManagement(IReadOnlyList<byte> pips)
        {
            if (pips != null && pips.Count==3)
            {
                Systems = pips[0];
                Engines = pips[1];
                Weapons = pips[2];
            }
            else
            {
                Systems = 4;
                Engines = 4;
                Weapons = 4;
            }
        }
    }

}