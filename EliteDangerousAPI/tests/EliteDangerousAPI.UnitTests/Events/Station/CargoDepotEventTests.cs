using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CargoDepotEventTests
    {
        private const string EventName = "CargoDepot";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.StationEvents.CargoDepot += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CargoDepotEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private void AssertEvent(CargoDepotEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:25:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(508888377, @event.MissionId);
            Assert.Equal(CargoUpdateType.Collect, @event.UpdateType);
            Assert.Equal("Superconductors", @event.CargoType);
            Assert.Equal("Сверхпроводники", @event.CargoTypeLocalised);
            Assert.Equal(3223641856, @event.StartMarketId);
            Assert.Equal(3223642368, @event.EndMarketId);
            Assert.Equal(45, @event.Count);
            Assert.Equal(45, @event.ItemsCollected);
            Assert.Equal(0, @event.ItemsDelivered);
            Assert.Equal(45, @event.TotalItemsToDeliver);
            Assert.Equal(1.000000, @event.Progress, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T10:25:03Z\", \"event\":\"CargoDepot\", \"MissionID\":508888377, \"UpdateType\":\"Collect\", \"CargoType\":\"Superconductors\", \"CargoType_Localised\":\"Сверхпроводники\", \"Count\":45, \"StartMarketID\":3223641856, \"EndMarketID\":3223642368, \"ItemsCollected\":45, \"ItemsDelivered\":0, \"TotalItemsToDeliver\":45, \"Progress\":1.000000 }" },
            };
    }
}