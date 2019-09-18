using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class UnderAttackEventTests
    {
        private const string EventName = "UnderAttack";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Combat.UnderAttack += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as UnderAttackEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(UnderAttackEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T13:42:02Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("You", @event.Target);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T13:42:02Z\", \"event\":\"UnderAttack\", \"Target\":\"You\" }" },
            };
    }
}