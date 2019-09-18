using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class NewCommanderEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Player.NewCommander += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as NewCommanderEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(NewCommanderEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal("NewCommander", @event.Event);
            Assert.Equal("HRC1", @event.Name);
            Assert.Equal("F44396", @event.FrontierId);
            Assert.Equal("ImperialBountyHunter", @event.Package);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "NewCommander",  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"NewCommander\", \"Name\":\"HRC1\",\r\n\"FID\":\"F44396\", \"Package\":\"ImperialBountyHunter\" }" },
            };
    }
}