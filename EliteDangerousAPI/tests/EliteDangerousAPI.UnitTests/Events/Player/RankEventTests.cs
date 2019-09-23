using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class RankEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Player.Rank += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as RankEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(RankEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal("Rank", @event.Event);
            Assert.Equal(CombatRank.Novice, @event.Combat);
            Assert.Equal(TradeRank.Peddler, @event.Trade);
            Assert.Equal(ExplorationRank.Pathfinder, @event.Explore);
            Assert.Equal(EmpireRank.Outsider, @event.Empire);
            Assert.Equal(FederationRank.Midshipman, @event.Federation);
            Assert.Equal(CqcRank.Helpless, @event.Cqc);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Rank",  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"Rank\", \"Combat\":2, \"Trade\":2, \"Explore\":5, \"Empire\":1, \"Federation\":3, \"CQC\":0 } " },
            };
    }
}