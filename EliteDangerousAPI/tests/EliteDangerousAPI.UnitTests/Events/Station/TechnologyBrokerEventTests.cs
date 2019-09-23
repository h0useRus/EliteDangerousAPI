using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class TechnologyBrokerEventTests
    {
        private const string EventName = "TechnologyBroker";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(TechnologyBrokerEvent), e.EventType);
                Assert.IsType<TechnologyBrokerEvent>(e.Event);
                AssertEvent((TechnologyBrokerEvent)e.Event);
                globalFired = true;
            };

            api.Station.TechnologyBroker += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as TechnologyBrokerEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(TechnologyBrokerEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-03-02T11:28:44Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(128151032, @event.MarketId);
            Assert.Equal("Human", @event.BrokerType);
            Assert.Equal("Hpt_PlasmaShockCannon_Fixed_Medium", @event.ItemsUnlocked[0].Name);
            Assert.Equal("Shock Cannon", @event.ItemsUnlocked[0].NameLocalised);
            Assert.Equal("iondistributor", @event.Commodities[0].Name);
            Assert.Equal("Ion Distributor", @event.Commodities[0].NameLocalised);
            Assert.Equal(6, @event.Commodities[0].Count);
            Assert.Equal(4, @event.Materials.Length);
            Assert.Equal("vanadium", @event.Materials[0].Name);
            Assert.Equal(MaterialCategory.Raw, @event.Materials[0].Category);
            Assert.Equal(30, @event.Materials[0].Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-03-02T11:28:44Z\", \"event\":\"TechnologyBroker\", \"BrokerType\":\"Human\",\r\n\"MarketID\":128151032, \"ItemsUnlocked\":[{ \"Name\":\"Hpt_PlasmaShockCannon_Fixed_Medium\",\r\n\"Name_Localised\":\"Shock Cannon\" }], \"Commodities\":[{ \"Name\":\"iondistributor\",\r\n\"Name_Localised\":\"Ion Distributor\", \"Count\":6 }], \"Materials\":[ { \"Name\":\"vanadium\", \"Count\":30,\r\n\"Category\":\"Raw\" }, { \"Name\":\"tungsten\", \"Count\":30, \"Category\":\"Raw\" }, { \"Name\":\"rhenium\",\r\n\"Count\":36, \"Category\":\"Raw\" }, { \"Name\":\"technetium\", \"Count\":30, \"Category\":\"Raw\"}]} " }
            };
    }
}