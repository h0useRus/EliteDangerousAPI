using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CodexEntryEvent : JournalEvent
    {
        [JsonProperty("EntryID")]
        public long EntryId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("SubCategory")]
        public string SubCategory { get; internal set; }

        [JsonProperty("SubCategory_Localised")]
        public string SubCategoryLocalised { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }

        [JsonProperty("Region")]
        public string Region { get; internal set; }

        [JsonProperty("Region_Localised")]
        public string RegionLocalised { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("IsNewEntry")]
        public bool IsNewEntry { get; internal set; }

        [JsonProperty("VoucherAmount")]
        public long VoucherAmount { get; internal set; }

        internal static CodexEntryEvent Execute(string json, API.EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<CodexEntryEvent>(json));
    }
}