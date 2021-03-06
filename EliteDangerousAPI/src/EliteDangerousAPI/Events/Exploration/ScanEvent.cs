using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals.Converters;

namespace NSW.EliteDangerous.API.Events
{
    public class ScanEvent : JournalEvent
    {
        #region General
        [JsonProperty("ScanType")]
        public DiscoveryScanType ScanType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("Radius")]
        public double Radius { get; internal set; }

        [JsonProperty("RotationPeriod")]
        public double RotationPeriod { get; internal set; }

        [JsonProperty("SurfaceTemperature")]
        public double SurfaceTemperature { get; internal set; }

        [JsonProperty("DistanceFromArrivalLS")]
        public double DistanceFromArrivalLs { get; internal set; }

        [JsonProperty("SemiMajorAxis")]
        public double SemiMajorAxis { get; internal set; }

        [JsonProperty("Eccentricity")]
        public double Eccentricity { get; internal set; }

        [JsonProperty("OrbitalInclination")]
        public double OrbitalInclination { get; internal set; }

        [JsonProperty("Periapsis")]
        public double Periapsis { get; internal set; }

        [JsonProperty("OrbitalPeriod")]
        public double OrbitalPeriod { get; internal set; }

        [JsonProperty("WasDiscovered")]
        public bool WasDiscovered { get; internal set; }

        [JsonProperty("WasMapped")]
        public bool WasMapped { get; internal set; }
        
        #endregion

        #region Star

        [JsonProperty("StarType")]
        public string StarType { get; internal set; }

        [JsonProperty("Subclass")]
        public int Subclass { get; internal set; }

        [JsonProperty("StellarMass")]
        public double StellarMass { get; internal set; }

        [JsonProperty("AbsoluteMagnitude")]
        public double AbsoluteMagnitude { get; internal set; }

        [JsonProperty("Luminosity")]
        public string Luminosity { get; internal set; }

        [JsonProperty("Age_MY")]
        public long AgeMillionsYears { get; internal set; }

        #endregion

        #region Planet

        [JsonProperty("PlanetClass")]
        public string PlanetClass { get; internal set; }

        [JsonProperty("TidalLock")]
        public bool? TidalLock { get; internal set; }

        [JsonProperty("TerraformState")]
        [JsonConverter(typeof(TerraformStateConverter))]
        public TerraformState TerraformState { get; internal set; }

        [JsonProperty("Parents")]
        public ParentBody[] Parents { get; internal set; }

        [JsonProperty("MassEM")]
        public double MassEm { get; internal set; }

        [JsonProperty("Atmosphere")]
        public string Atmosphere { get; internal set; }

        [JsonProperty("AtmosphereType")]
        public string AtmosphereType { get; internal set; }

        [JsonProperty("AtmosphereComposition")]
        public Composition[] AtmosphereComposition { get; internal set; }

        [JsonProperty("Volcanism")]
        public string Volcanism { get; internal set; }

        [JsonProperty("SurfaceGravity")]
        public double SurfaceGravity { get; internal set; }

        [JsonProperty("SurfacePressure")]
        public double SurfacePressure { get; internal set; }

        [JsonProperty("Landable")]
        public bool Landable { get; internal set; }

        [JsonProperty("Materials")]
        public Composition[] Materials { get; internal set; }

        [JsonProperty("Composition")]
        public GeologicComposition Composition { get; internal set; }

        [JsonProperty("Rings")]
        public Ring[] Rings { get; internal set; }

        [JsonProperty("ReserveLevel")]
        [JsonConverter(typeof(RingsReserveLevelConverter))]
        public RingsReserveLevel? ReserveLevel { get; internal set; }

        [JsonProperty("AxialTilt")]
        public double AxialTilt { get; internal set; }
        #endregion

        [JsonIgnore]
        public BodyType BodyType => string.IsNullOrWhiteSpace(StarType) ? BodyType.Planet : BodyType.Star;

        internal static ScanEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<ScanEvent>(json));
    }
}