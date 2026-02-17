/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateHostedFieldsSessionResponse
    {
        /// <summary>
        /// This is the cryptographic hash used for Subresource Integrity validation.
        /// </summary>
        public string SdkSri { get; set; }

        /// <summary>
        /// The URL points to the hosted fields SDK.
        /// </summary>
        public string SdkUrl { get; set; }

        /// <summary>
        /// This contains the data required to initialize the Hosted Fields SDK.
        /// </summary>
        public SessionData SessionData { get; set; }
    }
}
