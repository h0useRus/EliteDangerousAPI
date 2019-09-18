using System;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Fuel : IEquatable<Fuel>
    {
        [JsonProperty("FuelMain")]
        public double FuelMain { get; internal set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; internal set; }

        [JsonProperty("MaxFuel")]
        public double MaxFuel { get; internal set; }

        #region Equality members

        /// <inheritdoc />
        public bool Equals(Fuel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FuelMain.Equals(other.FuelMain) && FuelReservoir.Equals(other.FuelReservoir) && MaxFuel.Equals(other.MaxFuel);
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
                var hashCode = FuelMain.GetHashCode();
                hashCode = (hashCode * 397) ^ FuelReservoir.GetHashCode();
                hashCode = (hashCode * 397) ^ MaxFuel.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}