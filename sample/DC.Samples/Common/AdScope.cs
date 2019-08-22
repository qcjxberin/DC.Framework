using Ding;
using Ding.Data;
using System;

namespace DC.Samples.Common
{
    /// <summary>
    /// 广告范围
    /// </summary>
    public class AdScope : CacheObject
    {
        public static String GetName(int id)
        {
            AdScope c = cdb.findById<AdScope>(id);
            return c == null ? "" : c.Name;
        }

        public static int GetCount()
        {
            var model = new AdScope();
            model.Name = "test";
            cdb.insert(model);

            return cdb.findAll<AdScope>().Count;
        }
    }
}
