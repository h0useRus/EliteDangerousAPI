using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SquadronDemotionEventTests
    {
        private const string EventName = "SquadronDemotion";

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
                Assert.Equal(typeof(SquadronDemotionEvent), e.EventType);
                Assert.IsType<SquadronDemotionEvent>(e.Event);
                AssertEvent((SquadronDemotionEvent)e.Event);
                globalFired = true;
            };

            api.SquadronEvents.SquadronDemotion += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SquadronDemotionEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(SquadronDemotionEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-10-17T16:17:55Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("TestSquadron", @event.SquadronName);
            Assert.Equal(SquadronRank.SeniorOfficer, @event.OldRank);
            Assert.Equal(SquadronRank.Officer, @event.NewRank);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-10-17T16:17:55Z\", \"event\":\"SquadronDemotion\", \"SquadronName\":\"TestSquadron\", \"OldRank\":3, \"NewRank\":2  }" },
            };
    }
}