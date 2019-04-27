using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using System.Reflection;

namespace Ding.Webs.Plugin
{
    public interface IPluginStartup
    {
        Assembly Assembly { get; set; }
        List<CompilationLibrary> Dependency { get; set; }
        string CurrentPluginPath { get; set; }
        void Setup(params object[] args);
        void ConfigureServices(IServiceCollection services);
        void ConfigureApplication(IApplicationBuilder app, IHostingEnvironment env);
    }
}
