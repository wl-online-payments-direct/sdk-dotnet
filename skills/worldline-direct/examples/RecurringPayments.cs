using System;
using System.Threading.Tasks;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class RecurringPaymentsExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;
        private readonly HostedCheckoutExample _hostedCheckout;

        public RecurringPaymentsExample(IMerchantClient merchantClient, IOrderStore orders, HostedCheckoutExample hostedCheckout)
        {
            _merchantClient = merchantClient;
            _orders = orders;
            _hostedCheckout = hostedCheckout;
        }

        // [START recurring-first]
        // First payment of a subscription, made by the customer on the Hosted Checkout Page.
        // The recurring flag marks it as the first payment of the series.
        // It follows the Hosted Checkout flow: the return URL is built from your configuration and the call goes
        // through the same retry helper. Handle the return as there.
        public async Task<string> StartSubscription(string orderId, long amountInCents, string currencyCode)
        {
            var request = new CreateHostedCheckoutRequest
            {
                Order = new Order
                {
                    AmountOfMoney = new AmountOfMoney { Amount = amountInCents, CurrencyCode = currencyCode },
                    References = new OrderReferences { MerchantReference = orderId },
                },
                HostedCheckoutSpecificInput = new HostedCheckoutSpecificInput
                {
                    ReturnUrl = _hostedCheckout.BuildReturnUrl(orderId),
                    IsRecurring = true,
                },
            };

            CreateHostedCheckoutResponse response = await _hostedCheckout.CreateHostedCheckoutWithRetry(request);
            _orders.SaveHostedCheckout(orderId, response.HostedCheckoutId, response.RETURNMAC);
            return response.RedirectUrl;
        }

        // When the first payment is authorised or captured, keep its payment ID: later charges refer to it.
        public void OnFirstPaymentSucceeded(string customerId, string firstPaymentId)
        {
            _orders.SaveRecurringPaymentId(customerId, firstPaymentId);
        }
        // [END recurring-first]

        // [START recurring-subsequent]
        // Later charge started by you, without the customer (merchant-initiated). The caller creates ONE idempotence
        // key per charge and stores it with the charge (_orders.SaveIdempotenceKey(orderId, key)) before the first
        // call. On a retry, pass the same key again; the retry rules are in errors.md.
        public async Task<OrderPaymentState> ChargeRenewal(
            string customerId, string orderId, long amountInCents, string currencyCode, string idempotenceKey)
        {
            string firstPaymentId = _orders.GetRecurringPaymentId(customerId);

            var request = new SubsequentPaymentRequest
            {
                Order = new Order
                {
                    AmountOfMoney = new AmountOfMoney { Amount = amountInCents, CurrencyCode = currencyCode },
                    References = new OrderReferences { MerchantReference = orderId },
                },
                SubsequentcardPaymentMethodSpecificInput = new SubsequentCardPaymentMethodSpecificInput
                {
                    // Recurring = fixed amount, regular intervals (at most one year), started by you.
                    // Other allowed values: Unscheduled, Installment, NoShow, DelayedCharge, PartialShipment,
                    // Resubmission, RecurringVariable, UnscheduledFixed.
                    SubsequentType = "Recurring",
                    // SALE: authorised and captured at once. Acquirers that do not support it ignore it.
                    AuthorizationMode = "SALE",
                },
            };

            var context = new CallContext().WithIdempotenceKey(idempotenceKey);
            SubsequentPaymentResponse response = await _merchantClient.Subsequent.SubsequentPayment(firstPaymentId, request, context);

            _orders.SavePaymentId(orderId, response.Payment.Id);
            OrderPaymentState state = PaymentStatusExample.ToOrderState(response.Payment.Status, response.Payment.StatusOutput);
            _orders.SaveState(orderId, state);
            return state;
        }
        // [END recurring-subsequent]
    }
}
