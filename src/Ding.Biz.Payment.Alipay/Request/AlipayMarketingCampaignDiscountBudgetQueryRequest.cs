using System.Collections.Generic;
using Ding.Payment.Alipay.Response;

namespace Ding.Payment.Alipay.Request
{
    /// <summary>
    /// AOP API: alipay.marketing.campaign.discount.budget.query
    /// </summary>
    public class AlipayMarketingCampaignDiscountBudgetQueryRequest : IAlipayRequest<AlipayMarketingCampaignDiscountBudgetQueryResponse>
    {
        /// <summary>
        /// 营销立减活动预算查询
        /// </summary>
        public string BizContent { get; set; }

        #region IAlipayRequest Members

        private bool  needEncrypt;
        private string apiVersion = "1.0";
        private string terminalType;
        private string terminalInfo;
        private string prodCode;
        private string notifyUrl;
        private string returnUrl;
        private AlipayObject bizModel;

        public void SetNeedEncrypt(bool needEncrypt){
             this.needEncrypt=needEncrypt;
        }

        public bool GetNeedEncrypt(){

            return needEncrypt;
        }

        public void SetNotifyUrl(string notifyUrl){
            this.notifyUrl = notifyUrl;
        }

        public string GetNotifyUrl(){
            return notifyUrl;
        }

        public void SetReturnUrl(string returnUrl){
            this.returnUrl = returnUrl;
        }

        public string GetReturnUrl(){
            return returnUrl;
        }

        public void SetTerminalType(string terminalType){
			this.terminalType=terminalType;
		}

        public string GetTerminalType(){
    		return terminalType;
    	}

        public void SetTerminalInfo(string terminalInfo){
    		this.terminalInfo=terminalInfo;
    	}

        public string GetTerminalInfo(){
    		return terminalInfo;
    	}

        public void SetProdCode(string prodCode){
            this.prodCode=prodCode;
        }

        public string GetProdCode(){
            return prodCode;
        }

        public string GetApiName()
        {
            return "alipay.marketing.campaign.discount.budget.query";
        }

        public void SetApiVersion(string apiVersion){
            this.apiVersion=apiVersion;
        }

        public string GetApiVersion(){
            return apiVersion;
        }

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new AlipayDictionary
            {
                { "biz_content", BizContent }
            };
            return parameters;
        }

        public AlipayObject GetBizModel()
        {
            return bizModel;
        }

        public void SetBizModel(AlipayObject bizModel)
        {
            this.bizModel = bizModel;
        }

        #endregion
    }
}
