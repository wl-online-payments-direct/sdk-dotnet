/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MobilePaymentMethodSpecificInput
    {
        /// <summary>
        /// Determines the type of the authorization that will be used. Allowed values:
        /// <list type="bullet">
        ///   <item><description>FINAL_AUTHORIZATION - The payment creation results in an authorization that is ready for capture. Final authorizations can't be reversed and need to be captured for the full amount within 7 days.</description></item>
        ///   <item><description>PRE_AUTHORIZATION - The payment creation results in a pre-authorization that is ready for capture. Pre-authortizations can be reversed and can be captured within 30 days. The capture amount can be lower than the authorized amount.</description></item>
        ///   <item><description>SALE - The payment creation results in an authorization that is already captured at the moment of approval.</description></item>
        /// </list>
        /// <p />
        /// Only used with some acquirers, ignored for acquirers that do not support this. In case the acquirer does not allow this to be specified the authorizationMode is 'unspecified', which behaves similar to a final authorization.
        /// </summary>
        public string AuthorizationMode { get; set; }

        /// <summary>
        /// The payment data if you do the decryption of the encrypted payment data yourself.
        /// </summary>
        public DecryptedPaymentData DecryptedPaymentData { get; set; }

        /// <summary>
        /// The payment data if we will do the decryption of the encrypted payment data. Typically you'd use encryptedCustomerInput in the root of the create payment request to provide the encrypted payment data instead.
        /// <list type="bullet">
        ///   <item><description>For Apple Pay, the encrypted payment data can be found in property data of the PKPayment.token.paymentData property.</description></item>
        /// </list>
        /// </summary>
        public string EncryptedPaymentData { get; set; }

        /// <summary>
        /// Ephemeral Key
        /// A unique generated key used by Apple to encrypt data.
        /// </summary>
        public string EphemeralKey { get; set; }

        /// <summary>
        /// Object containing information specific to Apple Pay.
        /// </summary>
        public MobilePaymentProduct302SpecificInput PaymentProduct302SpecificInput { get; set; }

        /// <summary>
        /// Object containing information specific to Google Pay. Required for payments with product 320.
        /// </summary>
        public MobilePaymentProduct320SpecificInput PaymentProduct320SpecificInput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Public Key Hash
        /// A unique identifier to retrieve key used by Apple to encrypt information.
        /// </summary>
        public string PublicKeyHash { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true = the payment requires approval before the funds will be captured using the Approve payment or Capture payment API</description></item>
        ///   <item><description>false = the payment does not require approval, and the funds will be captured automatically</description></item>
        /// </list>
        /// </summary>
        public bool? RequiresApproval { get; set; }
    }
}
