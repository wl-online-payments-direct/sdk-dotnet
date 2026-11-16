using System;
using System.Threading.Tasks;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class PaymentLinksExample
    {
        private readonly IMerchantClient _merchantClient;

        public PaymentLinksExample(IMerchantClient merchantClient)
        {
            _merchantClient = merchantClient;
        }

        // [START payment-link-create]
        // Returns the link to send to the customer (email, chat, invoice).
        public async Task<PaymentLinkResponse> CreateLink(string orderId, long amountInCents, string currencyCode, string description)
        {
            var request = new CreatePaymentLinkRequest
            {
                Order = new Order
                {
                    AmountOfMoney = new AmountOfMoney { Amount = amountInCents, CurrencyCode = currencyCode },
                    References = new OrderReferences { MerchantReference = orderId },
                },
                PaymentLinkSpecificInput = new PaymentLinkSpecificInput
                {
                    Description = description,
                    // Required. At most 6 months in the future.
                    ExpirationDate = DateTimeOffset.UtcNow.AddDays(7),
                },
            };

            // CreatePaymentLink does not support idempotent requests, so no idempotence key is sent.
            PaymentLinkResponse link = await _merchantClient.PaymentLinks.CreatePaymentLink(request);

            // Store link.PaymentLinkId with the order. Send link.RedirectionUrl exactly as returned.
            // The paymentlink.paid webhook (or GetPaymentLinkById) tells you when it is paid.
            // Once paid, the link's PaymentId has no attempt suffix: use it with "_0" appended in
            // GetPaymentDetails, and read the payment's status.
            return link;
        }
        // [END payment-link-create]
    }
}
