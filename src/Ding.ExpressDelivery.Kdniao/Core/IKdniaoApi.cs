using Ding.ExpressDelivery.Kdniao.Models.Results;
using System.Net.Http;
using WebApiClient;
using WebApiClient.Attributes;

namespace Ding.ExpressDelivery.Kdniao.Core
{
    /// <summary>
    /// 快递鸟 API
    /// </summary>
    [HttpHost("http://api.kdniao.com")]
    public interface IKdniaoApi : IHttpApi
    {
        /// <summary>
        /// 即时查询
        /// </summary>
        /// <param name="content">请求内容</param>
        /// <returns></returns>
        [HttpPost("/Ebusiness/EbusinessOrderHandle.aspx")]
        [JsonReturn]
        ITask<KdniaoTrackQueryResult> TrackAsync(FormUrlEncodedContent content);

        /// <summary>
        /// 电子面单
        /// </summary>
        /// <param name="content">请求内容</param>
        /// <returns></returns>
        [HttpPost("/api/EOrderService")]
        [JsonReturn]
        ITask<KdniaoTrackQueryResult> ExterFaceAsync(FormUrlEncodedContent content);
    }
}
