namespace Ding.Sms.AliYun.Dysmsapi.Transform.V20170525
{
    public class SendBatchSmsResponseUnmarshaller
    {
        public static SendBatchSmsResponse Unmarshall(UnmarshallerContext context)
        {
            SendBatchSmsResponse sendBatchSmsResponse = new SendBatchSmsResponse();

            sendBatchSmsResponse.HttpResponse = context.HttpResponse;
            sendBatchSmsResponse.RequestId = context.StringValue("SendBatchSms.RequestId");
            sendBatchSmsResponse.BizId = context.StringValue("SendBatchSms.BizId");
            sendBatchSmsResponse.Code = context.StringValue("SendBatchSms.Code");
            sendBatchSmsResponse.Message = context.StringValue("SendBatchSms.Message");

            return sendBatchSmsResponse;
        }
    }
}
