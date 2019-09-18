using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ApproachBodyEventTests
    {
        public class PassengersEventTests
        {
            [Theory]
            [MemberData(nameof(Data))]
            public void ShouldExecuteEvent(string eventName, string json)
            {
                var api = (EliteDangerousAPI)TestHelpers.TestApi;
                var eventFired = false;
                api.Travel.ApproachBody += (sender, @event) =>
                {
                    Assert.IsType<EliteDangerousAPI>(sender);
                    AssertEvent(@event);
                    eventFired = true;
                };

                Assert.True(api.HasEvent(eventName));
                AssertEvent(api.ExecuteEvent(eventName, json) as ApproachBodyEvent);
                Assert.True(eventFired);
            }

            private void AssertEvent(ApproachBodyEvent @event)
            {
                Assert.NotNull(@event);
                Assert.Equal(DateTime.Parse("2019-09-11T12:45:48Z"), @event.Timestamp);
                Assert.Equal("ApproachBody", @event.Event);
                Assert.Equal("HIP 15329", @event.StarSystem);
                Assert.Equal(358596186802, @event.SystemAddress);
                Assert.Equal("HIP 15329 A 3 c", @event.Body);
                Assert.Equal(38, @event.BodyId);
            }

            public static IEnumerable<object[]> Data =>
                new List<object[]>
                {
                    new object[] { "ApproachBody",  "{ \"timestamp\":\"2019-09-11T12:45:48Z\", \"event\":\"ApproachBody\", \"StarSystem\":\"HIP 15329\", \"SystemAddress\":358596186802, \"Body\":\"HIP 15329 A 3 c\", \"BodyID\":38 }" },
                };
        }
    }
}