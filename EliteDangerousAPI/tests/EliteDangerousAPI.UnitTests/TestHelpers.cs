using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NSW.EliteDangerous
{
    public static class TestHelpers
    {
        public static string FilesFolder => Path.Combine(Directory.GetCurrentDirectory(), "files");
        public static string TestFolder => Path.Combine(Directory.GetCurrentDirectory(), "test");

        public static IEliteDangerousAPI TestApi
            => new ServiceCollection()
                .AddLogging(cfg => cfg.AddDebug())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Warning)
                .AddEliteDangerousAPI(TestFolder)
                .BuildServiceProvider()
                .GetService<IEliteDangerousAPI>();

        public static IEliteDangerousAPI FilesApi
            => new ServiceCollection()
                .AddLogging(cfg => cfg.AddDebug())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Warning)
                .AddEliteDangerousAPI(FilesFolder)
                .BuildServiceProvider()
                .GetService<IEliteDangerousAPI>();
            

        public static IEliteDangerousAPI DefaultAPI
            => new ServiceCollection()
                .AddLogging(cfg => cfg.AddDebug())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Warning)
                .AddEliteDangerousAPI()
                .BuildServiceProvider()
                .GetService<IEliteDangerousAPI>();
    }
}