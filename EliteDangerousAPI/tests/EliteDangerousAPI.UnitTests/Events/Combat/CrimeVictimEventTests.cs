using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CrimeVictimEventTests
    {
        private const string EventName = "CrimeVictim";

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
                Assert.Equal(typeof(CrimeVictimEvent), e.EventType);
                Assert.IsType<CrimeVictimEvent>(e.Event);
                AssertEvent((CrimeVictimEvent)e.Event);
                globalFired = true;
            };

            api.CombatEvents.CrimeVictim += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CrimeVictimEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(CrimeVictimEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-04T14:29:13Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Den 'h0use' McConan", @event.Offender);
            Assert.Equal(CrimeType.DisobeyPolice, @event.CrimeType);
            Assert.Equal(200, @event.Bounty);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-04T14:29:13Z\", \"event\":\"CrimeVictim\", \"Offender\":\"Den 'h0use' McConan\", \"CrimeType\":\"disobeypolice\", \"Bounty\":200 }" },
            };
    
    }
}