using System.Threading.Tasks;

namespace Ding.Localization
{
    public interface ITranslator
    {
        Task<string> TranslateAsync(string from, string to, string src);
    }
}
