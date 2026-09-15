/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class VisaAuthenticationOptions
    {
        /// <summary>
        /// Acquirer identification code as assigned by the Directory Server.
        /// </summary>
        public string AcquirerBIN { get; set; }

        /// <summary>
        /// Acquirer-assigned Merchant identifier.
        /// </summary>
        public string AcquirerMerchantId { get; set; }

        /// <summary>
        /// Merchant name assigned by the Acquirer or Payment System.
        /// </summary>
        public string MerchantName { get; set; }
    }
}
