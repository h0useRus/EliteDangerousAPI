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
    }
}