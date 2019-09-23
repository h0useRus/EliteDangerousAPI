using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SaaScanCompleteEventTests
    {
        private const string EventName = "SAAScanComplete";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Exploration.SaaScanComplete += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SaaScanCompleteEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private void AssertEvent(SaaScanCompleteEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T12:43:57Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("HIP 15329 A 3 c", @event.BodyName);
            Assert.Equal(38, @event.BodyId);
            Assert.Equal(5, @event.ProbesUsed);
            Assert.Equal(4, @event.EfficiencyTarget);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T12:43:57Z\", \"event\":\"SAAScanComplete\", \"BodyName\":\"HIP 15329 A 3 c\", \"BodyID\":38, \"ProbesUsed\":5, \"EfficiencyTarget\":4 }" },
            };
    }
}