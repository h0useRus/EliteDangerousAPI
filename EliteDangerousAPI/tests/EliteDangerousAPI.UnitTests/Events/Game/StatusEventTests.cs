using System;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
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
            api.GameEvents.Status += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
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
            Assert.Equal(DateTime.Parse("2019-10-03T11:42:45Z"), @event.Timestamp);
            Assert.Equal("Status", @event.Event);
            Assert.Equal(153157645, (int)@event.Flags);
            Assert.Equal(new byte[] { 4, 8, 0 }, @event.Pips);
            Assert.Equal(2, @event.FireGroup);
            Assert.Equal(GuiFocus.NoFocus, @event.GuiFocus);
            Assert.Equal(24.828249, @event.Fuel.Main, 6);
            Assert.Equal(0.392130, @event.Fuel.Reservoir, 6);
            Assert.Equal(0.000000, @event.Cargo, 6);
            Assert.Equal(0.000000, @event.Cargo, 6);
            Assert.Equal(LegalState.Clean, @event.LegalState);
            Assert.Equal(74.000931, @event.Latitude, 6);
            Assert.Equal(143.452332, @event.Longitude, 6);
            Assert.Equal(0, @event.Heading);
            Assert.Equal(0, @event.Altitude);
        }
    }
}