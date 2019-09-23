using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ProgressEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Player.Progress += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ProgressEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(ProgressEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal("Progress", @event.Event);
            Assert.Equal(77, @event.Combat);
            Assert.Equal(9, @event.Trade);
            Assert.Equal(93, @event.Explore);
            Assert.Equal(10, @event.Empire);
            Assert.Equal(45, @event.Federation);
            Assert.Equal(1, @event.Cqc);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Progress",  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"Progress\", \"Combat\":77, \"Trade\":9, \"Explore\":93,\r\n\"Empire\":10, \"Federation\":45, \"CQC\":1 }" },
            };
    }
}