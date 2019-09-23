using System;
using System.Threading.Tasks;

namespace NSW.EliteDangerous.API
{
    public interface IEliteDangerousPlugin
    {
        /// <summary>
        /// Unique plugin identifier
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Plugin name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Plugin version, API will automatically load latest version.
        /// </summary>
        Version Version { get; }
        /// <summary>
        /// Entry point to initialize plugin with <see cref="IEliteDangerousAPI"/>
        /// </summary>
        /// <param name="api"></param>
        void Initialize(IEliteDangerousAPI api);

        /// <summary>
        /// Optional method to start plugin, will automatically run after API start
        /// </summary>
        Task StartAsync();

        /// <summary>
        /// Optional method to stop plugin, will automatically run before API stopped
        /// </summary>
        Task StopAsync();
    }
}