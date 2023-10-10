/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificInputBase
    {
        /// <summary>
        /// * true - Default - Allows subsequent payments to use PSD2 dynamic linking from this payment (including Card On File).<para />
        /// * false - Indicates that the dynamic linking (including Card On File data) will be ignored.<para />
        /// </summary>
        public bool? AllowDynamicLinking { get; set; } = null;

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
        /// Object containing specific input required for Dynamic Currency Conversion.<para />
        /// </summary>
        public CurrencyConversionSpecificInput CurrencyConversionSpecificInput { get; set; } = null;

        /// <summary>
        /// The unique scheme transactionId of the initial transaction that was performed with SCA. In case this is unknown a scheme transactionId of an earlier transaction part of the same sequence can be used as a fall-back. Strongly advised to be submitted for any MerchantInitiated or recurring transaction (a subsequent one).<para />
        /// </summary>
        public string InitialSchemeTransactionId { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for CB payments<para />
        /// </summary>
        public PaymentProduct130SpecificInput PaymentProduct130SpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for OneyDuplo Leroy Merlin payments.<para />
        /// </summary>
        public PaymentProduct3208SpecificInput PaymentProduct3208SpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for OneyDuplo Alcampo payments.<para />
        /// </summary>
        public PaymentProduct3209SpecificInput PaymentProduct3209SpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for Cpay payments.<para />
        /// </summary>
        public PaymentProduct5100SpecificInput PaymentProduct5100SpecificInput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// Object containing data related to recurring<para />
        /// </summary>
        public CardRecurrenceDetails Recurring { get; set; } = null;

        /// <summary>
        /// Object containing specific data regarding 3-D Secure<para />
        /// </summary>
        public ThreeDSecureBase ThreeDSecure { get; set; } = null;

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
