using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class OutfittingEventTests
    {
        private const string EventName = "Outfitting";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Station.Outfitting += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as OutfittingEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(OutfittingEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T12:04:57Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(128675975, @event.MarketId);
            Assert.Equal("Demolition Unlimited", @event.StationName);
            Assert.Equal("Eurybia", @event.StarSystem);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T12:04:57Z\", \"event\":\"Outfitting\", \"MarketID\":128675975, \"StationName\":\"Demolition Unlimited\", \"StarSystem\":\"Eurybia\" }" },
            };
    }
}