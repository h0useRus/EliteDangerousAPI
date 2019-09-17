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
            Assert.Equal("1.0.25.0", api.Version);
            Assert.Equal(ApiStatus.Stopped, api.Status);
        }

        //[Fact]
        //public void InitializationWithCustomFolder()
        //{
            
        //    var api = new EliteDangerousAPI(Path.Combine(Directory.GetCurrentDirectory(), "files"));
        //    Assert.Equal(ApiStatus.Running, api.Start());
        //}

        //[Fact]
        //public void ShouldPending()
        //{
        //    var api = new EliteDangerousAPI(Directory.GetCurrentDirectory());
        //    Assert.Equal(ApiStatus.Pending, api.Start());
        //}

        //[Fact]
        //public void ShouldGameNotFound()
        //{
        //    var api = new EliteDangerousAPI(Path.GetRandomFileName());
        //    Assert.Equal(ApiStatus.GameNotFound, api.Start());
        //}
    }
}
