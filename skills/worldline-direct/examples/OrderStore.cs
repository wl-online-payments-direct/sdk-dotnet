namespace Examples
{
    /// <summary>
    /// Stand-in for your application's own persistence. The examples call it where your code must
    /// store or read data; replace it with your database code. Everything it keeps must survive a restart
    /// (a database, not memory); a demo that keeps it in memory must say so in its README.
    /// </summary>
    public interface IOrderStore
    {
        void SaveIdempotenceKey(string orderId, string idempotenceKey);

        /// <summary>Returns null when no key is stored for the order.</summary>
        string GetIdempotenceKey(string orderId);

        void SaveHostedCheckout(string orderId, string hostedCheckoutId, string returnMac);

        StoredHostedCheckout GetHostedCheckout(string orderId);

        void SavePaymentId(string orderId, string paymentId);

        string GetPaymentId(string orderId);

        void SaveState(string orderId, OrderPaymentState state);

        void SaveRecurringPaymentId(string customerId, string initialPaymentId);

        string GetRecurringPaymentId(string customerId);
    }

    public class StoredHostedCheckout
    {
        public string HostedCheckoutId { get; set; }

        public string ReturnMac { get; set; }
    }

    /// <summary>The payment state of an order in your application.</summary>
    public enum OrderPaymentState
    {
        Pending,
        Authorized,
        Paid,
        Failed,
        Cancelled,
        Refunded,
        Reversed,
    }

    /// <summary>What the web layer must do after a create payment call.</summary>
    public class PaymentStep
    {
        public string RedirectUrl { get; private set; }

        public OrderPaymentState State { get; private set; }

        public bool IsRedirect => RedirectUrl != null;

        public static PaymentStep Redirect(string url) => new PaymentStep { RedirectUrl = url, State = OrderPaymentState.Pending };

        public static PaymentStep Done(OrderPaymentState state) => new PaymentStep { State = state };
    }
}
