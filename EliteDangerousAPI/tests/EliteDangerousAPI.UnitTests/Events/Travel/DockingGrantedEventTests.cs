using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DockingGrantedEventTests
    {
        private const string EventName = "DockingGranted";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Travel.DockingGranted += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DockingGrantedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(DockingGrantedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-31T12:28:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Martin Silo", @event.StationName);
            Assert.Equal("CraterOutpost", @event.StationType);
            Assert.Equal(3512711680, @event.MarketId);
            Assert.Equal(2, @event.LandingPad);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-31T12:28:03Z\", \"event\":\"DockingGranted\", \"LandingPad\":2, \"MarketID\":3512711680, \"StationName\":\"Martin Silo\", \"StationType\":\"CraterOutpost\" }" },
            };
    }
}