using System.IO;
using System.Threading.Tasks;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.Events;
using Xunit;

namespace NSW.EliteDangerous
{
    public class EliteDangerousApiTests
    {
        [Fact]
        public void Initialization()
        {
            var api = TestHelpers.TestApi;
            Assert.Equal(25, api.DocumentationVersion);
            Assert.Equal("1.0.25.0", api.Version);
            Assert.Equal(ApiStatus.Stopped, api.Status);
        }

        [Fact]
        public void ShouldRunning()
        {
            using (var api = TestHelpers.FilesApi)
            {
                api.Start();
                Assert.Equal(ApiStatus.Running, api.Status);
            }
        }

        [Fact]
        public void ShouldPending()
        {
            using (var api = TestHelpers.TestApi)
            {
                api.Start();
                Assert.Equal(ApiStatus.Pending, api.Status);
            }
        }
    }
}
