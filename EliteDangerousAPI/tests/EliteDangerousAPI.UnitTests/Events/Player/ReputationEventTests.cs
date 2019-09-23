using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ReputationEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Player.Reputation += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ReputationEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(ReputationEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T09:53:32Z"), @event.Timestamp);
            Assert.Equal("Reputation", @event.Event);
            Assert.Equal(2.830170, @event.Empire, 6);
            Assert.Equal(3.797780, @event.Federation, 6);
            Assert.Equal(0, @event.Alliance, 6);
            Assert.Equal(0, @event.Independent, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Reputation",  "{ \"timestamp\":\"2019-09-08T09:53:32Z\", \"event\":\"Reputation\", \"Empire\":2.830170, \"Federation\":3.797780 }\r\n" },
            };
    }
}