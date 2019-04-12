using Microsoft.AspNetCore.Authorization;

namespace DCLGB.Auth
{
    public class H5AuthorizeAttribute : AuthorizeAttribute
    {
        public const string H5AuthenticationScheme = "H5AuthenticationScheme";
        public H5AuthorizeAttribute()
        {
            AuthenticationSchemes = H5AuthenticationScheme;
        }
    }
}
