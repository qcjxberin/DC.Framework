using System;
using System.Collections.Generic;
using System.Text;

namespace Ding.Sms.AliYun.Dysmsapi.Model.V20170525
{
    public class SendBatchSmsResponse : AcsResponse
    {
        private string requestId;

        private string bizId;

        private string code;

        private string message;

        public string RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }

        public string BizId
        {
            get { return bizId; }
            set { bizId = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
