using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NSW.EliteDangerous.API
{
    public static class EliteDangerousData
    {
        public static IReadOnlyDictionary<int, string> Engineers { get; } = new Dictionary<int, string>
        {
            {300000, "Didi Vatermann"},
            {300010, "Bill Turner"},
            {300030, "Broo Tarquin"},
            {300040, "The Sarge"},
            {300050, "Zachariah Nemo"},
            {300080, "Liz Ryder"},
            {300090, "Hera Tani"},
            {300100, "Felicity Farseer"},
            {300110, "Ram Tah"},
            {300120, "Lei Cheung"},
            {300140, "Col. Bris Dekker"},
            {300160, "Elvira Martuuk"},
            {300180, "The Dweller"},
            {300200, "Marco Quent"},
            {300210, "Selene Jean"},
            {300220, "Prof. Palin"},
            {300230, "Lori Jameson"},
            {300250, "Juri Ishmaak"},
            {300260, "Tod 'The Blaster' McQuinn"},
            {300270, "Tiana Fortune"}
        };

        public static IReadOnlyDictionary<int, string> PlanetClasses { get; } = new Dictionary<int, string>
        {
            {0, "Metal rich body"},
            {1, "High metal content body"},
            {2, "Icy body"},
            {3, "Rocky ice body"},
            {4, "Earthlike body"},
            {5, "Water world"},
            {6, "Ammonia world"},
            {7, "Water giant"},
            {8, "Water giant with life"},
            {9, "Gas giant with water based life"},
            {10, "Gas giant with ammonia based life"},
            {11, "Sudarsky class I gas giant (also class II, III, IV, V)"},
            {12, "Helium rich gas giant"},
            {13, "Helium gas giant"}
        };

        public static IReadOnlyDictionary<int, string> AtmosphereClasses { get; } = new Dictionary<int, string>
        {
            {0, "No atmosphere"},
            {1, "Suitable for water-based life"},
            {2, "Ammonia and oxygen"},
            {3, "Ammonia"},
            {4, "Water"},
            {5, "Carbon dioxide"},
            {6, "Sulphur dioxide"},
            {7, "Nitrogen"},
            {8, "Water-rich"},
            {9, "Methane-rich"},
            {10, "Ammonia-rich"},
            {11, "Carbon dioxide-rich"},
            {12, "Methane"},
            {13, "Helium"},
            {14, "Silicate vapour"},
            {15, "Metallic vapour"},
            {16, "Neon-rich"},
            {17, "Argon-rich"},
            {18, "Neon"},
            {19, "Argon"},
            {20, "Oxygen"}
        };

        public static IReadOnlyDictionary<int, string> VolcanismClasses { get; } = new Dictionary<int, string>
        {
            {0, "None"},
            {1, "Water Magma"},
            {2, "Sulphur Dioxide Magma"},
            {3, "Ammonia Magma"},
            {4, "Methane Magma"},
            {5, "Nitrogen Magma"},
            {6, "Silicate Magma"},
            {7, "Metallic Magma"},
            {8, "Water Geysers"},
            {9, "Carbon Dioxide Geysers"},
            {10, "Ammonia-rich"},
            {11, "Ammonia Geysers"},
            {12, "Methane Geysers"},
            {13, "Nitrogen Geysers"},
            {14, "Helium Geysers"},
            {15, "Silicate Vapour Geysers"}
        };

        public static IReadOnlyList<string> FuelScoopableStars { get; } = new List<string>
        {
            "M",
            "K",
            "A",
            "B",
            "F",
            "G"
        };
        /// <summary>
        /// Hidden gem, but not preferred
        /// </summary>
        public static IEliteDangerousAPI CreateAPI(ApiOptions options = null, ILoggerFactory loggerFactory = null)
            => new EliteDangerousAPI(new OptionsWrapper<ApiOptions>(options ?? new ApiOptions()), loggerFactory);
    }
}