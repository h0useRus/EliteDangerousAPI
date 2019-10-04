using System;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace NSW.EliteDangerous.API
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EliteDangerousApiExtensions
    {
        public static IServiceCollection AddEliteDangerousAPI(this IServiceCollection services)
        {
            services.AddOptions<ApiOptions>();
            return services.AddSingleton<IEliteDangerousAPI, EliteDangerousAPI>();
        }

        public static IServiceCollection AddEliteDangerousAPI(this IServiceCollection services, string journalPath)
            => services.AddEliteDangerousAPI(o =>
            {
                if(string.IsNullOrWhiteSpace(journalPath)) throw new ArgumentNullException(nameof(journalPath));
                o.JournalDirectory = journalPath;
            });

        public static IServiceCollection AddEliteDangerousAPI(this IServiceCollection services, Action<ApiOptions> configure)
        {
            services.AddEliteDangerousAPI();
            return services.Configure(configure);
        }
    }
}