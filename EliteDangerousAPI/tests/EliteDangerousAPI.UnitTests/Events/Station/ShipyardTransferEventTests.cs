using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardTransferEventTests
    {
        private const string EventName = "ShipyardTransfer";

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
                Assert.Equal(typeof(ShipyardTransferEvent), e.EventType);
                Assert.IsType<ShipyardTransferEvent>(e.Event);
                AssertEvent((ShipyardTransferEvent)e.Event);
                globalFired = true;
            };

            api.StationEvents.ShipyardTransfer += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipyardTransferEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(ShipyardTransferEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-07-21T15:19:49Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("SideWinder", @event.ShipType);
            Assert.Equal(ShipModel.Sidewinder, @event.ShipModel);
            Assert.Equal(7, @event.ShipId);
            Assert.Equal(580, @event.TransferPrice);
            Assert.Equal("Eranin", @event.System);
            Assert.Equal(85.639145, @event.Distance, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-07-21T15:19:49Z\", \"event\":\"ShipyardTransfer\", \"ShipType\":\"SideWinder\", \"ShipID\":7, \"System\":\"Eranin\", \"Distance\":85.639145, \"TransferPrice\":580 }" }
            };
    }
}