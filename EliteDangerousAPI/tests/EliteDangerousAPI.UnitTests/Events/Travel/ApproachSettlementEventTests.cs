using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ApproachSettlementEventTests
    {
        private const string EventName = "ApproachSettlement";

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
                Assert.Equal(typeof(ApproachSettlementEvent), e.EventType);
                Assert.IsType<ApproachSettlementEvent>(e.Event);
                AssertEvent((ApproachSettlementEvent)e.Event);
                globalFired = true;
            };

            api.Travel.ApproachSettlement += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ApproachSettlementEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(ApproachSettlementEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-30T12:03:53Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Aitkins Hub", @event.Name);
            Assert.Equal(128936752, @event.MarketId);
            Assert.Equal(1213084977515, @event.SystemAddress);
            Assert.Equal(8, @event.BodyId);
            Assert.Equal("Dromi 3 a", @event.BodyName);
            Assert.Equal(-0.177010, @event.Latitude, 6);
            Assert.Equal(-158.778259, @event.Longitude, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-30T12:03:53Z\", \"event\":\"ApproachSettlement\", \"Name\":\"Aitkins Hub\", \"MarketID\":128936752, \"SystemAddress\":1213084977515, \"BodyID\":8, \"BodyName\":\"Dromi 3 a\", \"Latitude\":-0.177010, \"Longitude\":-158.778259 }" },
            };
    }
}