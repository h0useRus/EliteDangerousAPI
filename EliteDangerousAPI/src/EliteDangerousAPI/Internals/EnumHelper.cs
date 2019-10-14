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
    }
}