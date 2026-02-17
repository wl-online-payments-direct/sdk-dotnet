/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateCertificateResponse
    {
        /// <summary>
        /// A unique identifier for the certificate generated on the GoPay platform, facilitating effective tracking and management of detokenization actions.
        /// </summary>
        public string CertificateId { get; set; }

        /// <summary>
        /// The signed certificate in base64 encoded string format, used for secure communication and authentication in API transactions.
        /// </summary>
        public string SignedCertificate { get; set; }
    }
}
