using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardBuyEventTests
    {
        private const string EventName = "ShipyardBuy";

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
                Assert.Equal(typeof(ShipyardBuyEvent), e.EventType);
                Assert.IsType<ShipyardBuyEvent>(e.Event);
                AssertEvent((ShipyardBuyEvent)e.Event);
                globalFired = true;
            };

            api.Station.ShipyardBuy += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipyardBuyEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(ShipyardBuyEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-30T14:10:31Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("adder", @event.ShipType);
            Assert.Equal(87808, @event.ShipPrice);
            Assert.Equal("SideWinder", @event.StoreOldShip);
            Assert.Equal(0, @event.StoreShipId);
            Assert.Equal(3223919616, @event.MarketId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-30T14:10:31Z\", \"event\":\"ShipyardBuy\", \"ShipType\":\"adder\", \"ShipPrice\":87808, \"StoreOldShip\":\"SideWinder\", \"StoreShipID\":0, \"MarketID\":3223919616 }" }
            };
    }
}