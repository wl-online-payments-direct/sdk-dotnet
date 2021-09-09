using Ingenico.Direct.Sdk.DefaultImpl;
using System;

namespace Ingenico.Direct.Sdk.It
{
    public abstract class IntegrationTest
    {
        readonly string ApiKeyId = Environment.GetEnvironmentVariable("direct.api.apiKeyId");
        readonly string SecretApiKey = Environment.GetEnvironmentVariable("direct.api.secretApiKey");
        readonly string MerchantId = Environment.GetEnvironmentVariable("direct.api.merchantId");
        readonly string EndpointHost = Environment.GetEnvironmentVariable("direct.api.endpoint.host");
        readonly string EndpointScheme = Environment.GetEnvironmentVariable("direct.api.endpoint.scheme");
        readonly string EndpointPort = Environment.GetEnvironmentVariable("direct.api.endpoint.port");

        protected CommunicatorConfiguration GetCommunicatorConfiguration()
        {
            if (ApiKeyId == null || SecretApiKey == null)
            {
                throw new System.InvalidOperationException("Environment variables direct.api.apiKeyId and direct.api.secretApiKey must be set");
            }
            return Factory.CreateConfiguration(ApiKeyId, SecretApiKey, GetEndpoint(), "Ingenico");
        }

        protected Client GetClient()
        {
            if (ApiKeyId != null && SecretApiKey != null)
            {
                return Factory.CreateClient(ApiKeyId, SecretApiKey, GetEndpoint(), "Ingenico").WithClientMetaInfo("{\"test\":\"test\"}");
            }
            throw new System.InvalidOperationException("Environment variables direct.api.apiKeyId and direct.api.secretApiKey must be set");
        }

        protected string GetMerchantId()
        {
            if (MerchantId != null)
            {
                return MerchantId;
            }
            throw new System.InvalidOperationException("Environment variable direct.api.merchantId must be set");
        }

        private Uri GetEndpoint()
        {
            if (EndpointHost == null)
            {
                throw new InvalidOperationException("Environment variable direct.api.endpoint.host must be set");
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
