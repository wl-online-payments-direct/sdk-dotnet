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
    }
}
