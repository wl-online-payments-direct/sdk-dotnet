/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubMerchant
    {
        /// <summary>
        /// Object containing billing address details.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Business Establishment Directory Identification System
        /// </summary>
        public string CompanyIdentificationNumber { get; set; }

        /// <summary>
        /// Name of the sales establishment requesting the transaction.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// MCC is a four-digit number that classifies the type of goods or services a business offers.
        /// </summary>
        public string MerchantCategoryCode { get; set; }

        /// <summary>
        /// Merchant Identifier is a value defined by the acquirer.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Website address of the submerchant.
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubMerchant WithAddress(Address value)
        {
            Address = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubMerchant WithCompanyIdentificationNumber(string value)
        {
            CompanyIdentificationNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubMerchant WithCompanyName(string value)
        {
            CompanyName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubMerchant WithMerchantCategoryCode(string value)
        {
            MerchantCategoryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubMerchant WithMerchantId(string value)
        {
            MerchantId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubMerchant WithWebsite(string value)
        {
            Website = value;
            return this;
        }
    }
}
