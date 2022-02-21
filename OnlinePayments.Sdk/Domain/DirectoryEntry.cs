/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DirectoryEntry
    {
        /// <summary>
        /// Unique ID of the issuing bank of the customer<para />
        /// </summary>
        public string IssuerId { get; set; } = null;

        /// <summary>
        /// To be used to sort the issuers.<para />
        ///   short - These issuers should be presented at the top of the list<para />
        ///   long - These issuers should be presented after the issuers marked as short<para />
        ///   Note this is only filled if supported by the payment product. Currently only iDeal (809) support this. Sorting within the groups should be done alphabetically<para />
        /// </summary>
        public string IssuerList { get; set; } = null;

        /// <summary>
        /// Name of the issuing bank as it should be presented to the customer<para />
        /// </summary>
        public string IssuerName { get; set; } = null;
    }
}
