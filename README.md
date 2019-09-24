# Frontier Elite Dangerous API
![Nuget](https://img.shields.io/nuget/v/NSW.EliteDangerous.API?label=nuget%3Astable)![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/NSW.EliteDangerous.API?label=nuget%3Adev)![Nuget](https://img.shields.io/nuget/dt/NSW.EliteDangerous.API)

![GitHub top language](https://img.shields.io/github/languages/top/h0useRus/EliteDangerousAPI)![GitHub](https://img.shields.io/github/license/h0useRus/EliteDangerousAPI)![GitHub Release Date](https://img.shields.io/github/release-date/h0useRus/EliteDangerousAPI)![GitHub last commit](https://img.shields.io/github/last-commit/h0useRus/EliteDangerousAPI)

Simple event-based library which is provide easy way to get events from Elite Dangerous log journal.

## Usage

Use `AddEliteDangerousAPI()` method to add API into your app:
```c#
// Use Microsoft.Extensions.DependencyInjection
var serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel=LogLevel.Debug)
                .AddEliteDangerousAPI()
                .BuildServiceProvider();
// Get instance from DI                
var api = serviceProvider.GetService<IEliteDangerousAPI>()
// Subscribe to all events or find events which you interested for.
api..AllEvents += (s, e) => Console.WriteLine($"API event at {e.Event.Timestamp:O} {e.EventName} type {e.EventType.Name}");
// Run api (you could define autostart in ApiOptions)
api.Start()
Console.ReadLine();
// Stop processing if you want
api.Stop()
```
