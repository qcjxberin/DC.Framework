using System.Collections.Generic;

namespace Ding.Localization
{
    public interface ILocalizedStringStore : IDictionary<string, string>
    {
        string Localize(string src, params object[] args);
    }
}
