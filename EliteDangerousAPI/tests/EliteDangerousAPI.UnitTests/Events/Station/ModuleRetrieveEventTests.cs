using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ModuleRetrieveEventTests
    {
        private const string EventName = "ModuleRetrieve";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.StationEvents.ModuleRetrieve += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ModuleRetrieveEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(ModuleRetrieveEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-01T13:09:19Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("MediumHardpoint1", @event.Slot);
            Assert.Equal(2, @event.ShipId);
            Assert.Equal(ShipType.CobraMkIII, @event.ShipType);
            Assert.Equal(3223388416, @event.MarketId);
            Assert.Equal("$hpt_multicannon_gimbal_medium_name;", @event.RetrievedItem);
            Assert.Equal("Многоствольное орудие", @event.RetrievedItemLocalised);
            Assert.False(@event.Hot);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-01T13:09:19Z\", \"event\":\"ModuleRetrieve\", \"MarketID\":3223388416, \"Slot\":\"MediumHardpoint1\", \"RetrievedItem\":\"$hpt_multicannon_gimbal_medium_name;\", \"RetrievedItem_Localised\":\"Многоствольное орудие\", \"Ship\":\"cobramkiii\", \"ShipID\":2, \"Hot\":false }" },
            };
    }
}