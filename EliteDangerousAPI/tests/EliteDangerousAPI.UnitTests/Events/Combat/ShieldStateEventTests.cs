using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShieldStateEventTests
    {
        private const string EventName = "ShieldState";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Combat.ShieldState += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShieldStateEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(ShieldStateEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-07-25T14:46:36Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.True(@event.ShieldsUp);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-07-25T14:46:36Z\", \"event\":\"ShieldState\", \"ShieldsUp\":true }" },
            };
    }
}