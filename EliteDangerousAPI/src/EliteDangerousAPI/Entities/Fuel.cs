using System;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Fuel : IEquatable<Fuel>
    {
        [JsonProperty("FuelMain")]
        public double Main { get; internal set; }

        [JsonProperty("FuelReservoir")]
        public double Reservoir { get; internal set; }

        [JsonProperty("MaxFuel")]
        public double Max { get; internal set; }

        #region Equality members

        /// <inheritdoc />
        public bool Equals(Fuel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Main.Equals(other.Main) && Reservoir.Equals(other.Reservoir) && Max.Equals(other.Max);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fuel) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Main.GetHashCode();
                hashCode = (hashCode * 397) ^ Reservoir.GetHashCode();
                hashCode = (hashCode * 397) ^ Max.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}