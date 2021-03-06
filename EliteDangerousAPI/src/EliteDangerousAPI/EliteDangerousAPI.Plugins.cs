using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NSW.EliteDangerous.API
{
    partial class EliteDangerousAPI
    {
        private Dictionary<Guid, IEliteDangerousPlugin> _plugins;
        public IReadOnlyDictionary<Guid, IEliteDangerousPlugin> Plugins => _plugins;

        private void InitPlugins()
        {
            if(!_settings.UsePlugins) return;

            _plugins = new Dictionary<Guid, IEliteDangerousPlugin>();

            if(string.IsNullOrWhiteSpace(_settings.PluginsDirectory))
                return;

            var pluginsDirectory = new DirectoryInfo(_settings.PluginsDirectory);
            pluginsDirectory.Create();

            var pluginFiles = pluginsDirectory.GetFiles("*.dll");

            if(pluginFiles.Length == 0)
                return;

            try
            {
                foreach (var file in pluginFiles)
                {
                    Assembly assembly = Assembly.LoadFile(file.FullName);
                    var plugin =
                        (from type in assembly.GetTypes()
                         where type.GetInterfaces().Contains(typeof(IEliteDangerousPlugin))
                         select Activator.CreateInstance(type) as IEliteDangerousPlugin).FirstOrDefault();

                    if (plugin != null)
                    {
                        if (_plugins.ContainsKey(plugin.Id) && _plugins[plugin.Id].Version > plugin.Version)
                            return;

                        _plugins[plugin.Id] = plugin;
                        plugin.Initialize(this);
                    }
                }
            }
            catch (Exception exception)
            {
                _log.LogError(exception, exception.Message);
            }
        }

        private void StartPlugins()
        {
            if(Plugins == null || Plugins.Count == 0) return;

            try
            {
                Task.WaitAll(Plugins.Select(plugin => plugin.Value.StartAsync()).ToArray());
            }
            catch (Exception exception)
            {
                _log.LogError(exception, exception.Message);
            }
        }

        private void StopPlugins()
        {
            if(Plugins == null || Plugins.Count == 0) return;

            try
            {
                Task.WaitAll(Plugins.Select(plugin => plugin.Value.StopAsync()).ToArray());
            }
            catch (Exception exception)
            {
                _log.LogError(exception, exception.Message);
            }
        }
    }
}