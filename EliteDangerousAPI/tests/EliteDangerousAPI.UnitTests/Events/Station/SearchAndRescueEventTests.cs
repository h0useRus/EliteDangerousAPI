using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SearchAndRescueEventTests
    {
        private const string EventName = "SearchAndRescue";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(SearchAndRescueEvent), e.EventType);
                Assert.IsType<SearchAndRescueEvent>(e.Event);
                AssertEvent((SearchAndRescueEvent)e.Event);
                globalFired = true;
            };

            api.Station.SearchAndRescue += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SearchAndRescueEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, $"Global event is not thrown");
        }

        private static void AssertEvent(SearchAndRescueEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-30T13:19:57Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3223937536, @event.MarketId);
            Assert.Equal("occupiedcryopod", @event.Name);
            Assert.Equal("Спасательная капсула с пассажиром", @event.NameLocalised);
            Assert.Equal(1, @event.Count);
            Assert.Equal(29994, @event.Reward);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-30T13:19:57Z\", \"event\":\"SearchAndRescue\", \"MarketID\":3223937536, \"Name\":\"occupiedcryopod\", \"Name_Localised\":\"Спасательная капсула с пассажиром\", \"Count\":1, \"Reward\":29994 }" }
            };
    }
}