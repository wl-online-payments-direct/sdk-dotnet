/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentPaymentRequest
    {
        /// <summary>
        /// Order object containing order related data <para />
        ///  Please note that this object is required to be able to submit the amount.<para />
        /// </summary>
        public Order Order { get; set; } = null;

        /// <summary>
        /// specific data required for Bizum subsequent payment<para />
        /// </summary>
        public SubsequentPaymentProduct5001SpecificInput SubsequentPaymentProduct5001SpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing the specific input details for subsequent card payments<para />
        /// </summary>
        public SubsequentCardPaymentMethodSpecificInput SubsequentcardPaymentMethodSpecificInput { get; set; } = null;
    }
}
