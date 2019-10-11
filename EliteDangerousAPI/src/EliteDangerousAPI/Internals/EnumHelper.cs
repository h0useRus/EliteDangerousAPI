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
                _ => GovernmentType.None,
            };
        }
    }
}