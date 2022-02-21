using NUnit.Framework;
using OnlinePayments.Sdk.Merchant.Services;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.DefaultImpl;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Util;

namespace OnlinePayments.Sdk.It
{
    public class SDKProxyTest : IntegrationTest
    {
        /// <summary>
        /// Smoke Test for using a proxy configured throught SDK properties.
        /// </summary>
        public async Task Test()
        {

            using (Client client = GetClient())
            {
                IServicesClient services = client
                    .WithNewMerchant(GetMerchantId())
                    .Services;

                Assert.That(services, Is.TypeOf(typeof(ServicesClient)));
                CommunicatorConfiguration configuration = GetCommunicatorConfiguration();
                Assert.NotNull(configuration.Proxy);
                AssertProxyAndAuthentication(GetConnectionFromService(services), configuration.Proxy);

                TestConnection response = await services.TestConnection()
                    .ConfigureAwait(false);

                Assert.NotNull(response.Result);
            }
        }

        static DefaultConnection GetConnectionFromService(IServicesClient services)
        {
            Communicator communicator = (Communicator)services.GetPrivateField("_communicator");
            return communicator.GetPrivateProperty<DefaultConnection>("Connection");
        }

        internal static void AssertProxy(DefaultConnection connection, Proxy proxy)
        {
            HttpClient httpClient = (HttpClient)connection.GetPrivateField("_httpClient");
            HttpClientHandler handler = (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler");
            Assert.That(handler.UseProxy, Is.True);
            Assert.That(((WebProxy)handler.Proxy).Address, Is.EqualTo(proxy.Uri));
            Assert.That(((NetworkCredential)handler.Proxy.Credentials), Is.Null);
        }

        internal void AssertProxyAndAuthentication(DefaultConnection connection, Proxy proxy)
        {
            HttpClient httpClient = (HttpClient)connection.GetPrivateField("_httpClient");
            HttpClientHandler handler = (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler");
            Assert.That(handler.UseProxy, Is.True);
            Assert.That(((WebProxy)handler.Proxy).Address, Is.EqualTo(proxy.Uri));
            Assert.That(((NetworkCredential)handler.Proxy.Credentials), Is.Null);
            Assert.That(((NetworkCredential)handler.Proxy.Credentials).UserName, Is.EqualTo(proxy.Username));
            Assert.That(((NetworkCredential)handler.Proxy.Credentials).Password, Is.EqualTo(proxy.Password));
        }
    }
}
