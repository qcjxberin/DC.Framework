namespace Ding.Sms.AliYun.Dysmsapi.Transform.V20170525
{
    public class SendInterSmsResponseUnmarshaller
    {
        public static SendInterSmsResponse Unmarshall(UnmarshallerContext context)
        {
            SendInterSmsResponse sendInterSmsResponse = new SendInterSmsResponse();

            sendInterSmsResponse.HttpResponse = context.HttpResponse;
            sendInterSmsResponse.RequestId = context.StringValue("SendInterSms.RequestId");
            sendInterSmsResponse.BizId = context.StringValue("SendInterSms.BizId");
            sendInterSmsResponse.Code = context.StringValue("SendInterSms.Code");
            sendInterSmsResponse.Message = context.StringValue("SendInterSms.Message");

            return sendInterSmsResponse;
        }
    }
}
