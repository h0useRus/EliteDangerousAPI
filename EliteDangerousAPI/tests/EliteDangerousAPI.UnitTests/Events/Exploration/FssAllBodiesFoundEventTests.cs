using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FssAllBodiesFoundEventTests
    {
        private const string EventName = "FSSAllBodiesFound";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.ExplorationEvents.FssAllBodiesFound += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FssAllBodiesFoundEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(FssAllBodiesFoundEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T11:08:04Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Hyades Sector IM-L b8-5", @event.SystemName);
            Assert.Equal(11667412755841, @event.SystemAddress);
            Assert.Equal(8, @event.Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T11:08:04Z\", \"event\":\"FSSAllBodiesFound\", \"SystemName\":\"Hyades Sector IM-L b8-5\", \"SystemAddress\":11667412755841, \"Count\":8 }" },
            };
    }
}