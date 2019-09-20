using System;
using NSW.EliteDangerous;
using NSW.EliteDangerous.Exceptions;

namespace TestConsole
{
    public class App
    {
        private readonly IEliteDangerousAPI _api;

        public App(IEliteDangerousAPI api)
        {
            _api = api;

            _api.StatusChanged += (sender, status) => Console.WriteLine($"API status {status}");
            _api.Errors += (sender, exception) =>
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

            _api.Warnings += (sender, exception) =>
            {
                if (exception.Type == JournalErrorType.EventNotFound)
                {
                    var ex = (JournalEventNotFoundException)exception; 
                    Console.WriteLine(
                        $"API no definition for {ex.EventName} json: {ex.JournalRecord}");
                }
            };

            _api.AllEvents += (s, e) => Console.WriteLine($"API event at {e.Event.Timestamp:O} {e.EventName} type {e.EventType.Name}");
        }

        public void Run()
        {
            _api.Start();

            Console.ReadLine();

            _api.Stop();
        }
    }
}