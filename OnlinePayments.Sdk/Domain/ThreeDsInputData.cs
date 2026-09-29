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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ThreeDsInputData WithAcquirerId(string value)
        {
            AcquirerId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ThreeDsInputData WithAcquirerMid(string value)
        {
            AcquirerMid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ThreeDsInputData WithRequestorId(string value)
        {
            RequestorId = value;
            return this;
        }
    }
}
