using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CodexEntryEventTests
    {
        private const string EventName = "CodexEntry";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Exploration.CodexEntry += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CodexEntryEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(CodexEntryEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T11:37:07Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(1300701, @event.EntryId);
            Assert.Equal("$Codex_Ent_Standard_Rocky_Ice_No_Atmos_Name;", @event.Name);
            Assert.Equal("Не пригодная для терраформирования", @event.NameLocalised);
            Assert.Equal("$Codex_Category_StellarBodies;", @event.Category);
            Assert.Equal("Астрономические тела", @event.CategoryLocalised);
            Assert.Equal("$Codex_SubCategory_Terrestrials;", @event.SubCategory);
            Assert.Equal("Землеподобные планеты", @event.SubCategoryLocalised);
            Assert.Equal("$Codex_RegionName_18;", @event.Region);
            Assert.Equal("Inner Orion Spur", @event.RegionLocalised);
            Assert.Equal("Trianguli Sector DQ-Y b2", @event.System);
            Assert.Equal(5069806118265, @event.SystemAddress);
            Assert.True(@event.IsNewEntry);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T11:37:07Z\", \"event\":\"CodexEntry\", \"EntryID\":1300701, \"Name\":\"$Codex_Ent_Standard_Rocky_Ice_No_Atmos_Name;\", \"Name_Localised\":\"Не пригодная для терраформирования\", \"SubCategory\":\"$Codex_SubCategory_Terrestrials;\", \"SubCategory_Localised\":\"Землеподобные планеты\", \"Category\":\"$Codex_Category_StellarBodies;\", \"Category_Localised\":\"Астрономические тела\", \"Region\":\"$Codex_RegionName_18;\", \"Region_Localised\":\"Inner Orion Spur\", \"System\":\"Trianguli Sector DQ-Y b2\", \"SystemAddress\":5069806118265, \"IsNewEntry\":true }" },
            };
    }
}