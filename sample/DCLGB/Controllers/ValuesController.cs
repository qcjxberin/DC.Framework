using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ding.Helpers;
using Ding.Webs.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCLGB.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : WebApiControllerBase
    {
        /// <summary>
        /// 测试1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<string>> Get()
        {
            //var BspAdmingroupsService = Ioc.Create<IBspAdmingroupsService>();
            //var list = await BspAdmingroupsService.GetAllAsync();

            //var str = list.Join(",");

            //return new string[] { "value1", "value2", list.Count.ToString() };

            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
