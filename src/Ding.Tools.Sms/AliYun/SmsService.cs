﻿using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Ding.Sms.AliYun.Dysmsapi.Model.V20170525;
using System;
using System.Threading.Tasks;

namespace Ding.Sms.AliYun
{
    /// <summary>
    /// 阿里云短信服务
    /// </summary>
    public class SmsService : ISmsService
    {
        /// <summary>
        /// 短信配置提供器
        /// </summary>
        private readonly ISmsConfigProvider _configProvider;

        /// <summary>
        /// 产品名称:云通信短信API产品,开发者无需替换
        /// </summary>
        const String product = "Dysmsapi";

        /// <summary>
        /// 产品域名,开发者无需替换
        /// </summary>
        const String domain = "dysmsapi.aliyuncs.com";

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
        /// 发送短信
        /// </summary>
        /// <param name="mobile">手机号,可批量，用逗号分隔开，上限为1000个</param>
        /// <param name="templatecode">短信模板-可在短信控制台中找到</param>
        /// <param name="templateparam">模板中的变量替换JSON串</param>
        /// <param name="outid">为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者</param>
        public async Task<SmsResult> SendAsync(string mobile, string templatecode, string templateparam,
            string outid)
        {
            var config = await _configProvider.GetConfigAsync();
            var accessKeyId = config.AccessKeyId;
            var accessKeySecret = config.AccessKeySecret;
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            SendSmsResponse response = null;
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = mobile;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = config.SignName;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = templatecode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = templateparam;
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = outid;
                //请求失败这里会抛ClientException异常
                response = acsClient.GetAcsResponse(request);
            }
            catch (ServerException e)
            {
                Console.WriteLine(e.ErrorCode);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e.ErrorCode);
            }

            response.CheckNull(nameof(response));
            if (response.Code == "OK")
                return SmsResult.Ok;
            if (response.Code == "isv.MOBILE_NUMBER_ILLEGAL")
                return new SmsResult(false, response.Message, SmsErrorCode.MobileError);
            return new SmsResult(false, response.Message);
        }

        public Task<SmsResult> SendAsync(string mobile, string content)
        {
            throw new NotImplementedException();
        }
    }
}
