using System.Threading.Tasks;

namespace Ding.Localization
{
    public class NonTranslator : ITranslator
    {
        public Task<string> TranslateAsync(string from, string to, string src)
        {
            return Task.FromResult(src);
        }
    }
}
