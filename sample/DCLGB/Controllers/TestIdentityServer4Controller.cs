using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DCLGB.Controllers
{
    /// <summary>
    /// 测试 IdentityServer4 相关功能
    /// </summary>
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestIdentityServer4Controller : WebApiControllerBase
    {
        /// <summary>
        /// 获取授权信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("GetInfo")]
        public string GetInfo(int id)
        {
            return id.ToString();
        }
    }
}
