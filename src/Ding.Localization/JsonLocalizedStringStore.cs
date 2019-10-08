﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ding.Localization
{
    public class JsonLocalizedStringStore : Dictionary<string, string>, ILocalizedStringStore
    {
        [JsonIgnore]
        private string path { get; set; }

        [JsonIgnore]
        private DateTime time { get; set; } = DateTime.Now;

        public JsonLocalizedStringStore(string path)
        {
            this.path = path;
            Load();
        }

        public string Localize(string src, params object[] args)
        {
            var fi = new FileInfo(path);
            if (fi.LastWriteTime > time)
                Load();
            if (this.ContainsKey(src))
            {
                if (args == null)
                    return this[src];
                else
                    return string.Format(this[src], args);
            }
            else
            {
                if (args == null)
                    return src;
                else
                    return string.Format(src, args);
            }
        }

        private void Load()
        {
            var tmp = JsonConvert.DeserializeObject<IDictionary<string, string>>(File.ReadAllText(path));
            this.Clear();
            foreach (var x in tmp)
                this.Add(x.Key, x.Value);
        }
    }
}
