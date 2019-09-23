using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CommanderEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Player.Commander += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CommanderEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(CommanderEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal("Commander", @event.Event);
            Assert.Equal("HRC1", @event.Name);
            Assert.Equal("F44396", @event.FrontierId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Commander",  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"Commander\", \"Name\":\"HRC1\",\r\n\"FID\":\"F44396\" } " },
            };
    }
}