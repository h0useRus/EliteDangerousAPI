using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class HullDamageEventTests
    {
        private const string EventName = "HullDamage";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Combat.HullDamage += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as HullDamageEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(HullDamageEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-04T14:28:51Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(0.798078, @event.Health, 6);
            Assert.True(@event.PlayerPilot);
            Assert.True(@event.Fighter);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-04T14:28:51Z\", \"event\":\"HullDamage\", \"Health\":0.798078, \"PlayerPilot\":true, \"Fighter\":true }" },
            };
    }
}