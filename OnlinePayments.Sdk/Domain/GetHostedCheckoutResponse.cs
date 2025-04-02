/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetHostedCheckoutResponse
    {
        /// <summary>
        /// This object will return the details of the payment after the payment is cancelled by the customer, rejected or authorized
        /// </summary>
        public CreatedPaymentOutput CreatedPaymentOutput { get; set; }

        /// <summary>
        /// This is the status of the hosted checkout. Possible values are:
        /// <list type="bullet">
        ///   <item><description>IN_PROGRESS - The checkout is still in progress and has not finished yet</description></item>
        ///   <item><description>PAYMENT_CREATED - A payment has been created</description></item>
        ///   <item><description>CANCELLED_BY_CONSUMER - The HostedCheckout session have been cancelled by the customer</description></item>
        /// </list>
        /// </summary>
        public string Status { get; set; }
    }
}
