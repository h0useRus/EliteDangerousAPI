using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MissionFailedEventTests
    {
        private const string EventName = "MissionFailed";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.MissionFailed += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MissionFailedEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(MissionFailedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(65343025, @event.MissionId);
            Assert.Equal("Mission_Collect_name", @event.Name);
            Assert.Equal(1000, @event.Fine);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"MissionFailed\",\"Name\":\"Mission_Collect_name\", \"MissionID\":65343025, \"Fine\":1000 }" },
            };
    }
}