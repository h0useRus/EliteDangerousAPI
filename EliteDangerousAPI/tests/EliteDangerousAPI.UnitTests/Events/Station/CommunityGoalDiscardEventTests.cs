using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalDiscardEventTests
    {
        private const string EventName = "CommunityGoalDiscard";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.CommunityGoalDiscard += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CommunityGoalDiscardEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(CommunityGoalDiscardEvent @event)
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
                new object[] { EventName,  "{\"timestamp\": \"2017-08-14T13:20:28Z\", \"event\": \"CommunityGoalDiscard\", \"CGID\": 726, \"Name\": \"Alliance Research Initiative – Trade\", \"System\": \"Kaushpoos\"}" },
            };
    }
}