using System;
using System.Linq;
using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class StatusEvent : JournalEvent, IEquatable<StatusEvent>
    {
        [JsonProperty("Flags")]
        public ShipStatusFlags Flags { get; internal set; }

        [JsonProperty("Pips")]
        public byte[] Pips { get; internal set; }

        [JsonProperty("FireGroup")]
        public byte FireGroup { get; internal set; }

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

        #region Equality members

        /// <inheritdoc />
        public bool Equals(StatusEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Flags == other.Flags
                   && CheckPips(Pips, other.Pips)
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

        private bool CheckPips(byte[] a, byte[] b)
        {
            if (a == null && b == null) return true;

            if (a != null && b == null) return false;

            if (a == null) return false;

            if (a.Length != b.Length) return false;

            return !a.Where((t, i) => t != b[i]).Any();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

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