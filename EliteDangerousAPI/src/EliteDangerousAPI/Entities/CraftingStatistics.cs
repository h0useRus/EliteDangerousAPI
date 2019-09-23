using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class CraftingStatistics
    {
        [JsonProperty("Spent_On_Crafting")]
        public long SpentOnCrafting { get; internal set; }
        [JsonProperty("Count_Of_Used_Engineers")]
        public long CountOfUsedEngineers { get; internal set; }

        [JsonProperty("Recipes_Generated")]
        public long RecipesGenerated { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_1")]
        public long RecipesGeneratedRank1 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_2")]
        public long RecipesGeneratedRank2 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_3")]
        public long RecipesGeneratedRank3 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_4")]
        public long RecipesGeneratedRank4 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_5")]
        public long RecipesGeneratedRank5 { get; internal set; }

        [JsonProperty("Recipes_Applied")]
        public long RecipesApplied { get; internal set; }

        [JsonProperty("Recipes_Applied_Rank_1")]
        public long RecipesAppliedRank1 { get; internal set; }

        [JsonProperty("Recipes_Applied_Rank_2")]
        public long RecipesAppliedRank2 { get; internal set; }

        [JsonProperty("Recipes_Applied_Rank_3")]
        public long RecipesAppliedRank3 { get; internal set; }

        [JsonProperty("Recipes_Applied_Rank_4")]
        public long RecipesAppliedRank4 { get; internal set; }

        [JsonProperty("Recipes_Applied_Rank_5")]
        public long RecipesAppliedRank5 { get; internal set; }

        [JsonProperty("Recipes_Applied_On_Previously_Modified_Modules")]
        public long RecipesAppliedOnPreviouslyModifiedModules { get; internal set; }
    }
}