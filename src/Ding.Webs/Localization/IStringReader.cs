namespace Ding.Localization
{
    public interface IStringReader
    {
        string this[string src, params object[] args] { get; }
    }
}
