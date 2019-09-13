using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalRewardEventTests
    {
        private const string EventName = "CommunityGoalReward";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Station.CommunityGoalReward += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CommunityGoalRewardEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(CommunityGoalRewardEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T13:20:28Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(726, @event.GoalId);
            Assert.Equal("Alliance Research Initiative – Trade", @event.Name);
            Assert.Equal("Kaushpoos", @event.System);
            Assert.Equal(123435, @event.Reward);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{\"timestamp\": \"2017-08-14T13:20:28Z\", \"event\": \"CommunityGoalReward\", \"CGID\": 726, \"Name\": \"Alliance Research Initiative – Trade\", \"System\": \"Kaushpoos\", \"Reward\": 123435}" },
            };
    }
}