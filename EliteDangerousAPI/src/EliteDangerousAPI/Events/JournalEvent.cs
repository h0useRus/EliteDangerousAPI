using System;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class JournalEvent : IEquatable<JournalEvent>
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        public override string ToString() => Event;

        #region Equality members

        /// <inheritdoc />
        public bool Equals(JournalEvent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Timestamp.Equals(other.Timestamp) && string.Equals(Event, other.Event, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((JournalEvent) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (Timestamp.GetHashCode() * 397) ^ (Event != null ? Event.GetHashCode() : 0);
            }
        }

        #endregion
    }
}