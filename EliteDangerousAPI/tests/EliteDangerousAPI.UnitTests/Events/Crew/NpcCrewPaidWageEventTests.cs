using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class NpcCrewPaidWageEventTests
    {
        private const string EventName = "NpcCrewPaidWage";

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
                Assert.Equal(typeof(NpcCrewPaidWageEvent), e.EventType);
                Assert.IsType<NpcCrewPaidWageEvent>(e.Event);
                AssertEvent((NpcCrewPaidWageEvent)e.Event);
                globalFired = true;
            };

            api.Crew.NpcCrewPaidWage += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as NpcCrewPaidWageEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(NpcCrewPaidWageEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-08-09T08:45:31Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Dannie Koller", @event.NpcCrewName);
            Assert.Equal(1234, @event.NpcCrewId);
            Assert.Equal(200, @event.Amount);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-08-09T08:45:31Z\", \"event\":\"NpcCrewPaidWage\", \"NpcCrewId\":1234, \"NpcCrewName\":\"Dannie Koller\", \"Amount\":200 }" },
            };
    }
}