using System;

namespace Ding.Webs.Plugin
{
    public class PluginInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public bool Enable { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedDate { get; set; }

        //Additional Property
        public string RelativePath { get; set; }
    }
}
