/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DirectoryEntry
    {
        /// <summary>
        /// Deprecated. Unique ID of the issuing bank of the customer
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// To be used to sort the issuers.
        /// short - These issuers should be presented at the top of the list
        /// long - These issuers should be presented after the issuers marked as short
        /// Note this is only filled if supported by the payment product. Currently only iDeal (809) support this. Sorting within the groups should be done alphabetically
        /// </summary>
        public string IssuerList { get; set; }

        /// <summary>
        /// Name of the issuing bank as it should be presented to the customer
        /// </summary>
        public string IssuerName { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DirectoryEntry WithIssuerId(string value)
        {
            IssuerId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DirectoryEntry WithIssuerList(string value)
        {
            IssuerList = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DirectoryEntry WithIssuerName(string value)
        {
            IssuerName = value;
            return this;
        }
    }
}
