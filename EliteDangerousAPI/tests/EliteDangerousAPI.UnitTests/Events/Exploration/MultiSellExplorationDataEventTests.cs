using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MultiSellExplorationDataEventTests
    {
        private const string EventName = "MultiSellExplorationData";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Exploration.MultiSellExplorationData += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MultiSellExplorationDataEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(MultiSellExplorationDataEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T09:58:16Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(string.Empty, @event.Discovered[0].SystemName);
            Assert.Equal(4, @event.Discovered[0].NumBodies);
            Assert.Equal("Puppis Sector DL-P a5-3", @event.Discovered[1].SystemName);
            Assert.Equal(5, @event.Discovered[1].NumBodies);
            Assert.Equal(12405, @event.BaseValue);
            Assert.Equal(0, @event.Bonus);
            Assert.Equal(12405, @event.TotalEarnings);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T09:58:16Z\", \"event\":\"MultiSellExplorationData\", \"Discovered\":[ { \"SystemName\":\"\", \"NumBodies\":4 }, { \"SystemName\":\"Puppis Sector DL-P a5-3\", \"NumBodies\":5 } ], \"BaseValue\":12405, \"Bonus\":0, \"TotalEarnings\":12405 }" },
            };
    }
}