using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class AsteroidCrackedEventTests
    {
        private const string EventName = "AsteroidCracked";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Trade.AsteroidCracked += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as AsteroidCrackedEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(AsteroidCrackedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T11:30:48Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Asteroid 1", @event.Body);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T11:30:48Z\", \"event\":\"AsteroidCracked\", \"Body\":\"Asteroid 1\" }" },
            };
    }
}