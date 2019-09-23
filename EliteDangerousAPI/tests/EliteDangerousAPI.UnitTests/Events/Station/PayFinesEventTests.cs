using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class PayFinesEventTests
    {
        private const string EventName = "PayFines";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(PayFinesEvent), e.EventType);
                Assert.IsType<PayFinesEvent>(e.Event);
            };

            api.Station.PayFines += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as PayFinesEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(PayFinesEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-03-19T10:24:21Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(250, @event.Amount);
            Assert.Equal("Batz Transport Commodities", @event.Faction);
            Assert.False(@event.AllFines);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-03-19T10:24:21Z\", \"event\":\"PayFines\", \"Amount\":250, \"AllFines\":false,\"Faction\":\"Batz Transport Commodities\", \"ShipID\":9 }" },
            };
    }
}