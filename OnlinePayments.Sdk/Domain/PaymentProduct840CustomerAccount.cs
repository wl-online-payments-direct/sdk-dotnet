/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct840CustomerAccount
    {
        /// <summary>
        /// Username with which the PayPal account holder has registered at PayPal<para />
        /// </summary>
        public string AccountId { get; set; } = null;

        /// <summary>
        /// Name of the company in case the PayPal account is owned by a business<para />
        /// </summary>
        public string CompanyName { get; set; } = null;

        /// <summary>
        /// ISO 3166-1 alpha-2 country code<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// Status of the PayPal account<para />
        /// * verified - PayPal has verified the funding means for this account<para />
        /// * unverified - PayPal has not verified the funding means for this account<para />
        /// </summary>
        public string CustomerAccountStatus { get; set; } = null;

        /// <summary>
        /// Status of the customer's shipping address as registered by PayPal<para />
        /// * none - Status is unknown at PayPal<para />
        /// * confirmed - The address has been confirmed<para />
        /// * unconfirmed - The address has not been confirmed<para />
        /// </summary>
        public string CustomerAddressStatus { get; set; } = null;

        /// <summary>
        /// First name of the PayPal account holder<para />
        /// </summary>
        public string FirstName { get; set; } = null;

        /// <summary>
        /// The unique identifier of a PayPal account and will never change in the life cycle of a PayPal account<para />
        /// </summary>
        public string PayerId { get; set; } = null;

        /// <summary>
        /// Surname of the PayPal account holder<para />
        /// </summary>
        public string Surname { get; set; } = null;
    }
}
