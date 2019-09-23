using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using NSW.EliteDangerous.API.Exceptions;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class OutfittingEventTests
    {
        private const string EventName = "Outfitting";

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
                Assert.Equal("outfitting", e.EventName);
                Assert.Equal(typeof(OutfittingEvent), e.EventType);
                Assert.IsType<OutfittingEvent>(e.Event);
                AssertEvent((OutfittingEvent)e.Event);
                globalFired = true;
            };

            api.Station.Outfitting += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as OutfittingEvent);
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
                Assert.Equal("outfitting", e.EventName);
                Assert.Equal(typeof(OutfittingEvent), e.EventType);
                Assert.IsType<OutfittingEvent>(e.Event);
                AssertFileEvent((OutfittingEvent)e.Event);
                globalFired = true;
            };

            api.Station.Outfitting += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertFileEvent(@event);
                eventFired = true;
            };

            api.Warnings += (sender, exception) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                Assert.IsType<JournalEventConsistencyException<OutfittingEvent>>(exception);

                AssertEvent(((JournalEventConsistencyException<OutfittingEvent>)exception).FromJournal);
                AssertFileEvent(((JournalEventConsistencyException<OutfittingEvent>)exception).FromFile);
            };

            Assert.True(api.HasEvent(eventName));
            AssertFileEvent(api.ExecuteEvent(eventName, json) as OutfittingEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(OutfittingEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T12:04:57Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(128675975, @event.MarketId);
            Assert.Equal("Demolition Unlimited", @event.StationName);
            Assert.Equal("Eurybia", @event.StarSystem);
        }

        private static void AssertFileEvent(OutfittingEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:23:48Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3223641856, @event.MarketId);
            Assert.Equal("Nagel City", @event.StationName);
            Assert.Equal("Scylla", @event.StarSystem);
            Assert.True(@event.Horizons);
            Assert.Equal(259, @event.Items.Length);

            Assert.Equal(128049445, @event.Items[0].Id);
            Assert.Equal("hpt_cannon_turret_small", @event.Items[0].Name);
            Assert.Equal(506400, @event.Items[0].BuyPrice);

            Assert.Equal(128064085, @event.Items[258].Id);
            Assert.Equal("int_engine_size5_class3", @event.Items[258].Name);
            Assert.Equal(567106, @event.Items[258].BuyPrice);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T12:04:57Z\", \"event\":\"Outfitting\", \"MarketID\":128675975, \"StationName\":\"Demolition Unlimited\", \"StarSystem\":\"Eurybia\" }" },
            };
    }
}