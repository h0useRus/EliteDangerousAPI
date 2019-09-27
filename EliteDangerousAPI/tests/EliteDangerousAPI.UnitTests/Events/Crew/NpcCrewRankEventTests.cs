using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class NpcCrewRankEventTests
    {
        private const string EventName = "NpcCrewRank";

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
                Assert.Equal(typeof(NpcCrewRankEvent), e.EventType);
                Assert.IsType<NpcCrewRankEvent>(e.Event);
                AssertEvent((NpcCrewRankEvent)e.Event);
                globalFired = true;
            };

            api.CrewEvents.NpcCrewRank += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as NpcCrewRankEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(NpcCrewRankEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-08-09T08:45:31Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Dannie Koller", @event.NpcCrewName);
            Assert.Equal(1234, @event.NpcCrewId);
            Assert.Equal(CombatRank.Expert, @event.Rank);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-08-09T08:45:31Z\", \"event\":\"NpcCrewRank\", \"NpcCrewId\":1234, \"NpcCrewName\":\"Dannie Koller\", \"RankCombat\":4 }" },
            };
    }
}