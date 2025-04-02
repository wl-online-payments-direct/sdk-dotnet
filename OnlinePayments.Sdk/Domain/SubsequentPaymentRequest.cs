/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentPaymentRequest
    {
        /// <summary>
        /// Order object containing order related data
        /// Please note that this object is required to be able to submit the amount.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// specific data required for Bizum subsequent payment
        /// </summary>
        public SubsequentPaymentProduct5001SpecificInput SubsequentPaymentProduct5001SpecificInput { get; set; }

        /// <summary>
        /// Object containing the specific input details for subsequent card payments
        /// </summary>
        public SubsequentCardPaymentMethodSpecificInput SubsequentcardPaymentMethodSpecificInput { get; set; }
    }
}
