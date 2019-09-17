using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSW.EliteDangerous;
using NSW.EliteDangerous.Exceptions;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel=LogLevel.Debug)
                .BuildServiceProvider();

            var api = new EliteDangerousAPI(Path.Combine(Directory.GetCurrentDirectory(), "logs"), serviceProvider.GetService<ILoggerFactory>());

            api.StatusChanged += (sender, status) => Console.WriteLine($"API status {status}");
            api.Errors += (sender, exception) =>
            {
                if (exception.Type == JournalErrorType.OnReadingRecord)
                {
                    Console.WriteLine(
                        $"API error {exception.Type} json: {((JournalRecordException)exception).JournalRecord}");
                }
                else
                {
                    Console.WriteLine($"API error {exception.Type}");
                }
            };

            api.Warnings += (sender, exception) =>
            {
                if (exception.Type == JournalErrorType.EventNotFound)
                {
                    var ex = (JournalEventNotFoundException)exception; 
                    Console.WriteLine(
                        $"API no definition for {ex.EventName} json: {ex.JournalRecord}");
                }
            };

            api.AllEvents += (s, e) => Console.WriteLine($"API event at {e.Event.Timestamp:O} {e.EventName} type {e.EventType.Name}");

            api.Start();

            Console.ReadLine();

            api.Stop();
        }
    }
}
