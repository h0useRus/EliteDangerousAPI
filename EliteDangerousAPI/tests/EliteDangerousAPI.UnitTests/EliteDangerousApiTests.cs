using Xunit;

namespace NSW.EliteDangerous
{
    public class EliteDangerousApiTests
    {
        [Fact]
        public void Initialization()
        {
            Assert.NotNull(new EliteDangerousAPI());
        }
    }
}
