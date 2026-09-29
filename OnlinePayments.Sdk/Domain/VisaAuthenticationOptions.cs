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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public VisaAuthenticationOptions WithAcquirerBIN(string value)
        {
            AcquirerBIN = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public VisaAuthenticationOptions WithAcquirerMerchantId(string value)
        {
            AcquirerMerchantId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public VisaAuthenticationOptions WithMerchantName(string value)
        {
            MerchantName = value;
            return this;
        }
    }
}
