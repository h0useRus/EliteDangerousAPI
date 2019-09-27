using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SellShipOnRebuyEventTests
    {
        private const string EventName = "SellShipOnRebuy";

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
                Assert.Equal(typeof(SellShipOnRebuyEvent), e.EventType);
                Assert.IsType<SellShipOnRebuyEvent>(e.Event);
                AssertEvent((SellShipOnRebuyEvent)e.Event);
                globalFired = true;
            };

            api.StationEvents.SellShipOnRebuy += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SellShipOnRebuyEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(SellShipOnRebuyEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-07-20T08:56:39Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Dolphin", @event.ShipType);
            Assert.Equal("Shinrarta Dezhra", @event.System);
            Assert.Equal(4, @event.SellShipId);
            Assert.Equal(4110183, @event.ShipPrice);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-07-20T08:56:39Z\", \"event\":\"SellShipOnRebuy\", \"ShipType\":\"Dolphin\",\"System\":\"Shinrarta Dezhra\", \"SellShipId\":4, \"ShipPrice\":4110183 } " }
            };
    }
}