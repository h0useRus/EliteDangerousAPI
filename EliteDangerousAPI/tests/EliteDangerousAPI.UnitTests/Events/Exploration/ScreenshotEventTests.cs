using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ScreenshotEventTests
    {
        private const string EventName = "Screenshot";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Exploration.Screenshot += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ScreenshotEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private void AssertEvent(ScreenshotEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-01-17T09:48:26Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("_Screenshots/Screenshot_0024.bmp", @event.Filename);
            Assert.Equal(1440, @event.Width);
            Assert.Equal(900, @event.Height);
            Assert.Equal("Nuenets", @event.System);
            Assert.Equal("Nuenets C 2", @event.Body);
            Assert.Equal(39, @event.Heading);
            Assert.Equal(-60.799900, @event.Latitude, 6);
            Assert.Equal(-74.059799, @event.Longitude, 6);
            Assert.Equal(27502.876953, @event.Altitude, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-01-17T09:48:26Z\", \"event\":\"Screenshot\",\r\n\"Filename\":\"_Screenshots/Screenshot_0024.bmp\", \"Width\":1440, \"Height\":900,\r\n\"System\":\"Nuenets\", \"Body\":\"Nuenets C 2\", \"Latitude\":-60.799900, \"Longitude\":-74.059799,\"Heading\":39, \"Altitude\":27502.876953 } " },
            };
    }
}