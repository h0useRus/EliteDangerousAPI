using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class BankStatistics
    {
        [JsonProperty("Current_Wealth")]
        public long CurrentWealth { get; internal set; }
        [JsonProperty("Spent_On_Ships")]
        public long SpentOnShips { get; internal set; }
        [JsonProperty("Spent_On_Outfitting")]
        public long SpentOnOutfitting { get; internal set; }
        [JsonProperty("Spent_On_Repairs")]
        public long SpentOnRepairs { get; internal set; }
        [JsonProperty("Spent_On_Fuel")]
        public long SpentOnFuel { get; internal set; }
        [JsonProperty("Spent_On_Ammo_Consumables")]
        public long SpentOnAmmoConsumables { get; internal set; }
        [JsonProperty("Insurance_Claims")]
        public long InsuranceClaims { get; internal set; }
        [JsonProperty("Spent_On_Insurance")]
        public long SpentOnInsurance { get; internal set; }
    }
}