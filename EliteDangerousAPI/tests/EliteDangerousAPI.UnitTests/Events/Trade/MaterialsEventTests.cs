using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MaterialsEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Trade.Materials += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MaterialsEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(MaterialsEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-02-10T14:25:51Z"), @event.Timestamp);
            Assert.Equal("Materials", @event.Event);
            Assert.Equal(4, @event.Raw.Length);
            Assert.Equal(3, @event.Manufactured.Length);
            Assert.Equal(2, @event.Encoded.Length);

            Assert.Equal("chromium", @event.Raw[0].Name);
            Assert.Equal(28, @event.Raw[0].Count);

            Assert.Equal("refinedfocuscrystals", @event.Manufactured[0].Name);
            Assert.Equal(10, @event.Manufactured[0].Count);

            Assert.Equal("emissiondata", @event.Encoded[0].Name);
            Assert.Equal(32, @event.Encoded[0].Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Materials",  "{ \"timestamp\":\"2017-02-10T14:25:51Z\", \"event\":\"Materials\", \"Raw\":[ { \"Name\":\"chromium\",\r\n\"Count\":28 }, { \"Name\":\"zinc\", \"Count\":18 }, { \"Name\":\"iron\", \"Count\":23 }, { \"Name\":\"sulphur\",\r\n\"Count\":19 } ], \"Manufactured\":[ { \"Name\":\"refinedfocuscrystals\", \"Count\":10 }, {\r\n\"Name\":\"highdensitycomposites\", \"Count\":3 }, { \"Name\":\"mechanicalcomponents\", \"Count\":3 } ],\r\n\"Encoded\":[ { \"Name\":\"emissiondata\", \"Count\":32 }, { \"Name\":\"shielddensityreports\", \"Count\":23 }\r\n] }" },
            };
    }
}