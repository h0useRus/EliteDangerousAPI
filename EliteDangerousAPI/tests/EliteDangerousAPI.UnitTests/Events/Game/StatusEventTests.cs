using System;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class StatusEventTests
    {
        [Fact]
        public void ShouldRunOnStartEvent()
        {
            var api = TestHelpers.FilesApi;
            var eventFired = false;
            api.Game.Status += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            api.Start();
            Assert.True(eventFired);

            api.Stop();
        }

        private static void AssertEvent(StatusEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-12-07T12:03:14Z"), @event.Timestamp);
            Assert.Equal("Status", @event.Event);
        }
    }
}