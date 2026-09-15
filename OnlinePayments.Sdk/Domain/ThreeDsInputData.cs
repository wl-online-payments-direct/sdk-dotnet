/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ThreeDsInputData
    {
        /// <summary>
        /// Merchant’s Acquirer ID.
        /// </summary>
        public string AcquirerId { get; set; }

        /// <summary>
        /// Acquirer’s Merchant ID.
        /// </summary>
        public string AcquirerMid { get; set; }

        /// <summary>
        /// The ID assigned to the merchant for authentication request to initiate 3DS with MPI.
        /// </summary>
        public string RequestorId { get; set; }
    }
}
