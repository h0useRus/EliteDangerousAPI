using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalJoinEventTests
    {
        private const string EventName = "CommunityGoalJoin";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.CommunityGoalJoin += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CommunityGoalJoinEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(CommunityGoalJoinEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T13:20:28Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(726, @event.GoalId);
            Assert.Equal("Alliance Research Initiative – Trade", @event.Name);
            Assert.Equal("Kaushpoos", @event.System);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{\"timestamp\": \"2017-08-14T13:20:28Z\", \"event\": \"CommunityGoalJoin\", \"CGID\": 726, \"Name\": \"Alliance Research Initiative – Trade\", \"System\": \"Kaushpoos\"}" },
            };
    }
}