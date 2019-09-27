using System;
using System.Collections.Generic;
using System.Linq;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class EngineerProgressEventTests
    {
        private const string EventName = "EngineerProgress";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.StationEvents.EngineerProgress += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as EngineerProgressEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(EngineerProgressEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-05-04T13:58:22Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(14, @event.Engineers.Length);

            var engineer = @event.Engineers.Single(e => e.EngineerId == 300200);
            Assert.Equal("Marco Qwent", engineer.EngineerName);
            Assert.Equal(EngineerProgressState.Unlocked, engineer.Progress);
            Assert.Equal(37, engineer.RankProgress);
            Assert.Equal(4, engineer.Rank);

            engineer = @event.Engineers.Single(e => e.EngineerId == 300120);
            Assert.Equal("Lei Cheung", engineer.EngineerName);
            Assert.Equal(EngineerProgressState.Known, engineer.Progress);
            Assert.Null(engineer.RankProgress);
            Assert.Null(engineer.Rank);

            engineer = @event.Engineers.Single(e => e.EngineerId == 300220);
            Assert.Equal("Professor Palin", engineer.EngineerName);
            Assert.Equal(EngineerProgressState.Invited, engineer.Progress);
            Assert.Null(engineer.RankProgress);
            Assert.Null(engineer.Rank);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-05-04T13:58:22Z\", \"event\":\"EngineerProgress\", \"Engineers\":[ { \"Engineer\":\"Zacariah Nemo\", \"EngineerID\":300050, \"Progress\":\"Unlocked\", \"RankProgress\":0, \"Rank\":5 }, { \"Engineer\":\"Marco Qwent\", \"EngineerID\":300200, \"Progress\":\"Unlocked\", \"RankProgress\":37, \"Rank\":4 }, { \"Engineer\":\"Hera Tani\", \"EngineerID\":300090, \"Progress\":\"Unlocked\", \"RankProgress\":0, \"Rank\":3 }, { \"Engineer\":\"Tod 'The Blaster' McQuinn\", \"EngineerID\":300260, \"Progress\":\"Unlocked\", \"RankProgress\":97, \"Rank\":3 }, { \"Engineer\":\"Selene Jean\", \"EngineerID\":300210, \"Progress\":\"Known\" }, { \"Engineer\":\"Lei Cheung\", \"EngineerID\":300120, \"Progress\":\"Known\" }, { \"Engineer\":\"Juri Ishmaak\", \"EngineerID\":300250, \"Progress\":\"Known\" }, {\"Engineer\":\"Felicity Farseer\", \"EngineerID\":300100, \"Progress\":\"Unlocked\", \"RankProgress\":0, \"Rank\":5 }, { \"Engineer\":\"Professor Palin\", \"EngineerID\":300220, \"Progress\":\"Invited\" }, { \"Engineer\":\"Elvira Martuuk\",\"EngineerID\":300160, \"Progress\":\"Unlocked\", \"RankProgress\":0, \"Rank\":5 }, { \"Engineer\":\"Lori Jameson\",\r\n\"EngineerID\":300230, \"Progress\":\"Known\" }, { \"Engineer\":\"The Dweller\", \"EngineerID\":300180,\r\n\"Progress\":\"Unlocked\", \"RankProgress\":0, \"Rank\":5 }, { \"Engineer\":\"Liz Ryder\", \"EngineerID\":300080,\r\n\"Progress\":\"Unlocked\", \"RankProgress\":93, \"Rank\":3 }, { \"Engineer\":\"Ram Tah\", \"EngineerID\":300110,\"Progress\":\"Unlocked\", \"RankProgress\":31, \"Rank\":3 } ] }" },
            };
    }
}