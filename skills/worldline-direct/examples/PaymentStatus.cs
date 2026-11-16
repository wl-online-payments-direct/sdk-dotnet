using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class PaymentStatusExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;

        public PaymentStatusExample(IMerchantClient merchantClient, IOrderStore orders)
        {
            _merchantClient = merchantClient;
            _orders = orders;
        }

        // [START payment-status]
        public async Task<OrderPaymentState> RefreshPaymentState(string orderId)
        {
            string paymentId = _orders.GetPaymentId(orderId);
            PaymentDetailsResponse details = await _merchantClient.Payments.GetPaymentDetails(paymentId);

            OrderPaymentState state = ToOrderState(details.Status, details.StatusOutput);
            _orders.SaveState(orderId, state);
            return state;
        }

        // Decide on StatusOutput.StatusCategory. Status and StatusOutput.StatusCode give more detail.
        // StatusOutput can be missing in a response: that means "not final" (Pending), never "paid".
        public static OrderPaymentState ToOrderState(string status, PaymentStatusOutput statusOutput)
        {
            switch (statusOutput?.StatusCategory)
            {
                case "COMPLETED":
                    return OrderPaymentState.Paid;
                case "PENDING_MERCHANT":
                    // PENDING_CAPTURE: authorized but not captured yet, capture or cancel it.
                    // Any other status (CANCELLED, waiting for its final result) is not final.
                    return status == "PENDING_CAPTURE" ? OrderPaymentState.Authorized : OrderPaymentState.Pending;
                case "REFUNDED":
                    return OrderPaymentState.Refunded;
                case "REVERSED":
                    // Not paid: do not treat the order as paid.
                    return OrderPaymentState.Reversed;
                case "UNSUCCESSFUL":
                    return status == "CANCELLED" ? OrderPaymentState.Cancelled : OrderPaymentState.Failed;
                default:
                    // CREATED, PENDING_PAYMENT, PENDING_CONNECT_OR_3RD_PARTY: not final.
                    // Wait for a webhook or check again later.
                    return OrderPaymentState.Pending;
            }
        }
        // [END payment-status]
    }
}
