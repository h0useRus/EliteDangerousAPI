using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardSellEventTests
    {
        private const string EventName = "ShipyardSell";

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
                Assert.Equal(typeof(ShipyardSellEvent), e.EventType);
                Assert.IsType<ShipyardSellEvent>(e.Event);
                AssertEvent((ShipyardSellEvent)e.Event);
                globalFired = true;
            };

            api.Station.ShipyardSell += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipyardSellEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(ShipyardSellEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-07-21T15:12:19Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("adder", @event.ShipType);
            Assert.Equal(6, @event.SellShipId);
            Assert.Equal(79027, @event.ShipPrice);
            Assert.Equal("Eranin", @event.System);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-07-21T15:12:19Z\", \"event\":\"ShipyardSell\", \"ShipType\":\"adder\", \"SellShipID\":6,\"ShipPrice\":79027, \"System\":\"Eranin\" }" }
            };
    }
}