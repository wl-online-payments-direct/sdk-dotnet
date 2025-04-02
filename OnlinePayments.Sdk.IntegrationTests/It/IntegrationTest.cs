using System;

namespace OnlinePayments.Sdk.It
{
    public abstract class IntegrationTest
    {
        private readonly string _merchantId = Environment.GetEnvironmentVariable("onlinePayments_api_merchantId");
        private readonly string _apiKeyId = Environment.GetEnvironmentVariable("onlinePayments_api_apiKeyId");
        private readonly string _secretApiKey = Environment.GetEnvironmentVariable("onlinePayments_api_secretApiKey");

        protected CommunicatorConfiguration GetCommunicatorConfiguration()
        {
            if (_apiKeyId == null || _secretApiKey == null)
            {
                throw new InvalidOperationException("Environment variables onlinePayments_api_apiKeyId and onlinePayments_api_secretApiKey must be set");
            }
            return Factory.CreateConfiguration(_apiKeyId, _secretApiKey);
        }

        protected IClient GetClient()
        {
            if (_apiKeyId != null && _secretApiKey != null)
            {
                return Factory.CreateClient(_apiKeyId, _secretApiKey).WithClientMetaInfo("{\"test\":\"test\"}");
            }
            throw new InvalidOperationException("Environment variables onlinePayments_api_apiKeyId and onlinePayments_api_secretApiKey must be set");
        }

        protected string GetMerchantId()
        {
            if (_merchantId != null)
            {
                return _merchantId;
            }
            throw new InvalidOperationException("Environment variable onlinePayments_api_merchantId must be set");
        }
    }
}
