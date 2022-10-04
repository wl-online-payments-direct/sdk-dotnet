/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificInput
    {
        /// <summary>
        /// Determines the type of the authorization that will be used. Allowed values: <para />
        ///   * FINAL_AUTHORIZATION - The payment creation results in an authorization that is ready for capture. Final authorizations can't be reversed and need to be captured for the full amount within 7 days. <para />
        ///   * PRE_AUTHORIZATION - The payment creation results in a pre-authorization that is ready for capture. Pre-authortizations can be reversed and can be captured within 30 days. The capture amount can be lower than the authorized amount. <para />
        ///   * SALE - The payment creation results in an authorization that is already captured at the moment of approval. <para />
        /// <para />
        ///   Only used with some acquirers, ignored for acquirers that don't support this. In case the acquirer doesn't allow this to be specified the authorizationMode is 'unspecified', which behaves similar to a final authorization.<para />
        /// </summary>
        public string AuthorizationMode { get; set; } = null;

        /// <summary>
        /// Object containing card details<para />
        /// </summary>
        public Card Card { get; set; } = null;

        /// <summary>
        /// The end date of the last scheduled payment in a series of transactions.<para />
        /// Format YYYYMMDD<para />
        /// </summary>
        public string CardOnFileRecurringExpiration { get; set; } = null;

        /// <summary>
        /// Period of payment occurrence for recurring and installment payments. Allowed values:<para />
        ///   * Yearly<para />
        ///   * Quarterly<para />
        ///   * Monthly<para />
        ///   * Weekly<para />
        ///   * Daily<para />
        /// </summary>
        public string CardOnFileRecurringFrequency { get; set; } = null;

        /// <summary>
        /// The unique scheme transactionId of the initial transaction that was performed with SCA. In case this is unknown a scheme transactionId of an earlier transaction part of the same sequence can be used as a fall-back. Strongly advised to be submitted for any MerchantInitiated or recurring transaction (a subsequent one).<para />
        /// </summary>
        public string InitialSchemeTransactionId { get; set; } = null;

        /// <summary>
        /// * true - Only payment products that support recurring payments will be shown. Any transactions created will also be tagged as being a first of a recurring sequence.<para />
        /// * false - Only payment products that support one-off payments will be shown.<para />
        /// The default value for this property is false.<para />
        /// </summary>
        public bool? IsRecurring { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for CB payments<para />
        /// </summary>
        public PaymentProduct130SpecificInput PaymentProduct130SpecificInput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// Object containing data related to recurring<para />
        /// </summary>
        public CardRecurrenceDetails Recurring { get; set; } = null;

        /// <summary>
        /// The URL that the customer is redirect to after the payment flow has finished. You can add any number of key value pairs in the query string that, for instance help you to identify the customer when they return to your site. Please note that we will also append some additional key value pairs that will also help you with this identification process.<para />
        /// Note: The provided URL should be absolute and contain the protocol to use, e.g. http:// or https://. For use on mobile devices a custom protocol can be used in the form of protocol://. This protocol must be registered on the device first.<para />
        /// URLs without a protocol will be rejected.<para />
        /// </summary>
        public string ReturnUrl { get; set; } = null;

        /// <summary>
        /// This is the unique Scheme Reference Data from the initial transaction that was performed with a Strong Customer Authentication. In case this value is unknown, a Scheme Reference of an earlier transaction that was part of the same sequence can be used as a fall-back. Still, it is strongly advised to submit this value for any Merchant Initiated Transaction or any recurring transaction (hereby defined as "Subsequent").<para />
        /// </summary>
        public string SchemeReferenceData { get; set; } = null;

        /// <summary>
        /// Deprecated: Use threeDSecure.skipAuthentication instead.<para />
        ///  * true = 3D Secure authentication will be skipped for this transaction. This setting should be used when isRecurring is set to true and recurringPaymentSequenceIndicator is set to recurring.<para />
        ///  * false = 3D Secure authentication will not be skipped for this transaction.<para />
        /// <para />
        ///   Note: This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction.<para />
        /// </summary>
        public bool? SkipAuthentication { get; set; } = null;

        /// <summary>
        /// Object containing specific data regarding 3-D Secure<para />
        /// </summary>
        public ThreeDSecure ThreeDSecure { get; set; } = null;

        /// <summary>
        /// ID of the token to use to create the payment.<para />
        /// </summary>
        public string Token { get; set; } = null;

        /// <summary>
        /// Indicates if this transaction should be tokenized<para />
        ///  * true - Tokenize the transaction. Note that a payment on the payment platform that results in a status REDIRECTED cannot be tokenized in this way.<para />
        ///  * false - Do not tokenize the transaction, unless it would be tokenized by other means such as auto-tokenization of recurring payments.<para />
        /// </summary>
        public bool? Tokenize { get; set; } = null;

        /// <summary>
        /// Indicates the channel via which the payment is created. Allowed values:<para />
        ///   * ECOMMERCE - The transaction is a regular E-Commerce transaction.<para />
        ///   * MOTO - The transaction is a Mail Order/Telephone Order.<para />
        /// <para />
        ///   Defaults to ECOMMERCE.<para />
        /// </summary>
        public string TransactionChannel { get; set; } = null;

        /// <summary>
        /// Indicates which party initiated the unscheduled recurring transaction. Allowed values:<para />
        ///   * merchantInitiated - Merchant Initiated Transaction.<para />
        ///   * cardholderInitiated - Cardholder Initiated Transaction.<para />
        /// Note:<para />
        ///   * This property is not allowed if isRecurring is true.<para />
        ///   * When a customer has chosen to use a token on a hosted checkout this property is set to "cardholderInitiated".<para />
        /// </summary>
        public string UnscheduledCardOnFileRequestor { get; set; } = null;

        /// <summary>
        /// * first = This transaction is the first of a series of unscheduled recurring transactions<para />
        /// * subsequent = This transaction is a subsequent transaction in a series of unscheduled recurring transactions<para />
        /// Note: this property is not allowed if isRecurring is true.<para />
        /// </summary>
        public string UnscheduledCardOnFileSequenceIndicator { get; set; } = null;
    }
}
