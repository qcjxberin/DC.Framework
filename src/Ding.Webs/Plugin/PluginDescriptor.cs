using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ding.Webs.Plugin
{
    public class PluginDescriptor
    {
        public Type PluginType { get; set; }
        public Assembly Assembly { get; set; }
        public List<CompilationLibrary> Dependency { get; set; }
        public string CurrentPluginPath { get; set; }
    }
}
