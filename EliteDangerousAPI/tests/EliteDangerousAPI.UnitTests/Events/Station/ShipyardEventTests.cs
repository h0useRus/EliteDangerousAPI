using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardEventTests
    {
        private const string EventName = "Shipyard";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(ShipyardEvent), e.EventType);
                Assert.IsType<ShipyardEvent>(e.Event);
                AssertEvent((ShipyardEvent)e.Event);
                globalFired = true;
            };

            api.Station.Shipyard += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipyardEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(ShipyardEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T13:42:34Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Mawson Dock", @event.StationName);
            Assert.Equal(128932277, @event.MarketId);
            Assert.Equal("Dromi", @event.StarSystem);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T13:42:34Z\", \"event\":\"Shipyard\", \"MarketID\":128932277, \"StationName\":\"Mawson Dock\", \"StarSystem\":\"Dromi\" }" }
            };
    }
}