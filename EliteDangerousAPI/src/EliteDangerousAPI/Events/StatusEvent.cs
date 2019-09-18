using System;
using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class StatusEvent : JournalEvent, IEquatable<StatusEvent>
    {
        [JsonProperty("Flags")]
        public ShipStatusFlags Flags { get; internal set; }

        [JsonProperty("Pips")]
        public long[] Pips { get; internal set; }

        [JsonProperty("FireGroup")]
        public long FireGroup { get; internal set; }

        [JsonProperty("GuiFocus")]
        public GuiFocus GuiFocus { get; internal set; }

        [JsonProperty("Fuel")]
        public Fuel Fuel { get; internal set; }

        [JsonProperty("LegalState")]
        public LegalState LegalState { get; internal set; }

        [JsonProperty("Cargo")]
        public int Cargo { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Altitude")]
        public double Altitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        [JsonProperty("Heading")]
        public double Heading { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("PlanetRadius")]
        public double PlanetRadius { get; internal set; }

        [JsonIgnore]
        public bool Docked => GetFlag(0);

        [JsonIgnore]
        public bool Landed => GetFlag(1);

        [JsonIgnore]
        public bool GearDown => GetFlag(2);

        [JsonIgnore]
        public bool ShieldsUp => GetFlag(3);

        [JsonIgnore]
        public bool InSupercruise => GetFlag(4);

        [JsonIgnore]
        public bool FlightAssistOff => !GetFlag(5);

        [JsonIgnore]
        public bool HardpointsDeployed => GetFlag(6);

        [JsonIgnore]
        public bool InWing => GetFlag(7);

        [JsonIgnore]
        public bool LightsOn => GetFlag(8);

        [JsonIgnore]
        public bool CargoScoopDeployed => GetFlag(9);

        [JsonIgnore]
        public bool SilentRunning => GetFlag(10);

        [JsonIgnore]
        public bool ScoopingFuel => GetFlag(11);

        [JsonIgnore]
        public bool SrvHandbreak => GetFlag(12);

        [JsonIgnore]
        public bool SrvTurrentInUse => GetFlag(13);

        [JsonIgnore]
        public bool SrvTurrentRetracted => GetFlag(14);

        [JsonIgnore]
        public bool SrvNearShip => GetFlag(14);

        [JsonIgnore]
        public bool SrvDriveAssist => GetFlag(15);

        [JsonIgnore]
        public bool FsdMassLocked => GetFlag(16);

        [JsonIgnore]
        public bool FsdCharging => GetFlag(17);

        [JsonIgnore]
        public bool FsdCooldown => GetFlag(18);

        [JsonIgnore]
        public bool LowFuel => GetFlag(19);

        [JsonIgnore]
        public bool Overheating => GetFlag(20);

        [JsonIgnore]
        public bool HasLatLong => GetFlag(21);

        [JsonIgnore]
        public bool InDanger => GetFlag(22);

        [JsonIgnore]
        public bool Interdicted => GetFlag(23);

        [JsonIgnore]
        public bool InMothership => GetFlag(24);

        [JsonIgnore]
        public bool InFighter => GetFlag(25);

        [JsonIgnore]
        public bool InSrv => GetFlag(26);

        [JsonIgnore]
        public bool AnalysisMode => GetFlag(27);

        [JsonIgnore]
        public bool NightVision => GetFlag(28);

        [JsonIgnore]
        public bool HighAltitudeMode => GetFlag(29);
        
        private bool GetFlag(int bit) => Flags.HasFlag((ShipStatusFlags)(1 << bit));

        #region Equality members

        /// <inheritdoc />
        public bool Equals(StatusEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Flags == other.Flags
                   && Equals(Pips, other.Pips)
                   && FireGroup == other.FireGroup
                   && GuiFocus == other.GuiFocus
                   && Equals(Fuel, other.Fuel)
                   && LegalState == other.LegalState
                   && Cargo == other.Cargo
                   && Latitude.Equals(other.Latitude)
                   && Altitude.Equals(other.Altitude)
                   && Longitude.Equals(other.Longitude)
                   && Heading.Equals(other.Heading)
                   && BodyName == other.BodyName
                   && PlanetRadius.Equals(other.PlanetRadius);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((StatusEvent) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Flags;
                hashCode = (hashCode * 397) ^ (Pips != null ? Pips.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ FireGroup.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) GuiFocus;
                hashCode = (hashCode * 397) ^ (Fuel != null ? Fuel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) LegalState;
                hashCode = (hashCode * 397) ^ Cargo;
                hashCode = (hashCode * 397) ^ Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Altitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Longitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Heading.GetHashCode();
                hashCode = (hashCode * 397) ^ (BodyName != null ? BodyName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PlanetRadius.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}