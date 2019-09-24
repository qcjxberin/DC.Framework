using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ding.Swashbuckle.Controllers
{
    /// <summary>
    /// Swagger 控制器
    /// </summary>
    [AllowAnonymous]
    [Route("api/swagger")]
    public class SwaggerController : Controller
    {
    }
}
