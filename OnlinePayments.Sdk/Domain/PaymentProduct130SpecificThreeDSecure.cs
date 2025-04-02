/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct130SpecificThreeDSecure
    {
        /// <summary>
        /// Indicates the Acquirer TRA exemption
        /// </summary>
        public bool? AcquirerExemption { get; set; }

        /// <summary>
        /// Score calculated by the 3DS Requestor and provided to CB Scoring service only.
        /// </summary>
        public string MerchantScore { get; set; }

        /// <summary>
        /// Number of purchased items or services. 99 if more than 99 items
        /// </summary>
        public int? NumberOfItems { get; set; }

        /// <summary>
        /// Indicates the type of payment for which an authentication is requested
        /// </summary>
        public string Usecase { get; set; }
    }
}
