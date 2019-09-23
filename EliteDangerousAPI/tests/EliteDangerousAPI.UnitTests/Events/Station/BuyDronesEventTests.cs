using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class BuyDronesEventTests
    {
        private const string EventName = "BuyDrones";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.BuyDrones += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as BuyDronesEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private void AssertEvent(BuyDronesEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-01T13:27:58Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Drones", @event.Type);
            Assert.Equal(4, @event.Count);
            Assert.Equal(101, @event.BuyPrice);
            Assert.Equal(404, @event.TotalCost);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-01T13:27:58Z\", \"event\":\"BuyDrones\", \"Type\":\"Drones\", \"Count\":4, \"BuyPrice\":101, \"TotalCost\":404 }" },
            };
    }
}