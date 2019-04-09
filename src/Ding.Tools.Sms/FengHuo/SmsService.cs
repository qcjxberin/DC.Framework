using Ding.Helpers;
using System;
using System.Threading.Tasks;
using Ding.Utils.Helpers;

namespace Ding.Sms.FengHuo
{
    /// <summary>
    /// 短信服务
    /// </summary>
    public class SmsService : ISmsService
    {
        /// <summary>
        /// 短信配置提供器
        /// </summary>
        private readonly ISmsConfigProvider _configProvider;

        /// <summary>
        /// 初始化短信服务
        /// </summary>
        /// <param name="configProvider">短信配置提供器</param>
        public SmsService(ISmsConfigProvider configProvider)
        {
            configProvider.CheckNull(nameof(configProvider));
            _configProvider = configProvider;
        }

        /// <summary>
        /// 获取YYYYMMDDHHMISS格式当前时间
        /// </summary>
        /// <returns></returns>
        private string GetSeed()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// 获取加密数据
        /// </summary>
        /// <param name="seed">时间</param>
        /// <param name="config">配置项</param>
        /// <returns></returns>
        private string GetKey(string seed, SmsConfig config)
        {
            var key = Encrypt.Md5By32(config.PassWrod).ToLower();
            return Encrypt.Md5By32(key + seed).ToLower();
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号,可批量，用逗号分隔开，上限为1000个</param>
        /// <param name="content">内容</param>
        public async Task<SmsResult> SendAsync(string mobile, string content)
        {
            var config = await _configProvider.GetConfigAsync();
            var seed = GetSeed();
            var key = GetKey(seed, config);
            var sendaction = config.Url + "send.do";

            var result = await Web.Client().Post(sendaction)
                .Data("name", config.Name)
                .Data("seed", seed)
                .Data("key", key)
                .Data("dest", mobile)
                .Data("content", content)
                .ResultAsync();
            if (result.Contains("success"))
            {
                return new SmsResult(true, result);
            }
            else
            {
                return new SmsResult(false, result);
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号,可批量，用逗号分隔开，上限为1000个</param>
        /// <param name="templatecode">短信模板-可在短信控制台中找到</param>
        /// <param name="templateparam">模板中的变量替换JSON串</param>
        /// <param name="outid">为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者</param>
        public Task<SmsResult> SendAsync(string mobile, string templatecode, string templateparam, string outid)
        {
            throw new System.NotImplementedException();
        }
    }
}
