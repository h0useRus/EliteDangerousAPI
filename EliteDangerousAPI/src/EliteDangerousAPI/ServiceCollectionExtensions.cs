using System;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace NSW.EliteDangerous.API
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEliteDangerousAPI(this IServiceCollection services)
            => services.AddEliteDangerousAPI(o =>
                {
                    o.JournalDirectory = ApiOptions.Default.JournalDirectory;
                    o.CheckInterval = ApiOptions.Default.CheckInterval;
                });

        public static IServiceCollection AddEliteDangerousAPI(this IServiceCollection services, string journalPath)
            => services.AddEliteDangerousAPI(o =>
            {
                o.JournalDirectory = journalPath ?? ApiOptions.Default.JournalDirectory;
                o.CheckInterval = ApiOptions.Default.CheckInterval;
            });

        public static IServiceCollection AddEliteDangerousAPI(this IServiceCollection services, Action<ApiOptions> configure)
        {
            services.Configure(configure);
            return services.AddSingleton<IEliteDangerousAPI, API.EliteDangerousAPI>();
        }
    }
}