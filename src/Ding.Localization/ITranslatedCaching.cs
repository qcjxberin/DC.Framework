namespace Ding.Localization
{
    public interface ITranslatedCaching
    {
        void Set(string key, string culture, string dst);

        string Get(string key, string culture);
    }
}
