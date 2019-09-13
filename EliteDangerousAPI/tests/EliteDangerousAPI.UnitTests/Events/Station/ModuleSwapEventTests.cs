using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ModuleSwapEventTests
    {
        private const string EventName = "ModuleSwap";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Station.ModuleSwap += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ModuleSwapEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(ModuleSwapEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-01T13:18:14Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3223388416, @event.MarketId);
            Assert.Equal(2, @event.ShipId);
            Assert.Equal("cobramkiii", @event.Ship);
            Assert.Equal("Slot03_Size4", @event.FromSlot);
            Assert.Equal("Slot02_Size4", @event.ToSlot);
            Assert.Equal("$int_fuelscoop_size4_class3_name;", @event.FromItem);
            Assert.Equal("Топливозаборник", @event.FromItemLocalised);
            Assert.Equal("$int_cargorack_size4_class1_name;", @event.ToItem);
            Assert.Equal("Груз. стеллаж", @event.ToItemLocalised);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-01T13:18:14Z\", \"event\":\"ModuleSwap\", \"MarketID\":3223388416, \"FromSlot\":\"Slot03_Size4\", \"ToSlot\":\"Slot02_Size4\", \"FromItem\":\"$int_fuelscoop_size4_class3_name;\", \"FromItem_Localised\":\"Топливозаборник\", \"ToItem\":\"$int_cargorack_size4_class1_name;\", \"ToItem_Localised\":\"Груз. стеллаж\", \"Ship\":\"cobramkiii\", \"ShipID\":2 }" },
            };
    }
}