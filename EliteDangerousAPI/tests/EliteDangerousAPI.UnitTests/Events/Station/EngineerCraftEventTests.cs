using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class EngineerCraftEventTests
    {
        private const string EventName = "EngineerCraft";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.EngineerCraft += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as EngineerCraftEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(EngineerCraftEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-03-04T07:08:27Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(300110, @event.EngineerId);
            Assert.Equal("Ram Tah", @event.Engineer);
            Assert.Equal(128731526, @event.BlueprintId);
            Assert.Equal("Misc_LightWeight", @event.BlueprintName);
            Assert.Equal(1, @event.Level);
            Assert.Equal(0.955000, @event.Quality, 6);

            Assert.Equal("phosphorus", @event.Ingredients[0].Name);
            Assert.Equal(1, @event.Ingredients[0].Count);

            Assert.Equal(2, @event.Modifiers.Length);
            Assert.Equal(ModuleAttribute.Mass, @event.Modifiers[0].Label);
            Assert.Equal(4.436000, @event.Modifiers[0].Value, 6);
            Assert.Equal(8.000000, @event.Modifiers[0].OriginalValue, 6);
            Assert.True(@event.Modifiers[0].LessIsGood);

            Assert.Equal(ModuleAttribute.Integrity, @event.Modifiers[1].Label);
            Assert.Equal(81.000000, @event.Modifiers[1].Value, 6);
            Assert.Equal(90.000000, @event.Modifiers[1].OriginalValue, 6);
            Assert.False(@event.Modifiers[1].LessIsGood);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-03-04T07:08:27Z\", \"event\":\"EngineerCraft\",\r\n\"Slot\":\"Slot03_Size3\", \"Module\":\"int_dronecontrol_collection_size3_class5\",\r\n\"Ingredients\":[ { \"Name\":\"phosphorus\", \"Count\":1 } ], \"Engineer\":\"Ram Tah\",\r\n\"EngineerID\":300110, \"BlueprintID\":128731526,\r\n\"BlueprintName\":\"Misc_LightWeight\", \"Level\":1, \"Quality\":0.955000,\r\n\"Modifiers\":[ { \"Label\":\"Mass\", \"Value\":4.436000, \"OriginalValue\":8.000000,\r\n\"LessIsGood\":1 }, { \"Label\":\"Integrity\", \"Value\":81.000000,\r\n\"OriginalValue\":90.000000, \"LessIsGood\":0 } ] }" },
            };
    }
}