using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DockingCancelledEventTests
    {
        private const string EventName = "DockingCancelled";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Travel.DockingCancelled += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DockingCancelledEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(DockingCancelledEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T09:53:44Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Krikalev Hangar", @event.StationName);
            Assert.Equal("Outpost", @event.StationType);
            Assert.Equal(3223662592, @event.MarketId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T09:53:44Z\", \"event\":\"DockingCancelled\", \"StationName\":\"Krikalev Hangar\", \"StationType\":\"Outpost\", \"MarketID\":3223662592 }" },
            };
    }
}