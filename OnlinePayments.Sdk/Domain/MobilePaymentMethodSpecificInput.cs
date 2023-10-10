/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MobilePaymentMethodSpecificInput
    {
        /// <summary>
        /// Determines the type of the authorization that will be used. Allowed values: <para />
        ///   * FINAL_AUTHORIZATION - The payment creation results in an authorization that is ready for capture. Final authorizations can't be reversed and need to be captured for the full amount within 7 days. <para />
        ///   * PRE_AUTHORIZATION - The payment creation results in a pre-authorization that is ready for capture. Pre-authortizations can be reversed and can be captured within 30 days. The capture amount can be lower than the authorized amount. <para />
        ///   * SALE - The payment creation results in an authorization that is already captured at the moment of approval. <para />
        /// <para />
        ///   Only used with some acquirers, ignored for acquirers that do not support this. In case the acquirer does not allow this to be specified the authorizationMode is 'unspecified', which behaves similar to a final authorization.<para />
        /// </summary>
        public string AuthorizationMode { get; set; } = null;

        /// <summary>
        /// The payment data if you do the decryption of the encrypted payment data yourself.<para />
        /// </summary>
        public DecryptedPaymentData DecryptedPaymentData { get; set; } = null;

        /// <summary>
        /// The payment data if we will do the decryption of the encrypted payment data. Typically you'd use encryptedCustomerInput in the root of the create payment request to provide the encrypted payment data instead.<para />
        /// * For Apple Pay, the encrypted payment data can be found in property data of the PKPayment.token.paymentData property.<para />
        /// </summary>
        public string EncryptedPaymentData { get; set; } = null;

        /// <summary>
        /// Ephemeral Key<para />
        /// A unique generated key used by Apple to encrypt data.<para />
        /// </summary>
        public string EphemeralKey { get; set; } = null;

        /// <summary>
        /// Object containing information specific to Google Pay. Required for payments with product 320.<para />
        /// </summary>
        public MobilePaymentProduct320SpecificInput PaymentProduct320SpecificInput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// Public Key Hash<para />
        /// A unique identifier to retrieve key used by Apple to encrypt information.<para />
        /// </summary>
        public string PublicKeyHash { get; set; } = null;

        /// <summary>
        /// * true = the payment requires approval before the funds will be captured using the Approve payment or Capture payment API<para />
        /// * false = the payment does not require approval, and the funds will be captured automatically<para />
        /// </summary>
        public bool? RequiresApproval { get; set; } = null;
    }
}
