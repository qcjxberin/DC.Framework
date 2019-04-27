using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace Ding.Webs.Plugin
{
    public interface IPluginLoader
    {
        IEnumerable<IPluginStartup> LoadEnablePlugins(IServiceCollection serviceCollection);
        IEnumerable<PluginInfo> GetPlugins();
        void DisablePlugin(string pluginId);
        void EnablePlugin(string pluginId);
        IEnumerable<Assembly> GetPluginAssemblies();
        string PluginFolderName();
    }
}
