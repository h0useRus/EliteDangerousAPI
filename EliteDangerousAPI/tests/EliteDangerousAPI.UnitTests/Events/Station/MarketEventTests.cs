using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Exceptions;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MarketEventTests
    {
        private const string EventName = "Market";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(MarketEvent), e.EventType);
                Assert.IsType<MarketEvent>(e.Event);
                AssertEvent((MarketEvent)e.Event);
                globalFired = true;
            };

            api.Station.Market += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MarketEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldReadFileEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.FilesApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(MarketEvent), e.EventType);
                Assert.IsType<MarketEvent>(e.Event);
                AssertFileEvent((MarketEvent)e.Event);
                globalFired = true;
            };

            api.Station.Market += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertFileEvent(@event);
                eventFired = true;
            };

            api.Warnings += (sender, exception) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                Assert.IsType<JournalEventConsistencyException<MarketEvent>>(exception);

                AssertEvent(((JournalEventConsistencyException<MarketEvent>)exception).FromJournal);
                AssertFileEvent(((JournalEventConsistencyException<MarketEvent>)exception).FromFile);
            };

            Assert.True(api.HasEvent(eventName));
            AssertFileEvent(api.ExecuteEvent(eventName, json) as MarketEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(MarketEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T12:28:18Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3510937344, @event.MarketId);
            Assert.Equal("Arnold Bastion", @event.StationName);
            Assert.Equal("Potrigua", @event.StarSystem);
        }

        private static void AssertFileEvent(MarketEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-07T12:48:31Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3511645184, @event.MarketId);
            Assert.Equal("Michell Depot", @event.StationName);
            Assert.Equal("Eurybia", @event.StarSystem);
            Assert.Equal(96, @event.Items.Length);

            Assert.Equal(128049152, @event.Items[0].Id);
            Assert.Equal("$platinum_name;", @event.Items[0].Name);
            Assert.Equal("Платина", @event.Items[0].NameLocalised);
            Assert.Equal("$MARKET_category_metals;", @event.Items[0].Category);
            Assert.Equal("Металлы", @event.Items[0].CategoryLocalised);
            Assert.Equal(0, @event.Items[0].BuyPrice);
            Assert.Equal(56471, @event.Items[0].SellPrice);
            Assert.Equal(42494, @event.Items[0].MeanPrice);
            Assert.Equal(0, @event.Items[0].StockBracket);
            Assert.Equal(3, @event.Items[0].DemandBracket);
            Assert.Equal(0, @event.Items[0].Stock);
            Assert.Equal(5053, @event.Items[0].Demand);
            Assert.True(@event.Items[0].Consumer);
            Assert.False(@event.Items[0].Producer);
            Assert.False(@event.Items[0].Rare);

            Assert.Equal(128924332, @event.Items[95].Id);
            Assert.Equal("$opal_name;", @event.Items[95].Name);
            Assert.Equal("Опалы бездны", @event.Items[95].NameLocalised);
            Assert.Equal("$MARKET_category_minerals;", @event.Items[95].Category);
            Assert.Equal("Минералы", @event.Items[95].CategoryLocalised);
            Assert.Equal(0, @event.Items[95].BuyPrice);
            Assert.Equal(753733, @event.Items[95].SellPrice);
            Assert.Equal(182168, @event.Items[95].MeanPrice);
            Assert.Equal(0, @event.Items[95].StockBracket);
            Assert.Equal(1, @event.Items[95].DemandBracket);
            Assert.Equal(0, @event.Items[95].Stock);
            Assert.Equal(1, @event.Items[95].Demand);
            Assert.True(@event.Items[95].Consumer);
            Assert.False(@event.Items[95].Producer);
            Assert.False(@event.Items[95].Rare);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T12:28:18Z\", \"event\":\"Market\", \"MarketID\":3510937344, \"StationName\":\"Arnold Bastion\", \"StarSystem\":\"Potrigua\" }" },
            };
    }
}