/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct840SpecificOutput
    {
        /// <summary>
        /// Object containing billing address details.
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Object containing address information
        /// </summary>
        public AddressPersonal BillingPersonalAddress { get; set; }

        /// <summary>
        /// Object containing the details of the PayPal account
        /// </summary>
        public PaymentProduct840CustomerAccount CustomerAccount { get; set; }

        /// <summary>
        /// Object containing billing address details.
        /// </summary>
        public Address CustomerAddress { get; set; }

        /// <summary>
        /// Id of a transaction given by PayPal
        /// </summary>
        public string PayPalTransactionId { get; set; }

        /// <summary>
        /// Kind of seller protection in force for the PayPal transaction
        /// </summary>
        public ProtectionEligibility ProtectionEligibility { get; set; }

        /// <summary>
        /// Object containing address information
        /// </summary>
        public AddressPersonal ShippingAddress { get; set; }
    }
}
