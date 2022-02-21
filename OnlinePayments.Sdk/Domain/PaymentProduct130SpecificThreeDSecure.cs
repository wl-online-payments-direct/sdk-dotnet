/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct130SpecificThreeDSecure
    {
        /// <summary>
        /// Indicates the Acquirer TRA exemption<para />
        /// </summary>
        public bool? AcquirerExemption { get; set; } = null;

        /// <summary>
        /// Score calculated by the 3DS Requestor and provided to CB Scoring service only.<para />
        /// </summary>
        public string MerchantScore { get; set; } = null;

        /// <summary>
        /// Number of purchased items or services. 99 if more than 99 items<para />
        /// </summary>
        public int? NumberOfItems { get; set; } = null;

        /// <summary>
        /// Indicates the type of payment for which an authentication is requested<para />
        /// </summary>
        public string Usecase { get; set; } = null;
    }
}
