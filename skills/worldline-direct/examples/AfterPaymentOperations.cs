using System;
using System.Threading.Tasks;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    // Each method takes an idempotence key. Create it once per operation (e.g. when someone clicks
    // "Refund") and store it. Pass the same key again if the request got no answer; see ErrorHandling.cs.
    public class AfterPaymentOperationsExample
    {
        private readonly IMerchantClient _merchantClient;

        public AfterPaymentOperationsExample(IMerchantClient merchantClient)
        {
            _merchantClient = merchantClient;
        }

        // [START capture-payment]
        // Captures an authorized payment (status PENDING_CAPTURE). Leave Amount out to capture the full amount.
        public async Task<CaptureResponse> Capture(string paymentId, long amountInCents, bool isFinal, string idempotenceKey)
        {
            PaymentDetailsResponse details = await _merchantClient.Payments.GetPaymentDetails(paymentId);
            if (details.Status != "PENDING_CAPTURE")
            {
                throw new InvalidOperationException("Payment " + paymentId + " cannot be captured in status " + details.Status);
            }

            var request = new CapturePaymentRequest
            {
                Amount = amountInCents,
                // true: this capture is final, no further capture is accepted.
                IsFinal = isFinal,
            };
            var context = new CallContext().WithIdempotenceKey(idempotenceKey);
            return await _merchantClient.Payments.CapturePayment(paymentId, request, context);
        }
        // [END capture-payment]

        // [START refund-payment]
        // Refunds a captured payment, fully or partly.
        public async Task<RefundResponse> Refund(string paymentId, long amountInCents, string currencyCode, string idempotenceKey)
        {
            PaymentDetailsResponse details = await _merchantClient.Payments.GetPaymentDetails(paymentId);
            if (details.StatusOutput?.IsRefundable != true)
            {
                throw new InvalidOperationException("Payment " + paymentId + " is not refundable in status " + details.Status);
            }

            var request = new RefundRequest
            {
                AmountOfMoney = new AmountOfMoney { Amount = amountInCents, CurrencyCode = currencyCode },
            };
            var context = new CallContext().WithIdempotenceKey(idempotenceKey);
            RefundResponse refund = await _merchantClient.Payments.RefundPayment(paymentId, request, context);

            // REFUND_REQUESTED: the platform is processing the refund and waiting for the result. The status
            // then becomes REFUNDED or REJECTED; treat the refund as done only when it is REFUNDED.
            return refund;
        }
        // [END refund-payment]

        // [START cancel-payment]
        // Cancels (voids) an authorization that is not captured yet. No amount cancels the full amount.
        public async Task<CancelPaymentResponse> Cancel(string paymentId, string idempotenceKey)
        {
            PaymentDetailsResponse details = await _merchantClient.Payments.GetPaymentDetails(paymentId);
            if (details.StatusOutput?.IsCancellable != true)
            {
                throw new InvalidOperationException("Payment " + paymentId + " is not cancellable in status " + details.Status);
            }

            var context = new CallContext().WithIdempotenceKey(idempotenceKey);
            return await _merchantClient.Payments.CancelPayment(paymentId, new CancelPaymentRequest(), context);
        }
        // [END cancel-payment]
    }
}
