using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CommitCrimeEventTests
    {
        private const string EventName = "CommitCrime";

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
                Assert.Equal(typeof(CommitCrimeEvent), e.EventType);
                Assert.IsType<CommitCrimeEvent>(e.Event);
                AssertEvent((CommitCrimeEvent)e.Event);
                globalFired = true;
            };

            api.Combat.CommitCrime += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CommitCrimeEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(CommitCrimeEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-04T14:29:13Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(CrimeType.Piracy, @event.CrimeType);
            Assert.Equal("Progressive Party of Scylla", @event.Faction);
            Assert.Equal("$ShipName_Police_Federation;", @event.Victim);
            Assert.Equal("Федеральная служба безопасности", @event.VictimLocalised);
            Assert.Equal(200, @event.Bounty);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-04T14:29:13Z\", \"event\":\"CommitCrime\", \"CrimeType\":\"piracy\", \"Faction\":\"Progressive Party of Scylla\", \"Victim\":\"$ShipName_Police_Federation;\", \"Victim_Localised\":\"Федеральная служба безопасности\", \"Bounty\":200 }" },
            };
    
    }
}