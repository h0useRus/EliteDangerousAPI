using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FuelScoopEventTests
    {
        private const string EventName = "FuelScoop";

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
                Assert.Equal(typeof(FuelScoopEvent), e.EventType);
                Assert.IsType<FuelScoopEvent>(e.Event);
                AssertEvent((FuelScoopEvent)e.Event);
                globalFired = true;
            };

            api.ShipEvents.FuelScoop += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FuelScoopEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(FuelScoopEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-31T13:42:18Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(0.624539, @event.Scooped, 6);
            Assert.Equal(8.000000, @event.Total, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-31T13:42:18Z\", \"event\":\"FuelScoop\", \"Scooped\":0.624539, \"Total\":8.000000 }" }
            };
    }
}