using System.Collections.Generic;

namespace NSW.EliteDangerous.API
{
    public class ShipBase
    {
        public ShipModel Model { get; }
        public int FrontierId { get; internal set; }
        public string FrontierName { get; internal set; }
        public string Name { get; internal set; }
        public ShipRole ShipRole { get; internal set; }
        public MajorFaction? Faction { get; internal set; }
        public int? Rank { get; internal set; }
        public int Class { get; internal set; }
        public int Cost { get; internal set; }
        public int Retail { get; internal set; }
        public int ThrustersSpeed { get; internal set; }
        public int BoostSpeed { get; internal set; }
        public int Manoeuvrability { get; internal set; }
        public int Shields { get; internal set; }
        public int Armour { get; internal set; }
        public int Mass { get; internal set; }
        public double ForwardAcceleration { get; internal set; }
        public double ReverseAcceleration { get; internal set; }
        public double LatitudeAcceleration { get; internal set; }
        public double MinThrust { get; internal set; }
        public int BoostCost { get; internal set; }
        public int Pitch { get; internal set; }
        public int Yaw { get; internal set; }
        public int Roll { get; internal set; }
        public int PitchAcceleration { get; internal set; }
        public int YawAcceleration { get; internal set; }
        public int RollAcceleration { get; internal set; }
        public int PitchMin { get; internal set; }
        public int YawMin { get; internal set; }
        public int RollMin { get; internal set; }
        public int HeatCap { get; internal set; }
        public double HeatDisMin { get; internal set; }
        public double HeatDisMax { get; internal set; }
        public int FuelCost { get; internal set; }
        public double FuelReserve { get; internal set; }
        public int Hardness { get; internal set; }
        public int MassLock { get; internal set; }
        public int Crew { get; internal set; }
        public SlotsConfiguration Slots { get; internal set; }

        internal ShipBase(ShipModel model)
        {
            Model = model;
        }

        public static readonly ShipBase Adder
            = new ShipBase(ShipModel.Adder)
            {
                FrontierId = 128049267,
                FrontierName = "Adder",
                ShipRole = ShipRole.Multipurpose,
                Name = "Adder",
                Class = 1,
                Cost = 18710,
                Retail = 87810,
                ThrustersSpeed = 220,
                BoostSpeed = 320,
                Manoeuvrability = 4,
                Shields = 60,
                Armour = 90,
                Mass = 35,
                ForwardAcceleration = 39.41,
                ReverseAcceleration = 27.73,
                LatitudeAcceleration = 27.86,
                MinThrust = 45.454,
                BoostCost = 8,
                Pitch = 38,
                Yaw = 14,
                Roll = 100,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 30,
                HeatCap = 170,
                HeatDisMin = 1.45,
                HeatDisMax = 22.60,
                FuelCost = 50,
                FuelReserve = 0.36,
                Hardness = 35,
                MassLock = 7,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 1, 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 3, 3, 3, 1, 2, 3, 3 },
                    Military = new byte[] { },
                    Internal = new byte[] { 3, 3, 2, 2, 1, 1, 1 },
                }
            };
        public static readonly ShipBase AllianceChallenger
            = new ShipBase(ShipModel.AllianceChallenger)
            {
                FrontierId = 128816588,
                FrontierName = "TypeX_3",
                ShipRole = ShipRole.Combat,
                Name = "Alliance Challenger",
                Class = 2,
                Cost = 29561170,
                Retail = 30472250,
                Faction = MajorFaction.Alliance,
                Rank = 0,
                ThrustersSpeed = 200,
                BoostSpeed = 310,
                Manoeuvrability = 4,
                Shields = 220,
                Armour = 300,
                Mass = 450,
                ForwardAcceleration = 31.65,
                ReverseAcceleration = 25.94,
                LatitudeAcceleration = 20.09,
                MinThrust = 65.00,
                BoostCost = 19,
                Pitch = 35,
                Yaw = 16,
                Roll = 90,
                PitchAcceleration = 120,
                YawAcceleration = 50,
                RollAcceleration = 120,
                PitchMin = 32,
                HeatCap = 316,
                HeatDisMin = 2.87,
                HeatDisMax = 51.40,
                FuelCost = 50,
                FuelReserve = 0.77,
                Hardness = 65,
                MassLock = 13,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 2, 2, 2, 1, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 6, 5, 5, 6, 4, 4 },
                    Military = new byte[] { 4, 4, 4 },
                    Internal = new byte[] { 6, 6, 3, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase AllianceChieftain
            = new ShipBase(ShipModel.AllianceChieftain)
            {
                FrontierId = 128816574,
                FrontierName = "TypeX",
                ShipRole = ShipRole.Combat,
                Name = "Alliance Chieftain",
                Class = 2,
                Cost = 18603850,
                Retail = 19382250,
                Faction = MajorFaction.Alliance,
                Rank = 0,
                ThrustersSpeed = 230,
                BoostSpeed = 330,
                Manoeuvrability = 4,
                Shields = 200,
                Armour = 280,
                Mass = 400,
                ForwardAcceleration = 37.84,
                ReverseAcceleration = 25.84,
                LatitudeAcceleration = 20.01,
                MinThrust = 65.217,
                BoostCost = 19,
                Pitch = 38,
                Yaw = 16,
                Roll = 90,
                PitchAcceleration = 170,
                YawAcceleration = 60,
                RollAcceleration = 150,
                PitchMin = 32,
                HeatCap = 289,
                HeatDisMin = 2.60,
                HeatDisMax = 46.50,
                FuelCost = 50,
                FuelReserve = 0.77,
                Hardness = 65,
                MassLock = 13,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3, 2, 1, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 6, 5, 5, 6, 4, 4 },
                    Military = new byte[] { 4, 4, 4 },
                    Internal = new byte[] { 6, 5, 4, 2, 2, 1 }
                }
            };
        public static readonly ShipBase AllianceCrusader
            = new ShipBase(ShipModel.AllianceCrusader)
            {
                FrontierId = 128816581,
                FrontierName = "TypeX_2",
                ShipRole = ShipRole.Combat,
                Name = "Alliance Crusader",
                Class = 2,
                Cost = 22087940,
                Retail = 22866340,
                Faction = MajorFaction.Alliance,
                Rank = 0,
                ThrustersSpeed = 180,
                BoostSpeed = 300,
                Manoeuvrability = 3,
                Shields = 200,
                Armour = 300,
                Mass = 500,
                ForwardAcceleration = 29.78,
                ReverseAcceleration = 24.78,
                LatitudeAcceleration = 18.96,
                MinThrust = 61.11,
                BoostCost = 19,
                Pitch = 32,
                Yaw = 16,
                Roll = 80,
                PitchAcceleration = 150,
                YawAcceleration = 50,
                RollAcceleration = 150,
                PitchMin = 30,
                HeatCap = 316,
                HeatDisMin = 2.53,
                HeatDisMax = 45.23,
                FuelCost = 50,
                FuelReserve = 0.77,
                Hardness = 65,
                MassLock = 13,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 2, 2, 1, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 6, 5, 5, 6, 4, 4 },
                    Military = new byte[] { 4, 4, 4 },
                    Internal = new byte[] { 6, 5, 3, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase Anaconda
            = new ShipBase(ShipModel.Anaconda)
            {
                FrontierId = 128049363,
                FrontierName = "Anaconda",
                ShipRole = ShipRole.Multipurpose,
                Name = "Anaconda",
                Class = 3,
                Cost = 142447820,
                Retail = 146969450,
                ThrustersSpeed = 180,
                BoostSpeed = 240,
                Manoeuvrability = 1,
                Shields = 350,
                Armour = 525,
                Mass = 400,
                ForwardAcceleration = 19.85,
                ReverseAcceleration = 10.03,
                LatitudeAcceleration = 10.05,
                MinThrust = 44.444,
                BoostCost = 27,
                Pitch = 25,
                Yaw = 10,
                Roll = 60,
                PitchAcceleration = 100,
                YawAcceleration = 50,
                RollAcceleration = 80,
                PitchMin = 20,
                HeatCap = 334,
                HeatDisMin = 3.16,
                HeatDisMax = 67.15,
                FuelCost = 50,
                FuelReserve = 1.07,
                Hardness = 65,
                MassLock = 23,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 4, 3, 3, 3, 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Component = new byte[] { 1, 8, 7, 6, 5, 8, 8, 5 },
                    Military = new byte[] { 5 },
                    Internal = new byte[] { 7, 6, 6, 6, 5, 5, 5, 4, 4, 4, 2, 1 }
                }
            };
        public static readonly ShipBase AspExplorer
            = new ShipBase(ShipModel.AspExplorer)
            {
                FrontierId = 128049303,
                FrontierName = "Asp",
                ShipRole = ShipRole.Multipurpose,
                Name = "Asp Explorer",
                Class = 2,
                Cost = 6137180,
                Retail = 6661160,
                ThrustersSpeed = 250,
                BoostSpeed = 340,
                Manoeuvrability = 4,
                Shields = 140,
                Armour = 210,
                Mass = 280,
                ForwardAcceleration = 23.64,
                ReverseAcceleration = 15.04,
                LatitudeAcceleration = 14.97,
                MinThrust = 48.0,
                BoostCost = 13,
                Pitch = 38,
                Yaw = 10,
                Roll = 100,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 30,
                HeatCap = 272,
                HeatDisMin = 2.34,
                HeatDisMax = 39.90,
                FuelCost = 50,
                FuelReserve = 0.63,
                Hardness = 52,
                MassLock = 11,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 5, 5, 5, 4, 4, 5, 5 },
                    Military = new byte[] { 5 },
                    Internal = new byte[] { 6, 5, 3, 3, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase AspScout
            = new ShipBase(ShipModel.AspScout)
            {
                FrontierId = 128672276,
                FrontierName = "Asp_Scout",
                ShipRole = ShipRole.Explorer | ShipRole.Combat,
                Name = "Asp Scout",
                Class = 2,
                Cost = 3811220,
                Retail = 3961160,
                ThrustersSpeed = 220,
                BoostSpeed = 300,
                Manoeuvrability = 5,
                Shields = 120,
                Armour = 180,
                Mass = 150,
                ForwardAcceleration = 35.02,
                ReverseAcceleration = 20.10,
                LatitudeAcceleration = 20.03,
                MinThrust = 50.0,
                BoostCost = 13,
                Pitch = 40,
                Yaw = 15,
                Roll = 110,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 35,
                HeatCap = 210,
                HeatDisMin = 1.80,
                HeatDisMax = 29.65,
                FuelCost = 50,
                FuelReserve = 0.47,
                Hardness = 52,
                MassLock = 8,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 4, 4, 4, 3, 4, 4, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 5, 4, 3, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase BelugaLiner
            = new ShipBase(ShipModel.BelugaLiner)
            {
                FrontierId = 128049345,
                FrontierName = "BelugaLiner",
                ShipRole = ShipRole.Passenger,
                Name = "Beluga Liner",
                Class = 3,
                Cost = 79686090,
                Retail = 84532760,
                ThrustersSpeed = 200,
                BoostSpeed = 280,
                Manoeuvrability = 2,
                Shields = 280,
                Armour = 280,
                Mass = 950,
                ForwardAcceleration = 20.01,
                ReverseAcceleration = 17.12,
                LatitudeAcceleration = 15.03,
                MinThrust = 55.0,
                BoostCost = 19,
                Pitch = 25,
                Yaw = 17,
                Roll = 60,
                PitchAcceleration = 100,
                YawAcceleration = 50,
                RollAcceleration = 80,
                PitchMin = 20,
                HeatCap = 283,
                HeatDisMin = 2.60,
                HeatDisMax = 50.85,
                FuelCost = 50,
                FuelReserve = 0.81,
                Hardness = 60,
                MassLock = 18,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 2, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 7, 7, 8, 6, 5, 7 },
                    Military = new byte[] { },
                    Internal = new byte[] { 6, 6, 6, 6, 5, 5, 4, 3, 3, 3, 3, 1 }
                }
            };
        public static readonly ShipBase CobraMkIII
            = new ShipBase(ShipModel.CobraMkIII)
            {
                FrontierId = 128049273,
                FrontierName = "CobraMkIII",
                ShipRole = ShipRole.Multipurpose,
                Name = "Cobra Mk III",
                Class = 1,
                Cost = 186260,
                Retail = 349720,
                ThrustersSpeed = 280,
                BoostSpeed = 400,
                Manoeuvrability = 5,
                Shields = 80,
                Armour = 120,
                Mass = 180,
                ForwardAcceleration = 35.03,
                ReverseAcceleration = 25.16,
                LatitudeAcceleration = 20.02,
                MinThrust = 50.0,
                BoostCost = 10,
                Pitch = 40,
                Yaw = 10,
                Roll = 100,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 30,
                HeatCap = 225,
                HeatDisMin = 1.92,
                HeatDisMax = 30.63,
                FuelCost = 50,
                FuelReserve = 0.49,
                Hardness = 35,
                MassLock = 8,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 4, 4, 4, 3, 3, 3, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 4, 4, 4, 2, 2, 2, 1, 1 }
                }
            };
        public static readonly ShipBase CobraMkIV
            = new ShipBase(ShipModel.CobraMkIV)
            {
                FrontierId = 128672262,
                FrontierName = "CobraMkIV",
                ShipRole = ShipRole.Multipurpose,
                Name = "Cobra Mk IV",
                Class = 1,
                Cost = 584200,
                Retail = 764720,
                ThrustersSpeed = 200,
                BoostSpeed = 300,
                Manoeuvrability = 3,
                Shields = 120,
                Armour = 120,
                Mass = 210,
                ForwardAcceleration = 27.84,
                ReverseAcceleration = 19.91,
                LatitudeAcceleration = 15.03,
                MinThrust = 50.0,
                BoostCost = 10,
                Pitch = 30,
                Yaw = 10,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 25,
                HeatCap = 228,
                HeatDisMin = 1.99,
                HeatDisMax = 31.68,
                FuelCost = 50,
                FuelReserve = 0.51,
                Hardness = 35,
                MassLock = 8,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1, 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 4, 4, 4, 3, 3, 3, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 4, 4, 4, 4, 3, 3, 2, 2, 1, 1 }
                }
            };
        public static readonly ShipBase DiamondbackExplorer
            = new ShipBase(ShipModel.DiamondbackExplorer)
            {
                FrontierId = 128671831,
                FrontierName = "DiamondBackXL",
                ShipRole = ShipRole.Explorer | ShipRole.Combat,
                Name = "Diamondback Explorer",
                Class = 1,
                Cost = 1616160,
                Retail = 1894760,
                ThrustersSpeed = 260,
                BoostSpeed = 340,
                Manoeuvrability = 4,
                Shields = 150,
                Armour = 150,
                Mass = 260,
                ForwardAcceleration = 34.63,
                ReverseAcceleration = 25.06,
                LatitudeAcceleration = 19.89,
                MinThrust = 61.538,
                BoostCost = 13,
                Pitch = 35,
                Yaw = 13,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 28,
                HeatCap = 351,
                HeatDisMin = 2.46,
                HeatDisMax = 50.55,
                FuelCost = 50,
                FuelReserve = 0.52,
                Hardness = 42,
                MassLock = 10,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 4, 4, 5, 3, 4, 3, 5 },
                    Military = new byte[] { },
                    Internal = new byte[] { 5, 4, 4, 3, 2, 2, 2, 1, 1 }
                }
            };
        public static readonly ShipBase DiamondbackScout
            = new ShipBase(ShipModel.DiamondbackScout)
            {
                FrontierId = 128671217,
                FrontierName = "DiamondBack",
                ShipRole = ShipRole.Explorer | ShipRole.Combat,
                Name = "Diamondback Scout",
                Class = 1,
                Cost = 441800,
                Retail = 564330,
                ThrustersSpeed = 280,
                BoostSpeed = 380,
                Manoeuvrability = 5,
                Shields = 120,
                Armour = 120,
                Mass = 170,
                ForwardAcceleration = 39.57,
                ReverseAcceleration = 29.82,
                LatitudeAcceleration = 25.19,
                MinThrust = 60.714,
                BoostCost = 10,
                Pitch = 42,
                Yaw = 15,
                Roll = 100,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 35,
                HeatCap = 346,
                HeatDisMin = 2.42,
                HeatDisMax = 48.05,
                FuelCost = 50,
                FuelReserve = 0.49,
                Hardness = 40,
                MassLock = 8,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 4, 4, 4, 2, 3, 2, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 3, 3, 3, 2, 1, 1 }
                }
            };
        public static readonly ShipBase Dolphin
            = new ShipBase(ShipModel.Dolphin)
            {
                FrontierId = 128049291,
                FrontierName = "Dolphin",
                ShipRole = ShipRole.Passenger,
                Name = "Dolphin",
                Class = 1,
                Cost = 1095780,
                Retail = 1337320,
                ThrustersSpeed = 250,
                BoostSpeed = 350,
                Manoeuvrability = 3,
                Shields = 110,
                Armour = 110,
                Mass = 140,
                ForwardAcceleration = 39.63,
                ReverseAcceleration = 30.01,
                LatitudeAcceleration = 14.97,
                MinThrust = 48.0,
                BoostCost = 10,
                Pitch = 30,
                Yaw = 20,
                Roll = 100,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 23,
                HeatCap = 165,
                HeatDisMin = 1.91,
                HeatDisMax = 31.35,
                FuelCost = 50,
                FuelReserve = 0.50,
                Hardness = 35,
                MassLock = 9,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 1, 1 },
                    Utility = new byte[] { 0, 0, 0 },
                    Component = new byte[] { 1, 4, 5, 4, 4, 3, 3, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 5, 4, 4, 3, 2, 2, 2, 1, 1 }
                }
            };
        public static readonly ShipBase Eagle
            = new ShipBase(ShipModel.Eagle)
            {
                FrontierId = 128049255,
                FrontierName = "Eagle",
                ShipRole = ShipRole.Combat,
                Name = "Eagle",
                Class = 1,
                Cost = 7490,
                Retail = 44800,
                ThrustersSpeed = 240,
                BoostSpeed = 350,
                Manoeuvrability = 7,
                Shields = 60,
                Armour = 40,
                Mass = 50,
                ForwardAcceleration = 43.97,
                ReverseAcceleration = 29.97,
                LatitudeAcceleration = 29.86,
                MinThrust = 75.0,
                BoostCost = 8,
                Pitch = 50,
                Yaw = 18,
                Roll = 120,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 40,
                HeatCap = 165,
                HeatDisMin = 1.38,
                HeatDisMax = 21.48,
                FuelCost = 50,
                FuelReserve = 0.34,
                Hardness = 28,
                MassLock = 6,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 1, 1, 1 },
                    Utility = new byte[] { 0 },
                    Component = new byte[] { 1, 2, 3, 3, 1, 2, 2, 2 },
                    Military = new byte[] { 2 },
                    Internal = new byte[] { 3, 2, 1, 1, 1, 1 },
                }
            };
        public static readonly ShipBase FederalAssaultShip
            = new ShipBase(ShipModel.FederalAssaultShip)
            {
                FrontierId = 128672145,
                FrontierName = "Federation_Dropship_MkII",
                ShipRole = ShipRole.Combat,
                Name = "Federal Assault Ship",
                Class = 2,
                Cost = 19102490,
                Retail = 19814210,
                Faction = MajorFaction.Federation,
                Rank = 5,
                ThrustersSpeed = 210,
                BoostSpeed = 350,
                Manoeuvrability = 4,
                Shields = 200,
                Armour = 300,
                Mass = 480,
                ForwardAcceleration = 39.81,
                ReverseAcceleration = 20.04,
                LatitudeAcceleration = 15.07,
                MinThrust = 71.429,
                BoostCost = 19,
                Pitch = 38,
                Yaw = 16,
                Roll = 90,
                PitchAcceleration = 170,
                YawAcceleration = 80,
                RollAcceleration = 200,
                PitchMin = 30,
                HeatCap = 286,
                HeatDisMin = 2.53,
                HeatDisMax = 45.23,
                FuelCost = 50,
                FuelReserve = 0.72,
                Hardness = 60,
                MassLock = 14,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 6, 5, 5, 6, 4, 4 },
                    Military = new byte[] { 4, 4 },
                    Internal = new byte[] { 5, 5, 4, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase FederalCorvette
            = new ShipBase(ShipModel.FederalCorvette)
            {
                FrontierId = 128049369,
                FrontierName = "Federation_Corvette",
                ShipRole = ShipRole.Combat,
                Name = "Federal Corvette",
                Class = 3,
                Cost = 183147460,
                Retail = 187969450,
                Faction = MajorFaction.Federation,
                Rank = 12,
                ThrustersSpeed = 200,
                BoostSpeed = 260,
                Manoeuvrability = 2,
                Shields = 555,
                Armour = 370,
                Mass = 900,
                ForwardAcceleration = 19.87,
                ReverseAcceleration = 10.08,
                LatitudeAcceleration = 9.98,
                MinThrust = 50.0,
                BoostCost = 27,
                Pitch = 28,
                Yaw = 8,
                Roll = 75,
                PitchAcceleration = 100,
                YawAcceleration = 50,
                RollAcceleration = 80,
                PitchMin = 22,
                HeatCap = 333,
                HeatDisMin = 3.28,
                HeatDisMax = 70.33,
                FuelCost = 50,
                FuelReserve = 1.13,
                Hardness = 70,
                MassLock = 24,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 4, 4, 3, 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Component = new byte[] { 1, 8, 7, 6, 5, 8, 8, 5 },
                    Military = new byte[] { 5, 5 },
                    Internal = new byte[] { 7, 7, 7, 6, 6, 5, 5, 4, 4, 3, 1 }
                }
            };
        public static readonly ShipBase FederalDropship
            = new ShipBase(ShipModel.FederalDropship)
            {
                FrontierId = 128049321,
                FrontierName = "Federation_Dropship",
                ShipRole = ShipRole.Multipurpose,
                Name = "Federal Dropship",
                Class = 2,
                Cost = 13501480,
                Retail = 14314210,
                Faction = MajorFaction.Federation,
                Rank = 3,
                ThrustersSpeed = 180,
                BoostSpeed = 300,
                Manoeuvrability = 3,
                Shields = 200,
                Armour = 300,
                Mass = 580,
                ForwardAcceleration = 29.99,
                ReverseAcceleration = 20.34,
                LatitudeAcceleration = 10.19,
                MinThrust = 55.556,
                BoostCost = 19,
                Pitch = 30,
                Yaw = 14,
                Roll = 80,
                PitchAcceleration = 100,
                YawAcceleration = 50,
                RollAcceleration = 80,
                PitchMin = 20,
                HeatCap = 331,
                HeatDisMin = 2.60,
                HeatDisMax = 46.50,
                FuelCost = 50,
                FuelReserve = 0.83,
                Hardness = 60,
                MassLock = 14,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 2, 2, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 6, 5, 5, 6, 4, 4 },
                    Military = new byte[] { 4, 4 },
                    Internal = new byte[] { 6, 5, 5, 4, 3, 3, 2, 1 }
                }
            };
        public static readonly ShipBase FederalGunship
            = new ShipBase(ShipModel.FederalGunship)
            {
                FrontierId = 128672152,
                FrontierName = "Federation_Gunship",
                ShipRole = ShipRole.Combat,
                Name = "Federal Gunship",
                Class = 2,
                Cost = 34806280,
                Retail = 35814210,
                Faction = MajorFaction.Federation,
                Rank = 7,
                ThrustersSpeed = 170,
                BoostSpeed = 280,
                Manoeuvrability = 1,
                Shields = 250,
                Armour = 350,
                Mass = 580,
                ForwardAcceleration = 24.61,
                ReverseAcceleration = 17.83,
                LatitudeAcceleration = 10.08,
                MinThrust = 58.824,
                BoostCost = 23,
                Pitch = 25,
                Yaw = 18,
                Roll = 80,
                PitchAcceleration = 100,
                YawAcceleration = 50,
                RollAcceleration = 80,
                PitchMin = 20,
                HeatCap = 325,
                HeatDisMin = 2.87,
                HeatDisMax = 51.40,
                FuelCost = 50,
                FuelReserve = 0.82,
                Hardness = 60,
                MassLock = 14,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 2, 2, 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 6, 5, 5, 7, 5, 4 },
                    Military = new byte[] { 4, 4, 4 },
                    Internal = new byte[] { 6, 6, 5, 2, 2, 1 }
                }
            };
        public static readonly ShipBase FerDeLance
            = new ShipBase(ShipModel.FerDeLance)
            {
                FrontierId = 128049351,
                FrontierName = "FerDeLance",
                ShipRole = ShipRole.Combat,
                Name = "Fer-de-Lance",
                Class = 2,
                Cost = 51126980,
                Retail = 51567040,
                ThrustersSpeed = 260,
                BoostSpeed = 350,
                Manoeuvrability = 4,
                Shields = 300,
                Armour = 225,
                Mass = 250,
                ForwardAcceleration = 29.31,
                ReverseAcceleration = 24.34,
                LatitudeAcceleration = 20.04,
                MinThrust = 84.615,
                BoostCost = 19,
                Pitch = 38,
                Yaw = 12,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 30,
                HeatCap = 224,
                HeatDisMin = 2.05,
                HeatDisMax = 41.63,
                FuelCost = 50,
                FuelReserve = 0.67,
                Hardness = 70,
                MassLock = 12,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 4, 2, 2, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 5, 4, 4, 6, 4, 3 },
                    Military = new byte[] { },
                    Internal = new byte[] { 5, 4, 4, 2, 1, 1 }
                }
            };
        public static readonly ShipBase Hauler
            = new ShipBase(ShipModel.Hauler)
            {
                FrontierId = 128049261,
                FrontierName = "Hauler",
                ShipRole = ShipRole.Freighter,
                Name = "Hauler",
                Class = 1,
                Cost = 8160,
                Retail = 52720,
                ThrustersSpeed = 200,
                BoostSpeed = 300,
                Manoeuvrability = 4,
                Shields = 50,
                Armour = 100,
                Mass = 14,
                ForwardAcceleration = 39.87,
                ReverseAcceleration = 29.95,
                LatitudeAcceleration = 29.95,
                MinThrust = 35.0,
                BoostCost = 7,
                Pitch = 36,
                Yaw = 14,
                Roll = 100,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 30,
                HeatCap = 123,
                HeatDisMin = 1.06,
                HeatDisMax = 16.20,
                FuelCost = 50,
                FuelReserve = 0.25,
                Hardness = 20,
                MassLock = 6,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 2, 2, 2, 1, 1, 1, 2 },
                    Military = new byte[] { },
                    Internal = new byte[] { 3, 3, 2, 1, 1, 1 },
                }
            };
        public static readonly ShipBase ImperialClipper
            = new ShipBase(ShipModel.ImperialClipper)
            {
                FrontierId = 128049315,
                FrontierName = "Empire_Trader",
                ShipRole = ShipRole.Multipurpose,
                Name = "Imperial Clipper",
                Class = 3,
                Cost = 21108270,
                Retail = 22295860,
                Faction = MajorFaction.Empire,
                Rank = 7,
                ThrustersSpeed = 300,
                BoostSpeed = 380,
                Manoeuvrability = 5,
                Shields = 180,
                Armour = 270,
                Mass = 400,
                ForwardAcceleration = 24.74,
                ReverseAcceleration = 20.05,
                LatitudeAcceleration = 10.10,
                MinThrust = 60.0,
                BoostCost = 19,
                Pitch = 40,
                Yaw = 18,
                Roll = 80,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 30,
                HeatCap = 304,
                HeatDisMin = 2.63,
                HeatDisMax = 46.80,
                FuelCost = 50,
                FuelReserve = 0.74,
                Hardness = 60,
                MassLock = 12,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 6, 5, 5, 6, 5, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 7, 6, 4, 4, 3, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase ImperialCourier
            = new ShipBase(ShipModel.ImperialCourier)
            {
                FrontierId = 128671223,
                FrontierName = "Empire_Courier",
                ShipRole = ShipRole.Multipurpose,
                Name = "Imperial Courier",
                Faction = MajorFaction.Empire,
                Rank = 3,
                Class = 1,
                Cost = 2462010,
                Retail = 2542930,
                ThrustersSpeed = 280,
                BoostSpeed = 380,
                Manoeuvrability = 4,
                Shields = 200,
                Armour = 80,
                Mass = 35,
                ForwardAcceleration = 57.53,
                ReverseAcceleration = 30.02,
                LatitudeAcceleration = 24.88,
                MinThrust = 78.571,
                BoostCost = 10,
                Pitch = 38,
                Yaw = 16,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 32,
                HeatCap = 230,
                HeatDisMin = 1.62,
                HeatDisMax = 25.05,
                FuelCost = 50,
                FuelReserve = 0.41,
                Hardness = 30,
                MassLock = 7,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 4, 3, 3, 1, 3, 2, 3 },
                    Military = new byte[] { },
                    Internal = new byte[] { 3, 3, 2, 2, 2, 1, 1, 1 }
                }
            };
        public static readonly ShipBase ImperialCutter
            = new ShipBase(ShipModel.ImperialCutter)
            {
                FrontierId = 128049375,
                FrontierName = "Cutter",
                ShipRole = ShipRole.Multipurpose,
                Name = "Imperial Cutter",
                Class = 3,
                Cost = 200484780,
                Retail = 208969450,
                Faction = MajorFaction.Empire,
                Rank = 12,
                ThrustersSpeed = 200,
                BoostSpeed = 320,
                Manoeuvrability = 0,
                Shields = 600,
                Armour = 400,
                Mass = 1100,
                ForwardAcceleration = 29.37,
                ReverseAcceleration = 10.04,
                LatitudeAcceleration = 6.06,
                MinThrust = 80.0,
                BoostCost = 23,
                Pitch = 18,
                Yaw = 8,
                Roll = 45,
                PitchAcceleration = 100,
                YawAcceleration = 50,
                RollAcceleration = 80,
                PitchMin = 14,
                HeatCap = 327,
                HeatDisMin = 3.27,
                HeatDisMax = 72.58,
                FuelCost = 50,
                FuelReserve = 1.16,
                Hardness = 70,
                MassLock = 27,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 4, 3, 3, 2, 2, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Component = new byte[] { 1, 8, 8, 7, 7, 7, 7, 6 },
                    Military = new byte[] { 5, 5 },
                    Internal = new byte[] { 8, 8, 6, 6, 6, 5, 5, 4, 3, 1 }
                }
            };
        public static readonly ShipBase ImperialEagle
            = new ShipBase(ShipModel.ImperialEagle)
            {
                FrontierId = 128672138,
                FrontierName = "Empire_Eagle",
                ShipRole = ShipRole.Combat,
                Name = "Imperial Eagle",
                Faction = MajorFaction.Empire,
                Rank = 0,
                Class = 1,
                Cost = 50890,
                Retail = 110830,
                ThrustersSpeed = 300,
                BoostSpeed = 400,
                Manoeuvrability = 5,
                Shields = 80,
                Armour = 60,
                Mass = 50,
                ForwardAcceleration = 34.54,
                ReverseAcceleration = 27.84,
                LatitudeAcceleration = 27.84,
                MinThrust = 70.0,
                BoostCost = 8,
                Pitch = 40,
                Yaw = 15,
                Roll = 100,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 30,
                HeatCap = 163,
                HeatDisMin = 1.50,
                HeatDisMax = 21.20,
                FuelCost = 50,
                FuelReserve = 0.37,
                Hardness = 28,
                MassLock = 6,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 1, 1 },
                    Utility = new byte[] { 0 },
                    Component = new byte[] { 1, 3, 3, 3, 1, 2, 2, 2 },
                    Military = new byte[] { 2 },
                    Internal = new byte[] { 3, 2, 1, 1, 1, 1 }
                }
            };
        public static readonly ShipBase Keelback
            = new ShipBase(ShipModel.Keelback)
            {
                FrontierId = 128672269,
                FrontierName = "Independant_Trader",
                ShipRole = ShipRole.Freighter | ShipRole.Combat,
                Name = "Keelback",
                Class = 2,
                Cost = 2937840,
                Retail = 3126150,
                ThrustersSpeed = 200,
                BoostSpeed = 300,
                Manoeuvrability = 2,
                Shields = 135,
                Armour = 270,
                Mass = 180,
                ForwardAcceleration = 20.22,
                ReverseAcceleration = 15.07,
                LatitudeAcceleration = 15.03,
                MinThrust = 45.0,
                BoostCost = 10,
                Pitch = 27,
                Yaw = 15,
                Roll = 100,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 20,
                HeatCap = 215,
                HeatDisMin = 1.87,
                HeatDisMax = 29.78,
                FuelCost = 50,
                FuelReserve = 0.39,
                Hardness = 45,
                MassLock = 8,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0, 0 },
                    Component = new byte[] { 1, 4, 4, 4, 1, 3, 2, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 5, 5, 4, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase KraitMkII
            = new ShipBase(ShipModel.KraitMkII)
            {
                FrontierId = 128816567,
                FrontierName = "Krait_MkII",
                ShipRole = ShipRole.Multipurpose,
                Name = "Krait Mk II",
                Class = 2,
                Cost = 44152080,
                Retail = 45814210,
                ThrustersSpeed = 240,
                BoostSpeed = 330,
                Manoeuvrability = 3,
                Shields = 220,
                Armour = 220,
                Mass = 320,
                ForwardAcceleration = 28.01,
                ReverseAcceleration = 18.04,
                LatitudeAcceleration = 15.12,
                MinThrust = 62.50,
                BoostCost = 13,
                Pitch = 31,
                Yaw = 10,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 200,
                PitchMin = 26,
                HeatCap = 300,
                HeatDisMin = 2.68,
                HeatDisMax = 52.05,
                FuelCost = 50,
                FuelReserve = 0.63,
                Hardness = 55,
                MassLock = 16,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3, 3, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 7, 6, 5, 4, 7, 6, 5 },
                    Military = new byte[] { },
                    Internal = new byte[] { 6, 6, 5, 5, 4, 3, 3, 2, 1 }
                }
            };
        public static readonly ShipBase KraitPhantom
            = new ShipBase(ShipModel.KraitPhantom)
            {
                FrontierId = 128839281,
                FrontierName = "Krait_Light",
                ShipRole = ShipRole.Multipurpose,
                Name = "Krait Phantom",
                Class = 2,
                Cost = 35732880,
                Retail = 37472250,
                ThrustersSpeed = 250,
                BoostSpeed = 350,
                Manoeuvrability = 3,
                Shields = 200,
                Armour = 180,
                Mass = 270,
                ForwardAcceleration = 0,
                ReverseAcceleration = 0,
                LatitudeAcceleration = 0,
                MinThrust = 64.00,
                BoostCost = 13,
                Pitch = 31,
                Yaw = 10,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 200,
                PitchMin = 26,
                HeatCap = 300,
                HeatDisMin = 2.68,
                HeatDisMax = 52.05,
                FuelCost = 50,
                FuelReserve = 0.63,
                Hardness = 60,
                MassLock = 16,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 7, 6, 5, 4, 7, 6, 5 },
                    Military = new byte[] { },
                    Internal = new byte[] { 6, 5, 5, 5, 3, 3, 3, 2, 1 }
                }
            };
        public static readonly ShipBase Mamba
            = new ShipBase(ShipModel.Mamba)
            {
                FrontierId = 128915979,
                FrontierName = "Mamba",
                ShipRole = ShipRole.Combat,
                Name = "Mamba",
                Class = 2,
                Cost = 55434290,
                Retail = 55867040,
                ThrustersSpeed = 310,
                BoostSpeed = 380,
                Manoeuvrability = 3,
                Shields = 270,
                Armour = 230,
                Mass = 250,
                ForwardAcceleration = 0,
                ReverseAcceleration = 0,
                LatitudeAcceleration = 0,
                MinThrust = 77.42,
                BoostCost = 17,
                Pitch = 30,
                Yaw = 10,
                Roll = 75,
                PitchAcceleration = 180,
                YawAcceleration = 90,
                RollAcceleration = 200,
                PitchMin = 27,
                HeatCap = 165,
                HeatDisMin = 2.05,
                HeatDisMax = 41.63,
                FuelCost = 50,
                FuelReserve = 0.50,
                Hardness = 70,
                MassLock = 12,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 4, 3, 3, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 5, 4, 4, 6, 4, 3 },
                    Military = new byte[] { },
                    Internal = new byte[] { 5, 4, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase Orca
            = new ShipBase(ShipModel.Orca)
            {
                FrontierId = 128049327,
                FrontierName = "Orca",
                ShipRole = ShipRole.Passenger,
                Name = "Orca",
                Class = 3,
                Cost = 47792090,
                Retail = 48539890,
                ThrustersSpeed = 300,
                BoostSpeed = 380,
                Manoeuvrability = 1,
                Shields = 220,
                Armour = 220,
                Mass = 290,
                ForwardAcceleration = 29.66,
                ReverseAcceleration = 25.08,
                LatitudeAcceleration = 19.95,
                MinThrust = 66.667,
                BoostCost = 16,
                Pitch = 25,
                Yaw = 18,
                Roll = 55,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 20,
                HeatCap = 262,
                HeatDisMin = 2.30,
                HeatDisMax = 42.68,
                FuelCost = 50,
                FuelReserve = 0.79,
                Hardness = 55,
                MassLock = 15,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 5, 6, 5, 6, 5, 4, 5 },
                    Military = new byte[] { },
                    Internal = new byte[] { 6, 5, 5, 5, 4, 3, 2, 2, 1 }
                }
            };
        public static readonly ShipBase Python
            = new ShipBase(ShipModel.Python)
            {
                FrontierId = 128049339,
                FrontierName = "Python",
                ShipRole = ShipRole.Multipurpose,
                Name = "Python",
                Class = 2,
                Cost = 55316050,
                Retail = 56978180,
                ThrustersSpeed = 230,
                BoostSpeed = 300,
                Manoeuvrability = 2,
                Shields = 260,
                Armour = 260,
                Mass = 350,
                ForwardAcceleration = 29.59,
                ReverseAcceleration = 18.02,
                LatitudeAcceleration = 15.92,
                MinThrust = 60.870,
                BoostCost = 23,
                Pitch = 29,
                Yaw = 10,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 24,
                HeatCap = 300,
                HeatDisMin = 2.68,
                HeatDisMax = 52.05,
                FuelCost = 50,
                FuelReserve = 0.83,
                Hardness = 65,
                MassLock = 17,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3, 3, 2, 2 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 7, 6, 5, 4, 7, 6, 5 },
                    Military = new byte[] { },
                    Internal = new byte[] { 6, 6, 6, 5, 5, 4, 3, 3, 2, 1 }
                }
            };
        public static readonly ShipBase Sidewinder
            = new ShipBase(ShipModel.Sidewinder)
            {
                FrontierId = 128049249,
                FrontierName = "SideWinder",
                ShipRole = ShipRole.Multipurpose,
                Name = "Sidewinder",
                Class = 1,
                Cost = 5070,
                Retail = 32000,
                ThrustersSpeed = 220,
                BoostSpeed = 320,
                Manoeuvrability = 5,
                Shields = 40,
                Armour = 60,
                Mass = 25,
                ForwardAcceleration = 44.39,
                ReverseAcceleration = 29.96,
                LatitudeAcceleration = 29.96,
                MinThrust = 45.454,
                BoostCost = 7,
                Pitch = 42,
                Yaw = 16,
                Roll = 110,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 34,
                HeatCap = 140,
                HeatDisMin = 1.18,
                HeatDisMax = 18.15,
                FuelCost = 50,
                FuelReserve = 0.30,
                Hardness = 20,
                MassLock = 6,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 1, 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 2, 2, 2, 1, 1, 1, 1 },
                    Military = new byte[] { },
                    Internal = new byte[] { 2, 2, 1, 1, 1, 1 },
                }
            };
        public static readonly ShipBase Type6Transporter
            = new ShipBase(ShipModel.Type6Transporter)
            {
                FrontierId = 128049285,
                FrontierName = "Type6",
                ShipRole = ShipRole.Freighter,
                Name = "Type-6 Transporter",
                Class = 2,
                Cost = 858010,
                Retail = 1045950,
                ThrustersSpeed = 220,
                BoostSpeed = 350,
                Manoeuvrability = 3,
                Shields = 90,
                Armour = 180,
                Mass = 155,
                ForwardAcceleration = 20.10,
                ReverseAcceleration = 14.96,
                LatitudeAcceleration = 15.07,
                MinThrust = 40.909,
                BoostCost = 10,
                Pitch = 30,
                Yaw = 17,
                Roll = 100,
                PitchAcceleration = 220,
                YawAcceleration = 110,
                RollAcceleration = 240,
                PitchMin = 23,
                HeatCap = 179,
                HeatDisMin = 1.70,
                HeatDisMax = 24.55,
                FuelCost = 50,
                FuelReserve = 0.39,
                Hardness = 35,
                MassLock = 8,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 1, 1 },
                    Utility = new byte[] { 0, 0, 0 },
                    Component = new byte[] { 1, 3, 4, 4, 2, 3, 2, 4 },
                    Military = new byte[] { },
                    Internal = new byte[] { 5, 5, 4, 4, 3, 2, 2, 1 }
                }
            }; 
        public static readonly ShipBase Type7Transporter
            = new ShipBase(ShipModel.Type7Transporter)
            {
                FrontierId = 128049297,
                FrontierName = "Type7",
                ShipRole = ShipRole.Freighter,
                Name = "Type-7 Transporter",
                Class = 3,
                Cost = 16774470,
                Retail = 17472250,
                ThrustersSpeed = 180,
                BoostSpeed = 300,
                Manoeuvrability = 1,
                Shields = 156,
                Armour = 340,
                Mass = 350,
                ForwardAcceleration = 20.11,
                ReverseAcceleration = 15.02,
                LatitudeAcceleration = 15.13,
                MinThrust = 33.333,
                BoostCost = 10,
                Pitch = 22,
                Yaw = 22,
                Roll = 60,
                PitchAcceleration = 200,
                YawAcceleration = 50,
                RollAcceleration = 200,
                PitchMin = 16,
                YawMin = 16,
                HeatCap = 226,
                HeatDisMin = 2.17,
                HeatDisMax = 32.45,
                FuelCost = 50,
                FuelReserve = 0.52,
                Hardness = 54,
                MassLock = 10,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 1, 1, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 5, 5, 5, 4, 4, 3, 5 },
                    Military = new byte[] { },
                    Internal = new byte[] { 6, 6, 6, 5, 5, 5, 3, 3, 2, 1 }
                }
            };
        public static readonly ShipBase Type9Heavy
            = new ShipBase(ShipModel.Type9Heavy)
            {
                FrontierId = 128049333,
                FrontierName = "Type9",
                ShipRole = ShipRole.Freighter,
                Name = "Type-9 Heavy",
                Class = 3,
                Cost = 72108220,
                Retail = 76555840,
                ThrustersSpeed = 130,
                BoostSpeed = 200,
                Manoeuvrability = 0,
                Shields = 240,
                Armour = 480,
                Mass = 850,
                ForwardAcceleration = 20.03,
                ReverseAcceleration = 10.11,
                LatitudeAcceleration = 10.03,
                MinThrust = 30.769,
                BoostCost = 19,
                Pitch = 20,
                Yaw = 8,
                Roll = 20,
                PitchAcceleration = 100,
                YawAcceleration = 50,
                RollAcceleration = 80,
                PitchMin = 15,
                HeatCap = 289,
                HeatDisMin = 3.10,
                HeatDisMax = 48.35,
                FuelCost = 50,
                FuelReserve = 0.77,
                Hardness = 65,
                MassLock = 16,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 6, 7, 6, 5, 6, 4, 6 },
                    Military = new byte[] { },
                    Internal = new byte[] { 8, 8, 7, 6, 5, 4, 4, 3, 3, 2, 1 }
                }
            };
        public static readonly ShipBase Type10Defender
            = new ShipBase(ShipModel.Type10Defender)
            {
                FrontierId = 128785619,
                FrontierName = "Type9_Military",
                ShipRole = ShipRole.Freighter,
                Name = "Type-10 Defender",
                Class = 3,
                Cost = 121486140,
                Retail = 124755340,
                ThrustersSpeed = 180,
                BoostSpeed = 220,
                Manoeuvrability = 0,
                Shields = 320,
                Armour = 580,
                Mass = 1200,
                ForwardAcceleration = 17.96,
                ReverseAcceleration = 10.04,
                LatitudeAcceleration = 10.09,
                MinThrust = 83.333,
                BoostCost = 19,
                Pitch = 22,
                Yaw = 8,
                Roll = 40,
                PitchAcceleration = 100,
                YawAcceleration = 35,
                RollAcceleration = 80,
                PitchMin = 18,
                HeatCap = 335,
                HeatDisMin = 3.16,
                HeatDisMax = 67.15,
                FuelCost = 50,
                FuelReserve = 0.77,
                Hardness = 75,
                MassLock = 26,
                Crew = 3,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3, 3, 3, 2, 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Component = new byte[] { 1, 8, 7, 7, 5, 7, 4, 6 },
                    Military = new byte[] { 5, 5 },
                    Internal = new byte[] { 8, 7, 6, 5, 4, 4, 3, 3, 2, 1 }
                }
            };
        public static readonly ShipBase ViperMkIII
            = new ShipBase(ShipModel.ViperMkIII)
            {
                FrontierId = 128049273,
                FrontierName = "Viper",
                ShipRole = ShipRole.Combat,
                Name = "Viper Mk III",
                Class = 1,
                Cost = 74610,
                Retail = 142930,
                ThrustersSpeed = 320,
                BoostSpeed = 400,
                Manoeuvrability = 4,
                Shields = 105,
                Armour = 70,
                Mass = 50,
                ForwardAcceleration = 53.98,
                ReverseAcceleration = 29.70,
                LatitudeAcceleration = 24.95,
                MinThrust = 62.5,
                BoostCost = 10,
                Pitch = 35,
                Yaw = 15,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 30,
                HeatCap = 195,
                HeatDisMin = 1.69,
                HeatDisMax = 26.20,
                FuelCost = 50,
                FuelReserve = 0.41,
                Hardness = 35,
                MassLock = 7,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 3, 3, 3, 2, 3, 3, 2 },
                    Military = new byte[] { 3 },
                    Internal = new byte[] { 3, 3, 2, 1, 1, 1 }
                }
            };
        public static readonly ShipBase ViperMkIV
            = new ShipBase(ShipModel.ViperMkIV)
            {
                FrontierId = 128672255,
                FrontierName = "Viper_MkIV",
                ShipRole = ShipRole.Combat,
                Name = "Viper Mk IV",
                Class = 1,
                Cost = 290680,
                Retail = 437930,
                ThrustersSpeed = 270,
                BoostSpeed = 340,
                Manoeuvrability = 3,
                Shields = 150,
                Armour = 150,
                Mass = 190,
                ForwardAcceleration = 53.84,
                ReverseAcceleration = 30.14,
                LatitudeAcceleration = 24.97,
                MinThrust = 64.815,
                BoostCost = 10,
                Pitch = 30,
                Yaw = 12,
                Roll = 90,
                PitchAcceleration = 200,
                YawAcceleration = 100,
                RollAcceleration = 220,
                PitchMin = 25,
                HeatCap = 209,
                HeatDisMin = 1.82,
                HeatDisMax = 28.98,
                FuelCost = 50,
                FuelReserve = 0.46,
                Hardness = 35,
                MassLock = 7,
                Crew = 1,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 2, 2, 1, 1 },
                    Utility = new byte[] { 0, 0 },
                    Component = new byte[] { 1, 4, 4, 4, 2, 3, 3, 4 },
                    Military = new byte[] { 3 },
                    Internal = new byte[] { 4, 4, 3, 2, 2, 1, 1, 1 }
                }
            };
        public static readonly ShipBase Vulture
            = new ShipBase(ShipModel.Vulture)
            {
                FrontierId = 128672276,
                FrontierName = "Vulture",
                ShipRole = ShipRole.Combat,
                Name = "Vulture",
                Class = 1,
                Cost = 4670100,
                Retail = 4925620,
                ThrustersSpeed = 210,
                BoostSpeed = 340,
                Manoeuvrability = 5,
                Shields = 240,
                Armour = 160,
                Mass = 230,
                ForwardAcceleration = 39.55,
                ReverseAcceleration = 29.88,
                LatitudeAcceleration = 19.98,
                MinThrust = 90.476,
                BoostCost = 16,
                Pitch = 42,
                Yaw = 17,
                Roll = 110,
                PitchAcceleration = 180,
                YawAcceleration = 90,
                RollAcceleration = 200,
                PitchMin = 35,
                HeatCap = 237,
                HeatDisMin = 1.87,
                HeatDisMax = 35.63,
                FuelCost = 50,
                FuelReserve = 0.57,
                Hardness = 55,
                MassLock = 10,
                Crew = 2,
                Slots = new SlotsConfiguration
                {
                    Hardpoints = new byte[] { 3, 3 },
                    Utility = new byte[] { 0, 0, 0, 0 },
                    Component = new byte[] { 1, 4, 5, 4, 3, 5, 4, 3 },
                    Military = new byte[] { 5 },
                    Internal = new byte[] { 5, 4, 2, 1, 1, 1, 1 }
                }
            };

        public static readonly IReadOnlyDictionary<ShipModel, ShipBase> Ships = new Dictionary<ShipModel, ShipBase>
        {
            {Adder.Model, Adder},
            {AllianceChallenger.Model, AllianceChallenger},
            {AllianceChieftain.Model, AllianceChieftain},
            {AllianceCrusader.Model, AllianceCrusader},
            {Anaconda.Model, Anaconda},
            {AspExplorer.Model, AspExplorer},
            {AspScout.Model, AspScout},
            {BelugaLiner.Model, BelugaLiner},
            {CobraMkIII.Model, CobraMkIII},
            {CobraMkIV.Model, CobraMkIV},
            {DiamondbackExplorer.Model, DiamondbackExplorer},
            {DiamondbackScout.Model, DiamondbackScout},
            {Dolphin.Model, Dolphin},
            {Eagle.Model, Eagle},
            {FederalAssaultShip.Model, FederalAssaultShip},
            {FederalCorvette.Model, FederalCorvette},
            {FederalDropship.Model, FederalDropship},
            {FederalGunship.Model, FederalGunship},
            {FerDeLance.Model, FerDeLance},
            {Hauler.Model, Hauler},
            {ImperialClipper.Model, ImperialClipper},
            {ImperialCourier.Model, ImperialCourier},
            {ImperialCutter.Model, ImperialCutter},
            {ImperialEagle.Model, ImperialEagle},
            {Keelback.Model, Keelback},
            {KraitMkII.Model, KraitMkII},
            {KraitPhantom.Model, KraitPhantom},
            {Mamba.Model, Mamba},
            {Orca.Model, Orca},
            {Python.Model, Python},
            {Sidewinder.Model, Sidewinder},
            {Type6Transporter.Model, Type6Transporter},
            {Type7Transporter.Model, Type7Transporter},
            {Type9Heavy.Model, Type9Heavy},
            {Type10Defender.Model, Type10Defender},
            {ViperMkIII.Model, ViperMkIII},
            {ViperMkIV.Model, ViperMkIV},
            {Vulture.Model, Vulture}
        };
    }

    public class SlotsConfiguration
    {
        public IReadOnlyList<byte> Hardpoints { get; internal set; }
        public IReadOnlyList<byte> Utility { get; internal set; }
        public IReadOnlyList<byte> Component { get; internal set; }
        public IReadOnlyList<byte> Military { get; internal set; }
        public IReadOnlyList<byte> Internal { get; internal set; }

        internal SlotsConfiguration() { }
    }
}