using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CrewAssignEventTests
    {
        private const string EventName = "CrewAssign";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Crew.CrewAssign += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CrewAssignEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(CrewAssignEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-08-09T08:45:31Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Dannie Koller", @event.Name);
            Assert.Equal("Active", @event.Role);
            Assert.Equal(0, @event.CrewId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-08-09T08:45:31Z\", \"event\":\"CrewAssign\", \"Name\":\"Dannie Koller\", \"Role\":\"Active\" }" },
            };
    }
}