﻿using Aliyun.Acs.Core.Transform;
using Ding.Sms.AliYun.Dysmsapi.Model.V20170525;

namespace Ding.Sms.AliYun.Dysmsapi.Transform.V20170525
{
    public class SendSmsResponseUnmarshaller
    {
        public static SendSmsResponse Unmarshall(UnmarshallerContext context)
        {
            SendSmsResponse sendSmsResponse = new SendSmsResponse
            {
                HttpResponse = context.HttpResponse,
                RequestId = context.StringValue("SendSms.RequestId"),
                BizId = context.StringValue("SendSms.BizId"),
                Code = context.StringValue("SendSms.Code"),
                Message = context.StringValue("SendSms.Message")
            };

            return sendSmsResponse;
        }
    }
}
