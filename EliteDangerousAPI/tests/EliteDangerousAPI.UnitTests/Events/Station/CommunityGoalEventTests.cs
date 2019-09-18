using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalEventTests
    {
        private const string EventName = "CommunityGoal";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.CommunityGoal += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CommunityGoalEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(CommunityGoalEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T13:20:28Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(726, @event.CurrentGoals[0].GoalId);
            Assert.Equal("Alliance Research Initiative – Trade", @event.CurrentGoals[0].Title);
            Assert.Equal("Kaushpoos", @event.CurrentGoals[0].SystemName);
            Assert.Equal("Neville Horizons", @event.CurrentGoals[0].MarketName);
            Assert.Equal(DateTime.Parse("2017-08-17T14: 58: 14Z"), @event.CurrentGoals[0].Expiry);
            Assert.False(@event.CurrentGoals[0].IsComplete);
            Assert.Equal(10062, @event.CurrentGoals[0].CurrentTotal);
            Assert.Equal(562, @event.CurrentGoals[0].PlayerContribution);
            Assert.Equal(101, @event.CurrentGoals[0].NumContributors);
            Assert.Equal(10, @event.CurrentGoals[0].TopRankSize);
            Assert.False(@event.CurrentGoals[0].PlayerInTopRank);
            Assert.Equal("Tier 1", @event.CurrentGoals[0].TierReached);
            Assert.Equal(50, @event.CurrentGoals[0].PlayerPercentileBand);
            Assert.Equal(200000, @event.CurrentGoals[0].Bonus);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-08-14T13:20:28Z\", \"event\":\"CommunityGoal\", \"CurrentGoals\":[ { \"CGID\":726,\"Title\":\"Alliance Research Initiative – Trade\", \"SystemName\":\"Kaushpoos\", \"MarketName\":\"Neville Horizons\", \"Expiry\":\"2017-08-17T14:58:14Z\", \"IsComplete\":false, \"CurrentTotal\":10062, \"PlayerContribution\":562, \"NumContributors\":101, \"TopRankSize\":10, \"PlayerInTopRank\":false, \"TierReached\":\"Tier 1\", \"PlayerPercentileBand\":50, \"Bonus\":200000 } ] }" },
            };
    }
}