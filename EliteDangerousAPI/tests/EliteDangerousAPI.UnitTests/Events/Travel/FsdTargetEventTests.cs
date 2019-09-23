using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FsdTargetEventTests
    {
        private const string EventName = "FSDTarget";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Travel.FsdTarget += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FsdTargetEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(FsdTargetEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-07T12:33:49Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Wailaroju", @event.Name);
            Assert.Equal(2346956343651, @event.SystemAddress);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-07T12:33:49Z\", \"event\":\"FSDTarget\", \"Name\":\"Wailaroju\", \"SystemAddress\":2346956343651 }\r\n" },
            };
    }
}