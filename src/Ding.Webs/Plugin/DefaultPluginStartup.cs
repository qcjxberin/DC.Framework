using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using System.Reflection;

namespace Ding.Webs.Plugin
{
    public class DefaultPluginStartup : IPluginStartup
    {
        public Assembly Assembly { get; set; }
        public string CurrentPluginPath { get; set; }
        public IHostingEnvironment HostingEnvironment { get; set; }
        public List<CompilationLibrary> Dependency { get; set; }

        public virtual void ConfigureApplication(IApplicationBuilder app, IHostingEnvironment env)
        {

        }

        public virtual void ConfigureServices(IServiceCollection services)
        {

        }

        public virtual void Setup(params object[] args)
        {

        }
    }
}
