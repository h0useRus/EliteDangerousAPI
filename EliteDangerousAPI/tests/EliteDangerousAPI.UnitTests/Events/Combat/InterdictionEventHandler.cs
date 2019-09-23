using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class InterdictionEventHandler
    {
        private const string EventName = "Interdiction";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Combat.Interdiction += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as InterdictionEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(InterdictionEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Fred Flintstone", @event.Interdicted);
            Assert.Equal(CombatRank.Master, @event.CombatRank);
            Assert.True(@event.IsPlayer);
            Assert.True(@event.Success);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"Interdiction\", \"Success\":true, \"Interdicted\":\"Fred Flintstone\", \"IsPlayer\":true, \"CombatRank\":5 } " },
            };
    }
}