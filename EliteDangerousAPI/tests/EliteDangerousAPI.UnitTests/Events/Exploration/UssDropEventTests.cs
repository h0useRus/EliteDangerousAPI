using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class UssDropEventTests
    {
        private const string EventName = "USSDrop";

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
                Assert.Equal(typeof(UssDropEvent), e.EventType);
                Assert.IsType<UssDropEvent>(e.Event);
                AssertEvent((UssDropEvent)e.Event);
                globalFired = true;
            };

            api.ExplorationEvents.UssDrop += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as UssDropEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(UssDropEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T12:12:45Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(UssType.Salvage, @event.UssType);
            Assert.Equal("Слабый сигнал", @event.UssTypeLocalised);
            Assert.Equal(1, @event.UssThreat);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T12:12:45Z\", \"event\":\"USSDrop\", \"USSType\":\"$USS_Type_Salvage;\", \"USSType_Localised\":\"Слабый сигнал\", \"USSThreat\":1 }" }
            };
    }
}