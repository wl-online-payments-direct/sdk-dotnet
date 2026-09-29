/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AuthenticationOptions
    {
        /// <summary>
        /// Acquiring institution identification code as assigned by the 3DS Directory Server receiving the AReq message.
        /// </summary>
        public string AcquirerBIN { get; set; }

        /// <summary>
        /// Acquiring institution identification code.
        /// </summary>
        public string AcquirerMerchantId { get; set; }

        /// <summary>
        /// Code representing merchant’s type of business, product or service.
        /// </summary>
        public string MerchantCategoryCode { get; set; }

        /// <summary>
        /// ISO-3166 country code of the merchant.
        /// </summary>
        public string MerchantCountryCode { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AuthenticationOptions WithAcquirerBIN(string value)
        {
            AcquirerBIN = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AuthenticationOptions WithAcquirerMerchantId(string value)
        {
            AcquirerMerchantId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AuthenticationOptions WithMerchantCategoryCode(string value)
        {
            MerchantCategoryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AuthenticationOptions WithMerchantCountryCode(string value)
        {
            MerchantCountryCode = value;
            return this;
        }
    }
}
