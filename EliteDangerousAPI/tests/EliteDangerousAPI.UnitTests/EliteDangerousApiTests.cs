using System.IO;
using System.Reflection;
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

        [Fact]
        public void InitializationWithCustomFolder()
        {
            
            var api = new EliteDangerousAPI(Path.Combine(Directory.GetCurrentDirectory(), "files"));
            Assert.Equal(25, api.DocumentationVersion);
            Assert.Equal(ApiStatus.Stopped, api.ApiStatus);

            Assert.Equal(ApiStatus.Running, api.Start());
        }
    }
}
