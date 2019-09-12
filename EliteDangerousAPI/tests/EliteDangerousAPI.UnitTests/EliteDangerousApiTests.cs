using Xunit;

namespace NSW.EliteDangerous
{
    public class EliteDangerousApiTests
    {
        [Fact]
        public void Initialization()
        {
            var api = new EliteDangerousAPI();
            Assert.Equal(25, api.DocumentationVersion);
            Assert.Equal(ApiStatus.Stopped, api.ApiStatus);
        }
    }
}
