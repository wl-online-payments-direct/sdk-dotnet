using OnlinePayments.Sdk.DefaultImpl;
using System;

namespace OnlinePayments.Sdk.It
{
    public abstract class IntegrationTest
    {
        readonly string ApiKeyId = Environment.GetEnvironmentVariable("onlinePayments.api.apiKeyId");
        readonly string SecretApiKey = Environment.GetEnvironmentVariable("onlinePayments.api.secretApiKey");
        readonly string MerchantId = Environment.GetEnvironmentVariable("onlinePayments.api.merchantId");
        readonly string EndpointHost = Environment.GetEnvironmentVariable("onlinePayments.api.endpoint.host");
        readonly string EndpointScheme = Environment.GetEnvironmentVariable("onlinePayments.api.endpoint.scheme");
        readonly string EndpointPort = Environment.GetEnvironmentVariable("onlinePayments.api.endpoint.port");

        protected CommunicatorConfiguration GetCommunicatorConfiguration()
        {
            if (ApiKeyId == null || SecretApiKey == null)
            {
                throw new System.InvalidOperationException("Environment variables onlinePayments.api.apiKeyId and onlinePayments.api.secretApiKey must be set");
            }
            return Factory.CreateConfiguration(ApiKeyId, SecretApiKey, GetEndpoint(), "OnlinePayments");
        }

        protected Client GetClient()
        {
            if (ApiKeyId != null && SecretApiKey != null)
            {
                return Factory.CreateClient(ApiKeyId, SecretApiKey, GetEndpoint(), "OnlinePayments").WithClientMetaInfo("{\"test\":\"test\"}");
            }
            throw new System.InvalidOperationException("Environment variables onlinePayments.api.apiKeyId and onlinePayments.api.secretApiKey must be set");
        }

        protected string GetMerchantId()
        {
            if (MerchantId != null)
            {
                return MerchantId;
            }
            throw new System.InvalidOperationException("Environment variable onlinePayments.api.merchantId must be set");
        }

        private Uri GetEndpoint()
        {
            if (EndpointHost == null)
            {
                throw new InvalidOperationException("Environment variable onlinePayments.api.endpoint.host must be set");
            }
            String scheme = EndpointScheme ?? "https";
            int port = EndpointPort != null ? Int32.Parse(EndpointPort) : -1;
            try
            {
                return new UriBuilder(scheme, EndpointHost, port).Uri;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentException("Unable to construct API endpoint URI", e);
            }
        }
    }
}
