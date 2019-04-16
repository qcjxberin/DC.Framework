using Ding.BankCardValidation.Models.Results;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Ding.BankCardValidation.Core
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class ReturnAttribute : JsonReturnAttribute
    {
        protected override async Task<object> GetTaskResult(ApiActionContext context)
        {
            var response = context.ResponseMessage;
            var bytes = await response.Content.ReadAsByteArrayAsync();

            var s = Encoding.UTF8.GetString(bytes);

            var json = JObject.Parse(s);
            return json.ToObject<ResponseData>();
        }
    }
}
