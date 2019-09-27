using System;

namespace NSW.EliteDangerous.API.Statuses
{
    public class ShipStatus
    {
        internal ShipStatusFlags Flags { get; private set; }

        public long ShipId { get; private set; }
        public string ShipType { get; private set; }
        public string Name { get; private set; }
        public string Identifier { get; private set; }
        public Fuel Fuel { get; private set; } = new Fuel();
        public byte[] Pips { get; private set; } = { 4, 4, 4 };

        public VehicleType CurrentVehicle { get; private set; } = VehicleType.Ship;

        public byte FireGroup { get; private set; }

        public int Cargo { get; private set; }

        public bool Docked => GetFlag(0);
        public bool Landed => GetFlag(1);
        public bool GearDown => GetFlag(2);
        public bool ShieldsUp => GetFlag(3);
        public bool InSupercruise => GetFlag(4);
        public bool FlightAssistOff => !GetFlag(5);
        public bool HardpointsDeployed => GetFlag(6);
        public bool InWing => GetFlag(7);
        public bool LightsOn => GetFlag(8);
        public bool CargoScoopDeployed => GetFlag(9);
        public bool SilentRunning => GetFlag(10);
        public bool ScoopingFuel => GetFlag(11);
        public bool SrvHandbreak => GetFlag(12);
        public bool SrvTurrentInUse => GetFlag(13);
        public bool SrvTurrentRetracted => GetFlag(14);
        public bool SrvDriveAssist => GetFlag(15);
        public bool FsdMassLocked => GetFlag(16);
        public bool FsdCharging => GetFlag(17);
        public bool FsdCooldown => GetFlag(18);
        public bool LowFuel => GetFlag(19);
        public bool Overheating => GetFlag(20);
        public bool HasLatLong => GetFlag(21);
        public bool InDanger => GetFlag(22);
        public bool Interdicted => GetFlag(23);
        public bool AnalysisMode => GetFlag(27);
        public bool NightVision => GetFlag(28);
        public bool HighAltitudeMode => GetFlag(29);
        public bool FsdJump => GetFlag(30);
        public bool SrvHighBeam => GetFlag(31);

        internal ShipStatus(API.EliteDangerousAPI api)
        {
            api.GameEvents.LoadGame += (s, e) =>
            {
                ShipId = e.ShipId;
                ShipType = e.ShipLocalised ?? e.Ship;
                Name = e.ShipName;
                Identifier = e.ShipIdent;
                Fuel.FuelMain = e.FuelLevel;
                Fuel.MaxFuel = e.FuelCapacity;

                api.InvokeShipStatusChanged(this);
            };

            api.GameEvents.Status += (s, e) =>
            {
                Flags = e.Flags;
                Fuel = e.Fuel ?? Fuel;
                Pips = e.Pips ?? Pips;
                FireGroup = e.FireGroup;
                Cargo = e.Cargo;

                if (GetFlag(25)) CurrentVehicle = VehicleType.Fighter;
                else if (GetFlag(26)) CurrentVehicle = VehicleType.SRV;
                else CurrentVehicle = VehicleType.Ship;

                api.InvokeShipStatusChanged(this);
            };

            api.ShipEvents.VehicleSwitch += (s, e) =>
            {
                if (CurrentVehicle != e.To)
                {
                    CurrentVehicle = e.To;
                    api.InvokeShipStatusChanged(this);
                }
            };

            api.StationEvents.SetUserShipName += (s, e) =>
            {
                Name = e.UserShipName;
                Identifier = e.UserShipId;

                api.InvokeShipStatusChanged(this);
            };

            api.StationEvents.ShipyardNew += (s, e) =>
            {
                ShipId = e.NewShipId;
                ShipType = e.ShipTypeLocalised ?? e.ShipType;
                Name = ShipType;
                Identifier = string.Empty;
            };

            api.StationEvents.ShipyardSwap += (s, e) =>
            {
                ShipId = e.ShipId;
                ShipType = e.ShipTypeLocalised ?? e.ShipType;
                Name = ShipType;
                Identifier = string.Empty;
            };
        }

        private bool GetFlag(int bit) => Flags.HasFlag((ShipStatusFlags)(1 << bit));

    }
}