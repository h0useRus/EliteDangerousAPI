using System;

namespace NSW.EliteDangerous.API.Internals
{
    internal static class EnumHelper
    {
        public static GovernmentType GetGovernmentType(string government)
        {
            if (string.IsNullOrWhiteSpace(government)) return GovernmentType.None;

            var value = government.Trim().ToLower().Replace(" ",string.Empty).Replace(";", string.Empty).Replace("$government_", string.Empty);

            return value switch
            {
                "anarchy" => GovernmentType.Anarchy,
                "communism" => GovernmentType.Communism,
                "confederacy" => GovernmentType.Confederacy,
                "cooperative" => GovernmentType.Cooperative,
                "corporate" => GovernmentType.Corporate,
                "democracy" => GovernmentType.Democracy,
                "dictatorship" => GovernmentType.Dictatorship,
                "feudal" => GovernmentType.Feudal,
                "imperial" => GovernmentType.Imperial,
                "patronage" => GovernmentType.Patronage,
                "prisoncolony" => GovernmentType.PrisonColony,
                "theocracy" => GovernmentType.Theocracy,
                "prison" => GovernmentType.Prison,
                "engineer" => GovernmentType.EngineerWorkshop,
                _ => GovernmentType.None
            };
        }

        public static EconomyType GetEconomyType(string economy)
        {
            if (string.IsNullOrWhiteSpace(economy)) return EconomyType.None;

            var value = economy.Trim().ToLower().Replace(" ",string.Empty).Replace(";", string.Empty).Replace("$economy_", string.Empty);

            return value switch
            {
                "agri" => EconomyType.Agriculture,
                "agriculture" => EconomyType.Agriculture,
                "colony" => EconomyType.Colony,
                "extraction" => EconomyType.Extraction,
                "hightech" => EconomyType.HighTech,
                "industrial" => EconomyType.Industrial,
                "military" => EconomyType.Military,
                "refinery" => EconomyType.Refinery,
                "service" => EconomyType.Service,
                "terraforming" => EconomyType.Terraforming,
                "tourism" => EconomyType.Tourism,
                "prison" => EconomyType.Prison,
                "repair" => EconomyType.Repair,
                "rescue" => EconomyType.Rescue,
                "damaged" => EconomyType.Damaged,
                _ => EconomyType.None
            };
        }

        public static SecurityType GetSecurityType(string security)
        {
            if (string.IsNullOrWhiteSpace(security)) return SecurityType.None;

            var value = security.Trim().ToLower()
                .Replace(" ", string.Empty)
                .Replace(";", string.Empty)
                .Replace("$system_security_", string.Empty)
                .Replace("$galaxy_map_info_state_", string.Empty);

            return value switch
            {
                "low" => SecurityType.Low,
                "medium" => SecurityType.Medium,
                "high" => SecurityType.High,
                "anarchy" => SecurityType.Anarchy,
                "lawless" => SecurityType.Lawless,
                _ => SecurityType.None
            };
        }

        public static UssType GetUssType(string uss)
        {
            if (string.IsNullOrWhiteSpace(uss)) return UssType.Unknown;

            var value = uss.Trim().ToLower()
                .Replace(" ", string.Empty)
                .Replace(";", string.Empty)
                .Replace("$uss_type_", string.Empty);

            return value switch
            {
                "aftermath" => UssType.Aftermath,
                "anomaly" => UssType.Anomaly,
                "ceremonial" => UssType.Ceremonial,
                "convoy" => UssType.Convoy,
                "distresssignal" => UssType.DistressSignal,
                "missiontarget" => UssType.MissionTarget,
                "nonhuman" => UssType.NonHuman,
                "salvage" => UssType.Salvage,
                "valuablesalvage" => UssType.ValuableSalvage,
                "veryvaluablesalvage" => UssType.VeryValuableSalvage,
                "weaponsfire" => UssType.WeaponsFire,
                "tradingbeacon" => UssType.TradingBeacon,
                _ => UssType.Unknown
            };
        }

        public static Happiness GetHappiness(string happiness)
        {
            if (string.IsNullOrWhiteSpace(happiness)) return Happiness.None;

            var value = happiness.Trim().ToLower()
                .Replace(" ", string.Empty)
                .Replace(";", string.Empty)
                .Replace("$faction_", string.Empty);
            return value switch
            {
                "happinessband1" => Happiness.Elated,
                "happinessband2" => Happiness.Happy,
                "happinessband3" => Happiness.Discontented,
                "happinessband4" => Happiness.Unhappy,
                "happinessband5" => Happiness.Despondent,
                _ => Happiness.None
            };
        }

        public static RingsReserveLevel GetRingsReserveLevel(string ringsLevel)
        {
            if (string.IsNullOrWhiteSpace(ringsLevel))
                return RingsReserveLevel.None;

            var value = ringsLevel.Trim().ToLower()
                .Replace(" ", string.Empty)
                .Replace("resources", string.Empty);

            return Enum.TryParse(value, true, out RingsReserveLevel result) ? result : RingsReserveLevel.None;
        }

        public static RingClass GetRingClass(string ringClass)
        {
            if (string.IsNullOrWhiteSpace(ringClass))
                return RingClass.Unknown;

            var value = ringClass.Trim().ToLower()
                .Replace(" ", string.Empty)
                .Replace("eringclass_", string.Empty)
                .Replace("metalic","metallic");

            return Enum.TryParse(value, true, out RingClass result) ? result : RingClass.Unknown;
        }

        public static TerraformState GetTerraformState(string terraform)
        {
            if (string.IsNullOrWhiteSpace(terraform))
                return TerraformState.NotTerraformable;

            var value = terraform.Trim().ToLower()
                .Replace(" ", string.Empty);

            return value switch
            {
               "terraformable" => TerraformState.Terraformable,
               "candidateforterraforming" => TerraformState.Terraformable,
               "terraformed" => TerraformState.Terraformed,
               "terraformingcompleted" => TerraformState.Terraformed,
               "terraforming" => TerraformState.Terraforming,
               "beingterraformed" => TerraformState.Terraforming,
                _ => TerraformState.NotTerraformable
            };
        }

        public static ShipModel GetShipModel(string shipType)
        {
            if (string.IsNullOrWhiteSpace(shipType))
                return ShipModel.Unknown;

            var value = shipType.Trim().ToLower()
                .Replace(";", string.Empty)
                .Replace("$shipname_", string.Empty);

            return value switch
            {
                "adder" => ShipModel.Adder,
                "typex_3" => ShipModel.AllianceChallenger,
                "typex" => ShipModel.AllianceChieftain,
                "typex_2" => ShipModel.AllianceCrusader,
                "anaconda" => ShipModel.Anaconda,
                "asp explorer" => ShipModel.AspExplorer,
                "asp" => ShipModel.AspExplorer,
                "asp scout" => ShipModel.AspScout,
                "asp_scout" => ShipModel.AspScout,
                "beluga liner" => ShipModel.BelugaLiner,
                "belugaliner" => ShipModel.BelugaLiner,
                "cobra mk. iii" => ShipModel.CobraMkIII,
                "cobramkiii" => ShipModel.CobraMkIII,
                "cobra mk. iv" => ShipModel.CobraMkIV,
                "cobramkiv" => ShipModel.CobraMkIV,
                "diamondback explorer" => ShipModel.DiamondbackExplorer,
                "diamondbackxl" => ShipModel.DiamondbackExplorer,
                "diamondback scout" => ShipModel.DiamondbackScout,
                "diamondback" => ShipModel.DiamondbackScout,
                "dolphin" => ShipModel.Dolphin,
                "eagle" => ShipModel.Eagle,
                "federal assault ship" => ShipModel.FederalAssaultShip,
                "federation_dropship_mkii" => ShipModel.FederalAssaultShip,
                "federal corvette" => ShipModel.FederalCorvette,
                "federation_corvette" => ShipModel.FederalCorvette,
                "federal dropship" => ShipModel.FederalDropship,
                "federation_dropship" => ShipModel.FederalDropship,
                "federal gunship" => ShipModel.FederalGunship,
                "federation_gunship" => ShipModel.FederalGunship,
                "fer-de-lance" => ShipModel.FerDeLance,
                "ferdelance" => ShipModel.FerDeLance,
                "hauler" => ShipModel.Hauler,
                "imperial clipper" => ShipModel.ImperialClipper,
                "empire_trader" => ShipModel.ImperialClipper,
                "imperial courier" => ShipModel.ImperialCourier,
                "empire_courier" => ShipModel.ImperialCourier,
                "imperial cutter" => ShipModel.ImperialCutter,
                "cutter" => ShipModel.ImperialCutter,
                "imperial eagle" => ShipModel.ImperialEagle,
                "empire_eagle" => ShipModel.ImperialEagle,
                "keelback" => ShipModel.Keelback,
                "independant_trader" => ShipModel.Keelback,
                "krait_mkii" => ShipModel.KraitMkII,
                "krait_light" => ShipModel.KraitPhantom,
                "mamba" => ShipModel.Mamba,
                "orca" => ShipModel.Orca,
                "python" => ShipModel.Python,
                "sidewinder" => ShipModel.Sidewinder,
                "type 6 transporter" => ShipModel.Type6Transporter,
                "type6" => ShipModel.Type6Transporter,
                "type 7 transporter" => ShipModel.Type7Transporter,
                "type7" => ShipModel.Type7Transporter,
                "type 9 heavy" => ShipModel.Type9Heavy,
                "type9" => ShipModel.Type9Heavy,
                "type 10 defender" => ShipModel.Type10Defender,
                "type9_military" => ShipModel.Type10Defender,
                "viper mk. iii" => ShipModel.ViperMkIII,
                "viper" => ShipModel.ViperMkIII,
                "viper mk. iv" => ShipModel.ViperMkIV,
                "viper_mkiv" => ShipModel.ViperMkIV,
                "vulture" => ShipModel.Vulture,
                // npc
                "police_alliance" => ShipModel.PoliceAlliance,
                "police_independent" => ShipModel.PoliceIndependent,
                "police_federation" => ShipModel.PoliceFederation,
                "police_empire" => ShipModel.PoliceEmpire,
                "military_federation" => ShipModel.MilitaryFederation,
                "military_independent" => ShipModel.MilitaryIndependent,
                "military_alliance" => ShipModel.MilitaryAlliance,
                "military_empire" => ShipModel.MilitaryEmpire,
                "militaryfighter_empire" => ShipModel.MilitaryFighterEmpire,
                "militaryfighter_alliance" => ShipModel.MilitaryFighterAlliance,
                "militaryfighter_independent" => ShipModel.MilitaryFighterIndependent,
                "militaryfighter_federation" => ShipModel.MilitaryFighterFederation,
                "atr_independent" => ShipModel.AtrIndependent,
                "atr_federation" => ShipModel.AtrFederation,
                "atr_empire" => ShipModel.AtrEmpire,
                "atr_alliance" => ShipModel.AtrAlliance,
                "passengerliner_wedding" => ShipModel.WeddingBarge,
                "searchandrescue" => ShipModel.SearchAndRescue,
                "ax_military_independent" => ShipModel.AxMilitaryIndependent,
                "ax_military_empire" => ShipModel.AxMilitaryEmpire,
                "ax_military_federation" => ShipModel.AxMilitaryFederation,
                "ax_military_alliance" => ShipModel.AxMilitaryAlliance,
                "independent_fighter" => ShipModel.IndependentFighter,
                _ => ShipModel.Npc
            };
        }

        public static StationType GetStationType(string station)
        {
            if (string.IsNullOrWhiteSpace(station))
                return StationType.Unknown;

            var value = station.Trim().ToLower()
                .Replace(" ", string.Empty);

            return value switch
            {
                "coriolis" => StationType.CoriolisStarport,
                "coriolisstarport" => StationType.CoriolisStarport,
                "bernal" => StationType.OcellusStarport,
                "ocellusstarport" => StationType.OcellusStarport,
                "ocellus" => StationType.OcellusStarport,
                "orbis" => StationType.OrbisStarport,
                "orbisstarport" => StationType.OrbisStarport,
                "outpost" => StationType.Outpost,
                "civilianoutpost" => StationType.CivilianOutpost,
                "commercialoutpost" => StationType.CommercialOutpost,
                "industrialoutpost" => StationType.IndustrialOutpost,
                "militaryoutpost" => StationType.MilitaryOutpost,
                "miningoutpost" => StationType.MiningOutpost,
                "scientificoutpost" => StationType.ScientificOutpost,
                "outpostscientific" => StationType.ScientificOutpost,
                "surfacestation" => StationType.PlanetaryOutpost,
                "crateroutpost" => StationType.PlanetaryOutpost,
                "planetaryoutpost" => StationType.PlanetaryOutpost,
                "planetaryport" => StationType.PlanetaryPort,
                "craterport" => StationType.PlanetaryPort,
                "asteroidbase" => StationType.AsteroidBase,
                "megaship" => StationType.MegaShip,
                "megashipcivilian" => StationType.CivilianMegaShip,
                _ => StationType.Unknown
            };
        }
    }
}