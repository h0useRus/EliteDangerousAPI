using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous
{
    public class ShipBaseTests
    {
        [Theory]
        [InlineData(null, ShipModel.Unknown)]
        [InlineData("", ShipModel.Unknown)]
        [InlineData("BlaBlaShip Model", ShipModel.Npc)]
        [InlineData("Viper_MkIV", ShipModel.ViperMkIV)]
        [InlineData("$Shipname_Passengerliner_Wedding;", ShipModel.WeddingBarge)]
        public void SimpleTests(string shipName, ShipModel model) => Assert.Equal(model, ShipBase.GetByFrontierName(shipName).Model);
    }
}