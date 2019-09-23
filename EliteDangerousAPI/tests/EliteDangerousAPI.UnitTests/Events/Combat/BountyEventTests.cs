using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class BountyEventTests
    {
        private const string EventName = "Bounty";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Combat.Bounty += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as BountyEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(BountyEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-03T13:38:51Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("eagle", @event.Target);
            Assert.Equal("Ninabin Silver Camorra", @event.VictimFaction);
            Assert.Equal(3935, @event.TotalReward);
            Assert.Equal(3935, @event.Rewards[0].Amount);
            Assert.Equal("Progressive Party of Scylla", @event.Rewards[0].Faction);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-03T13:38:51Z\", \"event\":\"Bounty\", \"Rewards\":[ { \"Faction\":\"Progressive Party of Scylla\", \"Reward\":3935 } ], \"Target\":\"eagle\", \"TotalReward\":3935, \"VictimFaction\":\"Ninabin Silver Camorra\" }" },
            };
    }
}