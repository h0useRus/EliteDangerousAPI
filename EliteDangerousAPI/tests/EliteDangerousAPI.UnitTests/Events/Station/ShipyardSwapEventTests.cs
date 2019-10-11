using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardSwapEventTests
    {
        private const string EventName = "ShipyardSwap";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(ShipyardSwapEvent), e.EventType);
                Assert.IsType<ShipyardSwapEvent>(e.Event);
                AssertEvent((ShipyardSwapEvent)e.Event);
                globalFired = true;
            };

            api.StationEvents.ShipyardSwap += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipyardSwapEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(ShipyardSwapEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-07-21T14:36:06Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(ShipType.Sidewinder, @event.ShipType);
            Assert.Equal(2, @event.StoreShipId);
            Assert.Equal("Asp", @event.StoreOldShip);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-07-21T14:36:06Z\", \"event\":\"ShipyardSwap\", \"ShipType\":\"sidewinder\",\"ShipID\":10, \"StoreOldShip\":\"Asp\", \"StoreShipID\":2 } " }
            };
    }
}