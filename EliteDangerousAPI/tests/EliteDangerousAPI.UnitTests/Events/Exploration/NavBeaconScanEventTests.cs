using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class NavBeaconScanEventTests
    {
        private const string EventName = "NavBeaconScan";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Exploration.NavBeaconScan += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as NavBeaconScanEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private void AssertEvent(NavBeaconScanEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T12:12:05Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(670148994409, @event.SystemAddress);
            Assert.Equal(17, @event.NumBodies);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T12:12:05Z\", \"event\":\"NavBeaconScan\", \"SystemAddress\":670148994409, \"NumBodies\":17 }" },
            };
    }
}