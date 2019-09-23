using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SellExplorationDataEventTests
    {
        private const string EventName = "SellExplorationData";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Exploration.SellExplorationData += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SellExplorationDataEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private void AssertEvent(SellExplorationDataEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("HIP 78085", @event.Systems[0]);
            Assert.Equal("Praea Euq NW-W b1-3", @event.Systems[1]);
            Assert.Equal("HIP 78085 A", @event.Discovered[0]);
            Assert.Equal("Praea Euq NW-W b1-3", @event.Discovered[1]);
            Assert.Equal("Praea Euq NWW b1-3 3 a", @event.Discovered[2]);
            Assert.Equal("Praea Euq NW-W b1-3 3", @event.Discovered[3]);
            Assert.Equal(10822, @event.BaseValue);
            Assert.Equal(3959, @event.Bonus);
            Assert.Equal(44343, @event.TotalEarnings);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"SellExplorationData\", \"Systems\":[ \"HIP 78085\",\"Praea Euq NW-W b1-3\" ], \"Discovered\":[ \"HIP 78085 A\", \"Praea Euq NW-W b1-3\", \"Praea Euq NWW b1-3 3 a\", \"Praea Euq NW-W b1-3 3\" ], \"BaseValue\":10822, \"Bonus\":3959, \"TotalEarnings\":44343 }" },
            };
    }
}