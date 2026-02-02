/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentPaymentRequest
    {
        /// <summary>
        /// This object contains additional subsequent details for omnichannel merchants.
        /// </summary>
        public OmnichannelSubsequentSpecificInput OmnichannelSubsequentSpecificInput { get; set; }

        /// <summary>
        /// The order object contains order-related data;
        /// Please note that this object is required to submit the amount.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Specific data is required for Bizum subsequent payment.
        /// </summary>
        public SubsequentPaymentProduct5001SpecificInput SubsequentPaymentProduct5001SpecificInput { get; set; }

        /// <summary>
        /// Object containing the specific input details for subsequent card payments
        /// </summary>
        public SubsequentCardPaymentMethodSpecificInput SubsequentcardPaymentMethodSpecificInput { get; set; }
    }
}
