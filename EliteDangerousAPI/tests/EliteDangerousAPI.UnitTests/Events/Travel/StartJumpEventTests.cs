using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class StartJumpEventTests
    {
        private const string EventName = "StartJump";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.TravelEvents.StartJump += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as StartJumpEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(StartJumpEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T09:59:57Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(JumpType.Hyperspace, @event.JumpType);
            Assert.Equal("Scylla", @event.StarSystem);
            Assert.Equal(2008064955082, @event.SystemAddress);
            Assert.Equal("G", @event.StarClass);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T09:59:57Z\", \"event\":\"StartJump\", \"JumpType\":\"Hyperspace\", \"StarSystem\":\"Scylla\", \"SystemAddress\":2008064955082, \"StarClass\":\"G\" }" },
            };
    }
}