using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Exceptions;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardEventTests
    {
        private const string EventName = "Shipyard";

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
                Assert.Equal(typeof(ShipyardEvent), e.EventType);
                Assert.IsType<ShipyardEvent>(e.Event);
                AssertEvent((ShipyardEvent)e.Event);
                globalFired = true;
            };

            api.Station.Shipyard += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipyardEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldReadFileEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.FilesApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(ShipyardEvent), e.EventType);
                Assert.IsType<ShipyardEvent>(e.Event);
                AssertFileEvent((ShipyardEvent)e.Event);
                globalFired = true;
            };

            api.Station.Shipyard += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertFileEvent(@event);
                eventFired = true;
            };

            api.Warnings += (sender, exception) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                Assert.IsType<JournalEventConsistencyException<ShipyardEvent>>(exception);

                AssertEvent(((JournalEventConsistencyException<ShipyardEvent>)exception).FromJournal);
                AssertFileEvent(((JournalEventConsistencyException<ShipyardEvent>)exception).FromFile);
            };

            Assert.True(api.HasEvent(eventName));
            AssertFileEvent(api.ExecuteEvent(eventName, json) as ShipyardEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(ShipyardEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T13:42:34Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Mawson Dock", @event.StationName);
            Assert.Equal(128932277, @event.MarketId);
            Assert.Equal("Dromi", @event.StarSystem);
        }

        private static void AssertFileEvent(ShipyardEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-01T13:03:07Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Wrangell Dock", @event.StationName);
            Assert.Equal(3223388416, @event.MarketId);
            Assert.Equal("Ross 584", @event.StarSystem);
            Assert.True(@event.Horizons);
            Assert.False(@event.AllowCobraMkIV);
            Assert.Equal(15, @event.Prices.Length);

            Assert.Equal(128049249, @event.Prices[0].Id);
            Assert.Equal("sidewinder", @event.Prices[0].ShipType);
            Assert.Null(@event.Prices[0].ShipTypeLocalised);
            Assert.Equal(27200, @event.Prices[0].ShipPrice);

            Assert.Equal(128049333, @event.Prices[14].Id);
            Assert.Equal("type9", @event.Prices[14].ShipType);
            Assert.Equal("Type-9 Heavy", @event.Prices[14].ShipTypeLocalised);
            Assert.Equal(65072466, @event.Prices[14].ShipPrice);

        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T13:42:34Z\", \"event\":\"Shipyard\", \"MarketID\":128932277, \"StationName\":\"Mawson Dock\", \"StarSystem\":\"Dromi\" }" }
            };
    }
}