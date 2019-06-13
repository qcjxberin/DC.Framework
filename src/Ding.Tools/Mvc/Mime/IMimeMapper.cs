#if __WIN__

namespace Ding.Tools.Mvc.Mime
{
    public interface IMimeMapper
    {
        IMimeMapper Extend(params MimeMappingItem[] extensions);
        string GetMimeFromExtension(string fileExtension);
        string GetMimeFromPath(string filePath);
    }
}
#endif