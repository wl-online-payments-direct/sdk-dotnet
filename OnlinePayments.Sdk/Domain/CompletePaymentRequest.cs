/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CompletePaymentRequest
    {
        public CompletePaymentCardPaymentMethodSpecificInput CardPaymentMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// Order object containing order related data <para />
        ///  Please note that this object is required to be able to submit the amount.<para />
        /// </summary>
        public Order Order { get; set; } = null;
    }
}
