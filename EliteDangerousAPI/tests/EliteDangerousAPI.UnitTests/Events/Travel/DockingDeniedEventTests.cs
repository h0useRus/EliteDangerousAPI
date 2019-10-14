using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DockingDeniedEventTests
    {
        private const string EventName = "DockingDenied";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.TravelEvents.DockingDenied += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DockingDeniedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(DockingDeniedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-02T13:42:18Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Chris & Silvia's Paradise Hideout", @event.StationName);
            Assert.Equal("Orbis", @event.StationType);
            Assert.Equal(128339960, @event.MarketId);
            Assert.Equal(DockingDeniedReason.Distance, @event.Reason);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-02T13:42:18Z\", \"event\":\"DockingDenied\", \"Reason\":\"Distance\", \"MarketID\":128339960, \"StationName\":\"Chris & Silvia's Paradise Hideout\", \"StationType\":\"Orbis\" }\r\n" },
            };
    }
}