using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ModuleStoreEventTests
    {
        private const string EventName = "ModuleStore";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.ModuleStore += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ModuleStoreEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(ModuleStoreEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-01T12:56:39Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3223388416, @event.MarketId);
            Assert.Equal(2, @event.ShipId);
            Assert.Equal("adder", @event.Ship);
            Assert.Equal("MediumHardpoint1", @event.Slot);
            Assert.Equal("$hpt_multicannon_gimbal_medium_name;", @event.StoredItem);
            Assert.Equal("Многоствольное орудие", @event.StoredItemLocalised);
            Assert.False(@event.Hot);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-01T12:56:39Z\", \"event\":\"ModuleStore\", \"MarketID\":3223388416, \"Slot\":\"MediumHardpoint1\", \"StoredItem\":\"$hpt_multicannon_gimbal_medium_name;\", \"StoredItem_Localised\":\"Многоствольное орудие\", \"Ship\":\"adder\", \"ShipID\":2, \"Hot\":false }" },
            };
    }
}