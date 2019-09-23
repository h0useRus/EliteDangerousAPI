using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSW.EliteDangerous;
using NSW.EliteDangerous.API;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel=LogLevel.Debug)
                .AddEliteDangerousAPI(Path.Combine(Directory.GetCurrentDirectory(), "logs"))
                .AddSingleton<App>()
                .BuildServiceProvider();

            serviceProvider.GetService<App>().Run();
        }
    }
}
