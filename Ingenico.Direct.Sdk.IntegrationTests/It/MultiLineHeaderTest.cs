using NUnit.Framework;
using Ingenico.Direct.Sdk.Merchant.Products;
using Ingenico.Direct.Sdk.Domain;
using System.Threading.Tasks;
using System.Reflection;
using System;

namespace Ingenico.Direct.Sdk.It
{
    public class MultiLineHeaderTest : IntegrationTest
    {
        [TestCase]
        public async Task Test()
        {
            CommunicatorConfiguration configuration = GetCommunicatorConfiguration();

            string multiLineHeader = " some value  \r\n \n with  some \r\n  spaces ";
            MetaDataProvider metaDataProvider = new MetaDataProviderBuilder("Ingenico")
                    .WithAdditionalRequestHeader(new RequestHeader("X-GCS-MultiLineHeader", multiLineHeader))
                    .Build();

            var lParams = new GetPaymentProductsParams
            {
                CountryCode = "NL",
                CurrencyCode = "EUR"
            };

            using (IClient client = Factory.CreateClient(configuration))
            {
                OverrideMetaDataProvider(client, metaDataProvider);
                GetPaymentProductsResponse response = await client
                    .WithNewMerchant(GetMerchantId())
                    .Products
                    .GetPaymentProducts(lParams)
                    .ConfigureAwait(false);

                Assert.That(response.PaymentProducts, Is.Not.Empty);
            }
        }

        [TestCase]
        public async Task SimpleTest()
        {
            CommunicatorConfiguration configuration = GetCommunicatorConfiguration();

            string multiLineHeader = "some\nvalue";
            MetaDataProvider metaDataProvider = new MetaDataProviderBuilder("Ingenico")
                    .WithAdditionalRequestHeader(new RequestHeader("X-GCS-MultiLineHeader", multiLineHeader))
                    .Build();

            using (IClient client = Factory.CreateClient(configuration))
            {
                OverrideMetaDataProvider(client, metaDataProvider);
                await client
                    .WithNewMerchant(GetMerchantId())
                    .Services
                    .TestConnection()
                    .ConfigureAwait(false);
            }
        }

        private static void OverrideMetaDataProvider(IClient client, MetaDataProvider metaDataProvider)
        {
            Type clientType = client.GetType();
            FieldInfo clientCommunicatorField = clientType.BaseType.GetField("_communicator", BindingFlags.NonPublic | BindingFlags.Instance);
            Communicator clientCommunicator = (Communicator) clientCommunicatorField.GetValue(client);

            Type typeCommunicator = clientCommunicator.GetType();
            PropertyInfo communicatorMetaDataProviderProperty = typeCommunicator.GetProperty("MetaDataProvider");
            communicatorMetaDataProviderProperty.SetValue(clientCommunicator, metaDataProvider);
        }
    }
}
