using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant.Tokens;
using OnlinePayments.Sdk.Logging;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.It
{
    public class TokenTest : IntegrationTest
    {
        /// <summary>
        /// Smoke Test for token calls.
        /// </summary>
        [TestCase]
        public async Task Test()
        {
            CreateTokenRequest createTokenRequest = new CreateTokenRequest
            {
                PaymentProductId = 1,
                Card = new TokenCardSpecificInput
                {
                    Data = new TokenData
                    {
                        Card = new Card
                        {
                            CardholderName = "Jan",
                            CardNumber = "4567350000427977",
                            Cvv = "123",
                            ExpiryDate = "1230"
                        }
                    }
                }
            };

            using (Client client = GetClient())
            {
                client.EnableLogging(SystemConsoleCommunicatorLogger.Instance);
                CreatedTokenResponse createTokenResponse = await client
                    .WithNewMerchant(GetMerchantId())
                    .Tokens
                    .CreateToken(createTokenRequest)
                    .ConfigureAwait(false);

                Assert.NotNull(createTokenResponse.Token);

                await client
                    .WithNewMerchant(GetMerchantId())
                    .Tokens
                    .DeleteToken(createTokenResponse.Token)
                    .ConfigureAwait(false);
            }
        }
    }
}
