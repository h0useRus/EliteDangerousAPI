using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MarketEventTests
    {
        private const string EventName = "Market";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Station.Market += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MarketEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(MarketEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T12:28:18Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3510937344, @event.MarketId);
            Assert.Equal("Arnold Bastion", @event.StationName);
            Assert.Equal("Potrigua", @event.StarSystem);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T12:28:18Z\", \"event\":\"Market\", \"MarketID\":3510937344, \"StationName\":\"Arnold Bastion\", \"StarSystem\":\"Potrigua\" }" },
            };
    }
}