namespace Microsoft.AspNetCore.Mvc
{
    public interface IRequestTemplateProvider
    {
        string DetermineRequestTemplate();
    }
}
