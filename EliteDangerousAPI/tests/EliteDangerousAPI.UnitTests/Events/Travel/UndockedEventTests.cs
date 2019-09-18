using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class UndockedEventTests
    {
        private const string EventName = "Undocked";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Travel.Undocked += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as UndockedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(UndockedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-01T12:39:17Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Chris & Silvia's Paradise Hideout", @event.StationName);
            Assert.Equal("Orbis", @event.StationType);
            Assert.Equal(128339960, @event.MarketId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-01T12:39:17Z\", \"event\":\"Undocked\", \"StationName\":\"Chris & Silvia's Paradise Hideout\", \"StationType\":\"Orbis\", \"MarketID\":128339960 }" },
            };
    }
}