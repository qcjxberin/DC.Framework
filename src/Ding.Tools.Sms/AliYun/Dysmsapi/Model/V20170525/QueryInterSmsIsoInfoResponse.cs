using System.Collections.Generic;

namespace Ding.Sms.AliYun.Dysmsapi.Model.V20170525
{
    public class QueryInterSmsIsoInfoResponse : AcsResponse
    {
        private string requestId;

        private string code;

        private string message;

        private List<QueryInterSmsIsoInfo_IsoSupportDTO> isoSupportDTOs;

        public string RequestId
        {
            get { return requestId; }
            set { requestId = value; }
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

        public List<QueryInterSmsIsoInfo_IsoSupportDTO> IsoSupportDTOs
        {
            get { return isoSupportDTOs; }
            set { isoSupportDTOs = value; }
        }

        public class QueryInterSmsIsoInfo_IsoSupportDTO
        {
            private string countryName;

            private string countryCode;

            private string isoCode;

            public string CountryName
            {
                get { return countryName; }
                set { countryName = value; }
            }

            public string CountryCode
            {
                get { return countryCode; }
                set { countryCode = value; }
            }

            public string IsoCode
            {
                get { return isoCode; }
                set { isoCode = value; }
            }
        }
    }
}
