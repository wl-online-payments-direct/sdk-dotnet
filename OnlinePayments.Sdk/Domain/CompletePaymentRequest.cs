/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CompletePaymentRequest
    {
        public CompletePaymentCardPaymentMethodSpecificInput CardPaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// Order object containing order related data
        /// Please note that this object is required to be able to submit the amount.
        /// </summary>
        public Order Order { get; set; }
    }
}
